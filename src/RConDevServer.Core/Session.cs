using RConDevServer.Protocol.Interface;
using RConDevServer.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;

namespace RConDevServer.Core
{
    /// <summary>
    /// the Session wraps a client connection to the <see cref="ServerInstance"/>
    /// </summary>
    public class Session : IRconSession
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// gets the bytes the client received from the <see cref="ServerInstance"/>
        /// </summary>
        public IList<byte[]> BytesReceived { get; private set; }

        /// <summary>
        /// the unique Session id
        /// </summary>
        public Guid Uid { get; private set; }

        /// <summary>
        /// timestamp of the Session creation
        /// </summary>
        public DateTime Created { get; private set; }

        /// <summary>
        /// the communication socket to the client
        /// </summary>
        public Socket Socket { get; set; }

        #region Events

        /// <summary>
        /// this event is invoked, when new byte data was received from the client
        /// </summary>
        public event EventHandler<ByteDataEventArgs> DataReceived;

        /// <summary>
        /// this event is invoked, when data is sent to the client
        /// </summary>
        public event EventHandler<ByteDataEventArgs> DataSent;

        /// <summary>
        /// this event is invoked, when the socket to the client was closed
        /// </summary>
        public event EventHandler<SessionEventArgs> Closed;

        #endregion

        /// <summary>
        /// basically sets up the Session
        /// </summary>
        internal Session()
        {
            Uid = Guid.NewGuid();
            BytesReceived = new List<byte[]>();
            Created = DateTime.Now;
        }

        /// <summary>
        /// sets up the Session for a client socket 
        /// </summary>
        /// <param name="socket"></param>
        public Session(Socket socket) : this()
        {
           log.DebugFormat("Creating socket to remote endpoint {0}", socket.RemoteEndPoint);
            Socket = socket;
        }

        /// <summary>
        /// sends the data to the client
        /// </summary>
        /// <param name="bytes"></param>
        public void SendToClient(byte[] bytes)
        {
            var buffer = new SessionBuffer(this, Socket, bytes);
            Socket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, SendCallback, buffer);
            log.DebugFormat("Sending {0} bytes to client on Session '{1}'", bytes.Length, this.Uid);
        }

        public void Close()
        {
            log.DebugFormat("Closing socket to remote endpoint {0}", this.Socket.RemoteEndPoint);
            Socket.Shutdown(SocketShutdown.Both);
            Socket.Close();
        }

        public void Dispose()
        {
            Close();
        }

        #region Private Methods

        public void WaitForData(Socket socket)
        {
            var buffer = new SessionBuffer(this, socket, Constants.DEFAULT_BUFFER_SIZE);
            socket.BeginReceive(buffer.Buffer, 0, Constants.DEFAULT_BUFFER_SIZE, SocketFlags.None, SocketReceiveCallback, buffer);
        }

        private void SocketReceiveCallback(IAsyncResult ar)
        {
            var buffer = ar.AsyncState as SessionBuffer;
            if (buffer != null)
            {
                try
                {
                    var bytesRead = buffer.Socket.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        var bytes = new byte[bytesRead];
                        Array.Copy(buffer.Buffer, 0, bytes, 0, bytesRead);
                        BytesReceived.Add(bytes);
                        InvokeDataReceived(bytes);
                        WaitForData(Socket);   
                    }
                    else
                    {
                        log.Debug("Remote socket disconnects");
                        InvokeClosed();
                    }
                }
                catch(SocketException se)
                {
                    log.Debug(string.Format("Error in socket-communication. Session-Id:{0}", this.Uid), se);
                    InvokeClosed();
                }
                catch(ObjectDisposedException)
                {
                    log.DebugFormat("Waiting Session-ListeningSocket was closed. Session-Id:{0}", this.Uid);
                    InvokeClosed();
                }
                catch (Exception e)
                {
                    log.Debug(string.Format("Other error in ListeningSocket Communication. Session-Id:{0}", this.Uid),e);
                    InvokeClosed();
                }
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            var sessionBuffer = ar.AsyncState as SessionBuffer;
            if (sessionBuffer != null)
            {
                var bytesSent = sessionBuffer.Socket.EndSend(ar);
                if (bytesSent > 0 && bytesSent == sessionBuffer.Buffer.Length)
                {
                    InvokeDataSent(sessionBuffer.Buffer);
                }
            }
        }

        #endregion

        #region Invoke Events

        internal void InvokeDataReceived(byte[] byteData)
        {
            if (DataReceived == null) return;

            DataReceived.InvokeAll(this, new ByteDataEventArgs(byteData));
        }

        internal void InvokeDataSent(byte[] bytes)
        {
            if (DataSent == null) return;

            DataSent.InvokeAll(this, new ByteDataEventArgs(bytes));
        }

        internal void InvokeClosed()
        {
            if (Closed == null) return;

            Closed.InvokeAll(this, new SessionEventArgs(this));
        }

        #endregion

        #region Equality Members

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(IRconSession)) return false;
            return Equals((IRconSession)obj);
        }

        public bool Equals(IRconSession other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Uid.Equals(Uid);
        }

        public override int GetHashCode()
        {
            return Uid.GetHashCode();
        }

        #endregion
    }
}