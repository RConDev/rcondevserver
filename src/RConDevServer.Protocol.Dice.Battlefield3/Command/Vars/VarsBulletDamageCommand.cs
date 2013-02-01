namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set bullet damage scale factor, in percent
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsBulletDamageCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsBulletDamageCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsBulletDamageCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsBulletDamage; }
        }
    }
}