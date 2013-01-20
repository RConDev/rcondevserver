namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    /// <summary>
    ///     Returns the index of the map that is currently being played,
    ///     and the index of the next map to run.
    /// </summary>
    public class MapListGetMapIndicesCommand : SimpleCommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.MapListGetMapIndices; }
        }
    }
}