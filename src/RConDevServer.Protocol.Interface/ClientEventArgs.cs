using System;

namespace RConDevServer.Protocol.Interface
{
    public class ClientEventArgs : EventArgs
    {
        public IRconSession Session { get; private set; }

        public ClientEventArgs(IRconSession session)
        {
            this.Session = session;
        }
    }
}