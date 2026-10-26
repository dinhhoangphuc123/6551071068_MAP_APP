namespace _6551071068_MAP_APP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var login = new Forms.LoginForm();
            if (login.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Application.Run(new Forms.MainForm());
        }
    }
}
