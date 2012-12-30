namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    /// <summary>
    /// this interface describes an instance, which is able to react to commands
    /// </summary>
    public interface ICanHandleClientCommands
    {
        /// <summary>
        /// gets the string command for which the current <see cref="ICanHandleClientCommands"/> implementation 
        /// is responsible for
        /// </summary>
        string Command { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestPacket"></param>
        /// <param name="responsePacket"></param>
        bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket);
    }
}