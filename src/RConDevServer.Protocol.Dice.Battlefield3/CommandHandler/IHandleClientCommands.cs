namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System.Collections.Generic;
    using Command;
    using Common;
    using Event;

    public interface IHandleClientCommands
    {
        IList<IEvent> CommandEvents { get; }

        /// <summary>
        ///     gets the string command for which the current 
        ///     <see cref="ICanHandleClientCommands{TCommand}" /> implementation
        ///     is responsible for
        /// </summary>
        string Command { get; }

        /// <summary>
        ///     Adds an <see cref="IEvent" /> to the CommandHandlers List,
        ///     that will be sent after having sent the response.
        /// </summary>
        /// <param name="anEvent">
        ///     the <see cref="IEvent" /> instance that will be added.
        /// </param>
        /// <returns></returns>
        void AddEvent(IEvent anEvent);

        bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket);
    }
}