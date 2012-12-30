using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ninject;
using RConDevServer.Console.Properties;
using RConDevServer.Core;
using RConDevServer.Protocol.Interface;
using RConDevServer.Util;

namespace RConDevServer.Console
{
    public class RConDevServerApplication : ApplicationContext
    {
        public RConDevServerApplication()
        {
            // create the server instance
            var serverInstance = new ServerInstance(Settings.Default.ListenOnPort, Settings.Default.MaxSessions);
            var viewModel = new ServerFormViewModel(serverInstance);

            var connectionString = ConfigurationManager.ConnectionStrings["Default"];
            var connection = new SQLiteConnection(connectionString.ConnectionString);
            
            var kernel = new StandardKernel();
            IServiceLocator serviceLocator = new NinjectServiceLocator(kernel);
            serviceLocator.RegisterService(typeof(IDbConnection), connection);

            // read all available protocols
            IList<IRconProtocol> protocols = new ProtocolLoader().LoadProtocols("protocols", serviceLocator.Clone() as IServiceLocator);
            viewModel.AvailableProtocols = protocols;

            var serverForm = new ServerForm
                {
                    DataContext = viewModel
                };
            this.MainForm = serverForm;
        }
    }
}
