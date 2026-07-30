using System;
using System.Drawing;
using System.Windows.Forms;

namespace DaiqDesktop
{
    public partial class Game_RUB : Form
    {
        private int[,] board;
        private Tetromino currentPiece;
        private Tetromino nextPiece;
        private Random random;
        private int score;
        private int lines;
        private int level;
        private bool gameOver;
        private bool paused;
        private int dropInterval;
        private Bitmap boardBuffer;
        private Bitmap nextBuffer;
        private const int CellSize = 30;
        private const int BoardWidth = 10;
        private const int BoardHeight = 20;
        private int animFrame;
        private bool clearing;
        private int[] clearRows;
        private System.Windows.Forms.Timer animTimer;

        public Game_RUB()
        {
            InitializeComponent();
            DoubleBuffered = true;
            random = new Random();
            score = 0;
            lines = 0;
            level = 1;
            dropInterval = 800;
            gameOver = false;
            paused = false;
            clearing = false;
            board = new int[BoardHeight, BoardWidth];
            boardBuffer = new Bitmap(BoardWidth * CellSize, BoardHeight * CellSize);
            nextBuffer = new Bitmap(4 * CellSize, 4 * CellSize);
            animFrame = 0;
            currentPiece = new Tetromino(random.Next(7));
            nextPiece = new Tetromino(random.Next(7));
        }

        private void Game_RUB_Load(object sender, EventArgs e)
        {
            animTimer = new System.Windows.Forms.Timer();
            animTimer.Interval = 16;
            animTimer.Tick += AnimTimer_Tick;
            animTimer.Start();
            gameTimer.Start();
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            animFrame++;
            if (clearing)
            {
                gameBoard.Invalidate();
            }
        }

        private void SpawnPiece()
        {
            currentPiece = nextPiece;
            nextPiece = new Tetromino(random.Next(7));
            if (!IsValidPosition(currentPiece))
            {
                gameOver = true;
                gameTimer.Stop();
                gameBoard.Invalidate();
            }
        }

        private bool IsValidPosition(Tetromino piece)
        {
            var cells = piece.GetCells();
            foreach (var cell in cells)
            {
                int r = cell[0];
                int c = cell[1];
                if (r < 0) continue;
                if (r >= BoardHeight || c < 0 || c >= BoardWidth) return false;
                if (board[r, c] != 0) return false;
            }
            return true;
        }

        private void LockPiece()
        {
            var cells = currentPiece.GetCells();
            int colorIdx = currentPiece.Type + 1;
            foreach (var cell in cells)
            {
                int r = cell[0];
                int c = cell[1];
                if (r >= 0 && r < BoardHeight && c >= 0 && c < BoardWidth)
                    board[r, c] = colorIdx;
            }
            CheckClearLines();
        }

        private void CheckClearLines()
        {
            var rows = new System.Collections.Generic.List<int>();
            for (int r = BoardHeight - 1; r >= 0; r--)
            {
                bool full = true;
                for (int c = 0; c < BoardWidth; c++)
                {
                    if (board[r, c] == 0) { full = false; break; }
                }
                if (full) rows.Add(r);
            }

            if (rows.Count > 0)
            {
                clearing = true;
                clearRows = rows.ToArray();
                gameTimer.Stop();
                System.Windows.Forms.Timer clearAnim = new System.Windows.Forms.Timer();
                clearAnim.Interval = 80;
                int step = 0;
                clearAnim.Tick += (s, ev) =>
                {
                    step++;
                    gameBoard.Invalidate();
                    if (step >= 6)
                    {
                        clearAnim.Stop();
                        clearing = false;
                        DoClearLines(rows.ToArray());
                        if (!gameOver) gameTimer.Start();
                    }
                };
                clearAnim.Start();
            }
            else
            {
                SpawnPiece();
            }
        }

        private void DoClearLines(int[] rows)
        {
            int cleared = rows.Length;
            foreach (int row in rows)
            {
                for (int rr = row; rr > 0; rr--)
                    for (int c = 0; c < BoardWidth; c++)
                        board[rr, c] = board[rr - 1, c];
                for (int c = 0; c < BoardWidth; c++) board[0, c] = 0;
            }

            lines += cleared;
            int[] pts = { 0, 40, 100, 300, 1200 };
            score += pts[cleared] * level;
            level = lines / 10 + 1;
            dropInterval = Math.Max(50, 800 - (level - 1) * 70);
            gameTimer.Interval = dropInterval;
            scoreLabel.Text = "SCORE: " + score;
            linesLabel.Text = "LINES: " + lines;
            levelLabel.Text = "LEVEL: " + level;
            SpawnPiece();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (paused || gameOver || clearing) return;
            if (!MovePiece(1, 0)) LockPiece();
            gameBoard.Invalidate();
            nextPieceBox.Invalidate();
        }

