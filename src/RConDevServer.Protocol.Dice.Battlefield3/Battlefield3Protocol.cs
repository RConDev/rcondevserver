using System;
using System.Drawing;
using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Controls;
using RConDevServer.Protocol.Dice.Battlefield3.DataStore;
using RConDevServer.Protocol.Dice.Battlefield3.Properties;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3
{
    public class Battlefield3Protocol : IRconProtocol
    {
        public Battlefield3Server Bf3Server { get; private set; }

        #region IRconProtocol Members

        public IServiceLocator ServiceLocator { get; set; }

        public string ProtocolCode
        {
            get { return Constants.PROTOCOL_CODE; }
        }

        public string ProtocolName
        {
            get { return Constants.PROTOCOL_NAME + " (" + Constants.PROTOCOL_VERSION + ")"; }
        }

        public string Version
        {
            get { return Constants.PROTOCOL_VERSION; }
        }

        public Image IconImage
        {
            get { return Resources.bf3_logo; }
        }

        public Control MainControl
        {
            get
            {
                var mainControl = new MainControl();
                mainControl.DataContext = new ServerViewModel(this.Bf3Server, a => mainControl.Invoke(a));
                return mainControl;
            }
        }

        public void Initialize()
        {
            this.Bf3Server = new Battlefield3Server(this.ServiceLocator);
            this.Bf3Server.Initialize();
        }

        public void OnClientConnected(object sender, ClientEventArgs e)
        {
            this.Bf3Server.OnClientConnected(sender, e);
        }

        public void OnStopped(object sender, EventArgs e)
        {
            this.Bf3Server.OnStopped(sender, e);
        }

        #endregion
    }
}