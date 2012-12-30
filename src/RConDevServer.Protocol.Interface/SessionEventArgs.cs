using System;

namespace RConDevServer.Protocol.Interface
{
    public class SessionEventArgs : EventArgs
    {
        public IRconSession IrConSession { get; private set; }

        public SessionEventArgs(IRconSession irConSession)
        {
            this.IrConSession = irConSession;
        }
    }
}