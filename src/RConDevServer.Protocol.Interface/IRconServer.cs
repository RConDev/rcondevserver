using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Interface
{
    public interface IRconServer
    {
        event EventHandler<ClientEventArgs> ClientConnected;

        event EventHandler<EventArgs> Stopped;
        
        void Start();

        void Stop();
    }
}
