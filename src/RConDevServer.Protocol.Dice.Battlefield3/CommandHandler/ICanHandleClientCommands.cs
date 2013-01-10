using System;
using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Event;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using Command;
    using CommandFactory;

    /// <summary>
    /// this interface describes an instance, which is able to react to commands
    /// </summary>
    public interface ICanHandleClientCommands
    {
        IList<IEvent> CommandEvents { get; }

        /// <summary>
        /// gets the string command for which the current <see cref="ICanHandleClientCommands"/> implementation 
        /// is responsible for
        /// </summary>
        string Command { get; }

        /// <summary>
        /// the <see cref="ICommandFactory{TCommand}"/> to create the <see cref="ICommand"/> instances for the 
        /// current <see cref="ICanHandleClientCommands"/> implementation
        /// </summary>
        ICommandFactory<ICommand> CommandFactory { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestPacket"></param>
        /// <param name="responsePacket"></param>
        /// <param name="command"></param>
        bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket, ICommand command);

        /// <summary>
        /// Adds an <see cref="IEvent"/> to the CommandHandlers List, 
        /// that will be sent after having sent the response.
        /// </summary>
        /// <param name="anEvent">the <see cref="IEvent"/> instance that will be added.</param>
        /// <returns></returns>
        void AddEvent(IEvent anEvent);
    }
}