        private bool MovePiece(int dr, int dc)
        {
            var test = currentPiece.Clone();
            test.Row += dr;
            test.Col += dc;
            if (IsValidPosition(test))
            {
                currentPiece.Row = test.Row;
                currentPiece.Col = test.Col;
                return true;
            }
            return false;
        }

        private void RotatePiece()
        {
            var test = currentPiece.Clone();
            test.Rotate();
            if (IsValidPosition(test))
            {
                currentPiece.Rotate();
                return;
            }
            for (int off = -2; off <= 2; off++)
            {
                if (off == 0) continue;
                test.Col = currentPiece.Col + off;
                if (IsValidPosition(test))
                {
                    currentPiece.Rotate();
                    currentPiece.Col = test.Col;
                    return;
                }
            }
        }

        private void HardDrop()
        {
            int dist = 0;
            while (MovePiece(1, 0)) dist++;
            score += dist * 2;
            scoreLabel.Text = "SCORE: " + score;
            LockPiece();
        }

        private void Game_RUB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                if (!gameOver && !clearing)
                {
                    paused = !paused;
                    if (!paused) gameTimer.Start();
                    else gameTimer.Stop();
                }
                return;
            }

            if (gameOver)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RestartGame();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
                return;
            }

            if (paused || clearing) return;

            switch (e.KeyCode)
            {
                case Keys.Left: MovePiece(0, -1); break;
                case Keys.Right: MovePiece(0, 1); break;
                case Keys.Down: if (MovePiece(1, 0)) score++; break;
                case Keys.Up:
                case Keys.Z: RotatePiece(); break;
                case Keys.Space: HardDrop(); break;
                case Keys.Escape: Close(); break;
            }
            scoreLabel.Text = "SCORE: " + score;
            gameBoard.Invalidate();
            nextPieceBox.Invalidate();
        }

        private void RestartGame()
        {
            board = new int[BoardHeight, BoardWidth];
            score = 0;
            lines = 0;
            level = 1;
            dropInterval = 800;
            gameTimer.Interval = dropInterval;
            gameOver = false;
            paused = false;
            clearing = false;
            scoreLabel.Text = "SCORE: 0";
            linesLabel.Text = "LINES: 0";
            levelLabel.Text = "LEVEL: 1";
            currentPiece = new Tetromino(random.Next(7));
            nextPiece = new Tetromino(random.Next(7));
            SpawnPiece();
            gameTimer.Start();
            gameBoard.Invalidate();
            nextPieceBox.Invalidate();
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromImage(boardBuffer);
            g.Clear(Color.Black);

            for (int r = 0; r < BoardHeight; r++)
            {
                for (int c = 0; c < BoardWidth; c++)
                {
                    if (board[r, c] != 0)
                    {
                        if (clearing && System.Array.IndexOf(clearRows, r) >= 0)
                        {
                            DrawClearingCell(g, c, r, board[r, c]);
                        }
                        else
                        {
                            DrawCell(g, c, r, board[r, c]);
                        }
                    }
                }
            }

            if (currentPiece != null && !gameOver && !clearing)
            {
                DrawGhostPiece(g);
                var cells = currentPiece.GetCells();
                foreach (var cell in cells)
                {
                    int r = cell[0], c = cell[1];
                    if (r >= 0 && r < BoardHeight && c >= 0 && c < BoardWidth)
                        DrawCell(g, c, r, currentPiece.Type + 1);
                }
            }

            g.DrawRectangle(Pens.Gray, 0, 0, BoardWidth * CellSize - 1, BoardHeight * CellSize - 1);

            for (int c = 0; c <= BoardWidth; c++)
                g.DrawLine(Pens.DarkGray, c * CellSize, 0, c * CellSize, BoardHeight * CellSize);
            for (int r = 0; r <= BoardHeight; r++)
                g.DrawLine(Pens.DarkGray, 0, r * CellSize, BoardWidth * CellSize, r * CellSize);

            e.Graphics.DrawImage(boardBuffer, 0, 0);

            if (gameOver)
            {
                DrawGameOverOverlay(e.Graphics);
            }
            else if (paused)
            {
                DrawPausedOverlay(e.Graphics);
            }

            g.Dispose();
        }

        private void DrawGhostPiece(Graphics g)
        {
            var ghost = currentPiece.Clone();
            while (true)
            {
                var test = ghost.Clone();
                test.Row++;
                if (IsValidPosition(test))
                    ghost.Row++;
                else
                    break;
            }

            var cells = ghost.GetCells();
            foreach (var cell in cells)
            {
                int r = cell[0], c = cell[1];
                if (r >= 0 && r < BoardHeight && c >= 0 && c < BoardWidth)
                {
                    Rectangle rect = new Rectangle(c * CellSize + 8, r * CellSize + 8, CellSize - 17, CellSize - 17);
                    using (Pen p = new Pen(Color.FromArgb(80, Color.White), 2))
                    {
                        g.DrawRectangle(p, rect);
                    }
                }
            }
        }

        private void DrawClearingCell(Graphics g, int c, int r, int colorIdx)
        {
            Color[] colors = {
                Color.Cyan, Color.Yellow, Color.Magenta,
                Color.Blue, Color.Orange, Color.Green, Color.Red
            };
            Color col = colors[colorIdx - 1];
            int flash = (animFrame / 3) % 2;
            if (flash == 0)
            {
                Rectangle rect = new Rectangle(c * CellSize, r * CellSize, CellSize - 1, CellSize - 1);
                using (Brush b = new SolidBrush(Color.White))
                    g.FillRectangle(b, rect);
            }
            else
            {
                DrawCell(g, c, r, colorIdx);
            }
        }

        private void DrawGameOverOverlay(Graphics g)
        {
            using (Brush b = new SolidBrush(Color.FromArgb(180, Color.Black)))
                g.FillRectangle(b, 0, 0, BoardWidth * CellSize, BoardHeight * CellSize);

            string text = "GAME OVER";
            using (Font f = new Font("Courier New", 24, FontStyle.Bold))
            {
                SizeF size = g.MeasureString(text, f);
                float x = (BoardWidth * CellSize - size.Width) / 2;
                float y = BoardHeight * CellSize / 2 - 60;
                g.DrawString(text, f, Brushes.Red, x, y);
            }

            string scoreText = "SCORE: " + score;
            using (Font f = new Font("Courier New", 14, FontStyle.Bold))
            {
                SizeF size = g.MeasureString(scoreText, f);
                float x = (BoardWidth * CellSize - size.Width) / 2;
                g.DrawString(scoreText, f, Brushes.White, x, BoardHeight * CellSize / 2);
            }

            string restartText = "ENTER - Restart";
            using (Font f = new Font("Courier New", 12, FontStyle.Bold))
            {
                SizeF size = g.MeasureString(restartText, f);
                float x = (BoardWidth * CellSize - size.Width) / 2;
                g.DrawString(restartText, f, Brushes.Yellow, x, BoardHeight * CellSize / 2 + 40);
            }

            string quitText = "ESC - Quit";
            using (Font f = new Font("Courier New", 12, FontStyle.Bold))
            {
                SizeF size = g.MeasureString(quitText, f);
                float x = (BoardWidth * CellSize - size.Width) / 2;
                g.DrawString(quitText, f, Brushes.Gray, x, BoardHeight * CellSize / 2 + 70);
            }
        }

        private void DrawPausedOverlay(Graphics g)
        {
            using (Brush b = new SolidBrush(Color.FromArgb(150, Color.Black)))
                g.FillRectangle(b, 0, 0, BoardWidth * CellSize, BoardHeight * CellSize);

            string text = "PAUSED";
            using (Font f = new Font("Courier New", 28, FontStyle.Bold))
            {
                SizeF size = g.MeasureString(text, f);
                float x = (BoardWidth * CellSize - size.Width) / 2;
                float y = BoardHeight * CellSize / 2 - 30;
                g.DrawString(text, f, Brushes.Yellow, x, y);
            }
        }

        private void NextPieceBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromImage(nextBuffer);
            g.Clear(Color.Black);
            if (nextPiece != null)
            {
                var cells = nextPiece.GetCells();
                int minR = int.MaxValue, minC = int.MaxValue;
                foreach (var cell in cells)
                {
                    if (cell[0] < minR) minR = cell[0];
                    if (cell[1] < minC) minC = cell[1];
                }
                foreach (var cell in cells)
                {
                    int r = cell[0] - minR;
                    int c = cell[1] - minC;
                    DrawCell(g, c, r, nextPiece.Type + 1);
                }
            }
            e.Graphics.DrawImage(nextBuffer, 0, 0);
            g.Dispose();
        }

        private void DrawCell(Graphics g, int c, int r, int colorIdx)
        {
            Color[] colors = {
                Color.Cyan, Color.Yellow, Color.Magenta,
                Color.Blue, Color.Orange, Color.Green, Color.Red
            };
            Color col = colors[colorIdx - 1];
            Rectangle rect = new Rectangle(c * CellSize + 1, r * CellSize + 1, CellSize - 3, CellSize - 3);

            using (Brush b = new SolidBrush(col))
                g.FillRectangle(b, rect);

            using (Brush light = new SolidBrush(Color.FromArgb(100, Color.White)))
                g.FillRectangle(light, rect.X, rect.Y, rect.Width, 4);
            using (Brush dark = new SolidBrush(Color.FromArgb(80, Color.Black)))
                g.FillRectangle(dark, rect.X, rect.Y + rect.Height - 4, rect.Width, 4);

            g.DrawRectangle(Pens.White, rect);
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }
    }

    class Tetromino
    {
        private static readonly int[][][][] Shapes = new int[][][][]
        {
            new int[][][] {
                new int[][] { new[]{0,1}, new[]{0,2}, new[]{0,3}, new[]{0,4} },
                new int[][] { new[]{0,3}, new[]{1,3}, new[]{2,3}, new[]{3,3} },
                new int[][] { new[]{2,1}, new[]{2,2}, new[]{2,3}, new[]{2,4} },
                new int[][] { new[]{0,2}, new[]{1,2}, new[]{2,2}, new[]{3,2} }
            },
            new int[][][] {
                new int[][] { new[]{0,1}, new[]{0,2}, new[]{1,1}, new[]{1,2} },
                new int[][] { new[]{0,1}, new[]{0,2}, new[]{1,1}, new[]{1,2} },
                new int[][] { new[]{0,1}, new[]{0,2}, new[]{1,1}, new[]{1,2} },
                new int[][] { new[]{0,1}, new[]{0,2}, new[]{1,1}, new[]{1,2} }
            },
            new int[][][] {
                new int[][] { new[]{0,2}, new[]{1,1}, new[]{1,2}, new[]{1,3} },
                new int[][] { new[]{0,2}, new[]{1,2}, new[]{1,3}, new[]{2,2} },
                new int[][] { new[]{1,1}, new[]{1,2}, new[]{1,3}, new[]{2,2} },
                new int[][] { new[]{0,2}, new[]{1,1}, new[]{1,2}, new[]{2,2} }
            },
            new int[][][] {
                new int[][] { new[]{0,1}, new[]{1,1}, new[]{1,2}, new[]{1,3} },
                new int[][] { new[]{0,2}, new[]{0,3}, new[]{1,2}, new[]{2,2} },
                new int[][] { new[]{1,1}, new[]{1,2}, new[]{1,3}, new[]{2,3} },
                new int[][] { new[]{0,2}, new[]{1,2}, new[]{2,1}, new[]{2,2} }
            },
            new int[][][] {
                new int[][] { new[]{0,3}, new[]{1,1}, new[]{1,2}, new[]{1,3} },
                new int[][] { new[]{0,2}, new[]{1,2}, new[]{2,2}, new[]{2,3} },
                new int[][] { new[]{1,1}, new[]{1,2}, new[]{1,3}, new[]{2,1} },
                new int[][] { new[]{0,1}, new[]{0,2}, new[]{1,2}, new[]{2,2} }
            },
            new int[][][] {
                new int[][] { new[]{0,2}, new[]{0,3}, new[]{1,1}, new[]{1,2} },
                new int[][] { new[]{0,2}, new[]{1,2}, new[]{1,3}, new[]{2,3} },
                new int[][] { new[]{1,2}, new[]{1,3}, new[]{2,1}, new[]{2,2} },
                new int[][] { new[]{0,1}, new[]{1,1}, new[]{1,2}, new[]{2,2} }
            },
            new int[][][] {
                new int[][] { new[]{0,1}, new[]{0,2}, new[]{1,2}, new[]{1,3} },
                new int[][] { new[]{0,3}, new[]{1,2}, new[]{1,3}, new[]{2,2} },
                new int[][] { new[]{1,1}, new[]{1,2}, new[]{2,2}, new[]{2,3} },
                new int[][] { new[]{0,2}, new[]{1,1}, new[]{1,2}, new[]{2,1} }
            }
        };

        public int Type { get; private set; }
        public int Rotation { get; private set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Tetromino(int type)
        {
            Type = type;
            Rotation = 0;
            Row = 0;
            Col = 3;
        }

        public int[][] GetCells()
        {
            var cells = Shapes[Type][Rotation];
            var result = new int[4][];
            for (int i = 0; i < 4; i++)
            {
                result[i] = new int[] { cells[i][0] + Row, cells[i][1] + Col };
            }
            return result;
        }

        public void Rotate() { Rotation = (Rotation + 1) % 4; }

        public Tetromino Clone()
        {
            return new Tetromino(Type) { Rotation = Rotation, Row = Row, Col = Col };
        }
    }
}