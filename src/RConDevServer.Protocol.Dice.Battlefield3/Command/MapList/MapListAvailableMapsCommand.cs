namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    using System;

    /// <summary>
    ///     Currently broken!
    /// </summary>
    [Obsolete("Currently broken!")]
    public class MapListAvailableMapsCommand : SimpleCommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.MapListAvailableMaps; }
        }
    }
}