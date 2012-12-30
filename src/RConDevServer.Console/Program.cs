using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Windows.Forms;
using RConDevServer.Console.Properties;
using RConDevServer.Core;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Console
{
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