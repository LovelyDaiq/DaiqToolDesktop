using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DaiqDesktop
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = "Server=[填写您的SQL服务器ip];Port=[请填写您的端口];Da
            tabase=[填写您的数据库地址];Uid=[数据库用户名];Pwd=[数据库密码];Charset=utf8mb4;SslMode=none;";

        /// <summary>
        /// 验证用户登录
        /// </summary>
        public static (bool success, string username, int userId, string message) ValidateLogin(string username, string password)
        {
            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                conn.Open();

                string sql = @"SELECT id, username, password FROM admin_users 
                               WHERE username = @username AND password = @password";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return (true, reader.GetString("username"), reader.GetInt32("id"), "登录成功");
                }
                return (false, "", 0, "用户名或密码错误");
            }
            catch (Exception ex)
            {
                return (false, "", 0, $"数据库错误: {ex.Message}");
            }
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        public static (bool success, string message) RegisterUser(string username, string password)
        {
            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                conn.Open();

                // 检查用户名是否已存在
                string checkSql = "SELECT COUNT(*) FROM admin_users WHERE username = @username";
                using var checkCmd = new MySqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@username", username);

                long count = (long)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    return (false, "用户名已存在");
                }

                // 插入新用户
                string insertSql = "INSERT INTO admin_users (username, password) VALUES (@username, @password)";
                using var insertCmd = new MySqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", password);

                insertCmd.ExecuteNonQuery();
                return (true, "注册成功");
            }
            catch (Exception ex)
            {
                return (false, $"注册失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 提交游戏分数
        /// </summary>
        public static bool SubmitScore(int userId, string username, int score)
        {
            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                conn.Open();

                string sql = @"INSERT INTO game_scores (user_id, username, score, game_date) 
                               VALUES (@userId, @username, @score, NOW())
                               ON DUPLICATE KEY UPDATE 
                               score = GREATEST(score, @score),
                               game_date = IF(@score > score, NOW(), game_date)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@score", score);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"提交分数失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 获取排行榜（前10名）
        /// </summary>
        public static List<ScoreRecord> GetLeaderboard()
        {
            var list = new List<ScoreRecord>();
            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                conn.Open();

                string sql = @"SELECT username, MAX(score) as best_score, MAX(game_date) as last_play 
                               FROM game_scores 
                               GROUP BY user_id, username 
                               ORDER BY best_score DESC 
                               LIMIT 10";

                using var cmd = new MySqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();

                int rank = 1;
                while (reader.Read())
                {
                    list.Add(new ScoreRecord
                    {
                        Rank = rank++,
                        Username = reader.GetString("username"),
                        Score = reader.GetInt32("best_score"),
                        Date = reader.GetDateTime("last_play")
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取排行榜失败: {ex.Message}");
            }
            return list;
        }

        /// <summary>
        /// 获取当前用户的最佳分数
        /// </summary>
        public static int GetUserBestScore(int userId)
        {
            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                conn.Open();

                string sql = "SELECT MAX(score) as best FROM game_scores WHERE user_id = @userId";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                var result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
            catch
            {
                return 0;
            }
        }
    }

    public class ScoreRecord
    {
        public int Rank { get; set; }
        public string Username { get; set; } = "";
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
