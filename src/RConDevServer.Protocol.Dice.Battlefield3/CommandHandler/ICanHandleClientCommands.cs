namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System;
    using Command;
    using CommandFactory;
    using CommandResponse;
    using Common;

    /// <summary>
    ///     this interface describes an instance, which is able to react to commands
    /// </summary>
    public interface ICanHandleClientCommands<in TCommand> : IHandleClientCommands
        where TCommand : ICommand
    {
        /// <summary>
        /// </summary>
        /// <param name="session"></param>
        /// <param name="command"></param>
        /// <param name="requestPacket"></param>
        /// <param name="responsePacket"></param>
        [Obsolete("This is the old way of handling the commands. Use ProcessCommand() instead")]
        bool OnCreatingResponse(PacketSession session, TCommand command, Packet requestPacket, Packet responsePacket);

        /// <summary>
        /// Processes the <see cref="ICommand"/> the current handler is responsible for
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        ICommandResponse ProcessCommand(TCommand command, IPacketSession session);
    }
}