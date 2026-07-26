namespace DaiqDesktop
{
    internal static class Program
    {
        public static string? CurrentUsername { get; set; }
        public static int CurrentUserId { get; set; }
        public static bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUsername);

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
