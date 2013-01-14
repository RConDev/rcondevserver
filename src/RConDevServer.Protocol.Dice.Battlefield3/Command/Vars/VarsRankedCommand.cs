namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Change the server between ranked/unranked mode
    /// </summary>
    /// <remarks>
    ///     This command can only be used during startup.
    ///     It can only be used to switch the server from ranked to unranked mode;
    ///     the server can never switch back to ranked mode again.
    /// </remarks>
    public class VarsRankedCommand : VarsCommandBase<bool>
    {
        /// <summary>
        ///     create a new <see cref="VarsRankedCommand" /> instance
        /// </summary>
        /// <param name="isRanked"></param>
        public VarsRankedCommand(bool? isRanked = null)
        {
            this.Value = isRanked;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsRanked; }
        }
    }
}