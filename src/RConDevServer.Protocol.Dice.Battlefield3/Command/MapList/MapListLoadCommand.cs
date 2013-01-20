namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    /// <summary>
    ///     Clears the map list and loads it from disk again.
    /// </summary>
    /// <remarks>
    ///     If loading fails, the map list will be in an undefined state.
    /// </remarks>
    public class MapListLoadCommand : SimpleCommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.MapListLoad; }
        }
    }
}