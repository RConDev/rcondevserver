namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    /// <summary>
    ///     Saves the map list to disk.
    /// </summary>
    public class MapListSaveCommand : SimpleCommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.MapListSave; }
        }
    }
}