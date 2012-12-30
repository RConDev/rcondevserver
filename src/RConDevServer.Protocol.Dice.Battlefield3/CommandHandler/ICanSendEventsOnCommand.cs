using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    /// <summary>
    /// Interface for sending <see cref=""/> Events on a Command executed
    /// </summary>
    public interface ICanSendEventsOnCommand
    {
        /// <summary>
        /// In this method events can be send to the client via the <paramref name="session"/>
        /// </summary>
        /// <param name="session"></param>
        void OnSendingEvents (PacketSession session);
    }
}
