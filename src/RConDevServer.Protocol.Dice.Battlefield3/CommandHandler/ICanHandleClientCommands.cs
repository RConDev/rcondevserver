﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System.Collections.Generic;
    using Command;
    using CommandFactory;
    using Common;
    using Event;

    /// <summary>
    ///     this interface describes an instance, which is able to react to commands
    /// </summary>
    public interface ICanHandleClientCommands
    {
        IList<IEvent> CommandEvents { get; }

        /// <summary>
        ///     gets the string command for which the current <see cref="ICanHandleClientCommands" /> implementation
        ///     is responsible for
        /// </summary>
        string Command { get; }

        /// <summary>
        /// </summary>
        /// <param name="session"></param>
        /// <param name="command"></param>
        /// <param name="requestPacket"></param>
        /// <param name="responsePacket"></param>
        bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket);

        /// <summary>
        ///     Adds an <see cref="IEvent" /> to the CommandHandlers List,
        ///     that will be sent after having sent the response.
        /// </summary>
        /// <param name="anEvent">
        ///     the <see cref="IEvent" /> instance that will be added.
        /// </param>
        /// <returns></returns>
        void AddEvent(IEvent anEvent);
    }
}