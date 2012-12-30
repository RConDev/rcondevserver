using System;
using System.Net.Sockets;

namespace RConDevServer.Protocol.Interface
{
    /// <summary>
    /// IRConSession information
    /// </summary>
    public interface IRconSession : IDisposable
    {
        /// <summary>
        /// the unique IrConSession id
        /// </summary>
        Guid Uid { get; }

        /// <summary>
        /// timestamp of the IrConSession creation
        /// </summary>
        DateTime Created { get; }

        Socket Socket { get; set; }

        /// <summary>
        /// this event is invoked, when new byte data was received from the client
        /// </summary>
        event EventHandler<ByteDataEventArgs> DataReceived;

        /// <summary>
        /// this event is invoked, when data is sent to the client
        /// </summary>
        event EventHandler<ByteDataEventArgs> DataSent;

        /// <summary>
        /// this event is invoked, when the socket to the client was closed
        /// </summary>
        event EventHandler<SessionEventArgs> Closed;

        /// <summary>
        /// sends the data to the client
        /// </summary>
        /// <param name="bytes"></param>
        void SendToClient(byte[] bytes);

        void Close();

        void WaitForData(Socket listeningSocket);
    }
}