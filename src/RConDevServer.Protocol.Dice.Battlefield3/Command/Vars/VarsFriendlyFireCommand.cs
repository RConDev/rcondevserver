namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if the server should allow team damage
    /// </summary>
    /// <remarks>
    ///     Works after round restart.
    ///     Not available during level load.
    /// </remarks>
    public class VarsFriendlyFireCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsFriendlyFireCommand" /> instance
        /// </summary>
        /// <param name="isFriendlyFire"></param>
        public VarsFriendlyFireCommand(bool? isFriendlyFire = null)
        {
            this.Value = isFriendlyFire;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsFriendlyFire; }
        }
    }
}