namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using Command;
    using CommandFactory;
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
        bool OnCreatingResponse(PacketSession session, TCommand command, Packet requestPacket, Packet responsePacket);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        void ProcessCommand(TCommand command, PacketSession session);
    }
}