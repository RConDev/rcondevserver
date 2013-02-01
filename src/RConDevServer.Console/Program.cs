namespace RConDevServer.Console
{
    using System;
    using System.Windows.Forms;

    public static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var application = new RConDevServerApplication();
            Application.Run(application);
        }
    }
}