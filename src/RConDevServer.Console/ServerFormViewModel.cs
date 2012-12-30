using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using RConDevServer.Core;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Console
{
    /// <summary>
    /// The view model for the central server form
    /// </summary>
    public class ServerFormViewModel : INotifyPropertyChanged
    {
        private IList<IRconProtocol> availableProtocols;

        private ServerInstance serverInstance;

        #region Constructor

        public ServerFormViewModel(ServerInstance serverInstance1)
        {
            ServerInstance = serverInstance1;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the current Application Product Name from Assemby Info
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets and sets the list of available protocols to be attached
        /// </summary>
        public IList<IRconProtocol> AvailableProtocols
        {
            get { return availableProtocols; }
            set
            {
                availableProtocols = value;
                InvokePropertyChanged("AvailableProtocols");
            }
        }

        /// <summary>
        /// Gets or sets the server instance
        /// </summary>
        public ServerInstance ServerInstance
        {
            get { return serverInstance; }
            set
            {
                serverInstance = value;
                InvokePropertyChanged("ServerInstance");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// invokes the <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propertyName"></param>
        private void InvokePropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}