namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set desired maximum number of players
    /// </summary>
    /// <remarks>
    ///     The effective maximum number of players is also effected by the server provider,
    ///     and the game engine. If the desired maximum number of players is set to something
    ///     that is accepted by the server, the effective maximum number of players will usually
    ///     change within a second. If the value is currently not accepted, then the server will
    ///     continue to check every 10 seconds and change the effective count whenever the game
    ///     engine allows it.
    /// </remarks>
    public class VarsMaxPlayersCommand : VarsCommandBase<int?>
    {
        /// <summary>
        /// creates a new <see cref="VarsMaxPlayersCommand"/> instance
        /// </summary>
        /// <param name="maxPlayers"></param>
        public VarsMaxPlayersCommand(int? maxPlayers = null)
        {
            this.Value = maxPlayers;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsMaxPlayers; }
        }
    }
}