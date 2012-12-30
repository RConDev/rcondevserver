using RConDevServer.Protocol.Interface;
using System.Net.Sockets;

namespace RConDevServer.Core
{
    /// <summary>
    /// the Session buffer is used for the asynchronous communication between client an <see cref="ServerInstance"/>
    /// </summary>
    public class SessionBuffer
    {
        #region Constructors

        /// <summary>
        /// hidden default constructor
        /// </summary>
        /// <param name="irConSession"></param>
        /// <param name="socket"></param>
        private SessionBuffer(IRconSession irConSession, Socket socket)
        {
            IrConSession = irConSession;
            Socket = socket;
        }

        /// <summary>
        /// creates a Session buffer for reading bytes
        /// </summary>
        /// <param name="irConSession"></param>
        /// <param name="socket"></param>
        /// <param name="bufferSize"></param>
        public SessionBuffer(IRconSession irConSession, Socket socket, int bufferSize)
            : this(irConSession, socket)
        {
            Buffer = new byte[bufferSize];
        }

        /// <summary>
        /// creates a Session buffer for existing bytes
        /// </summary>
        /// <param name="irConSession"></param>
        /// <param name="socket"></param>
        /// <param name="bufferedBytes"></param>
        public SessionBuffer(IRconSession irConSession, Socket socket, byte[] bufferedBytes)
            : this(irConSession, socket)
        {
            Buffer = bufferedBytes;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// the content bytes of the current buffer
        /// </summary>
        public byte[] Buffer { get; set; }

        /// <summary>
        /// the socket the bytes where sent to / received from
        /// </summary>
        public Socket Socket { get; private set; }

        /// <summary>
        /// the Session the socket refers to
        /// </summary>
        public IRconSession IrConSession { get; set; }

        #endregion
    }
}