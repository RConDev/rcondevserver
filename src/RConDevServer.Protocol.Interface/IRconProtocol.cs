using System;
using System.Drawing;
using System.Windows.Forms;

namespace RConDevServer.Protocol.Interface
{
    /// <summary>
    /// The Basic Interface for RCon-Protocol Implementations
    /// </summary>
    public interface IRconProtocol
    {
        /// <summary>
        /// Gets an instance which is resonsible to deliver several services
        /// </summary>
        IServiceLocator ServiceLocator { get; set; }

        /// <summary>
        /// A unique Code of the Protocol / Game 
        /// </summary>
        string ProtocolCode { get; }

        /// <summary>
        /// the display name of the protocol implementation
        /// </summary>
        string ProtocolName { get; }

        /// <summary>
        /// the version of the protocol implementation
        /// </summary>
        string Version { get; }

        /// <summary>
        /// the icon image of the protocol
        /// </summary>
        Image IconImage { get; }

        /// <summary>
        /// the ui part of the implementation
        /// </summary>
        Control MainControl { get; }

        void Initialize();

        void OnClientConnected(object sender, ClientEventArgs e);

        void OnStopped(object sender, EventArgs e);
    }

}