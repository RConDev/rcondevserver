namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set what weapons preset to use when playing the gun master game mode, 0=normal, 1=?...
    ///     Delay: Works after map switch
    /// </summary>
    public class VarsGunMasterWeaponsPresetCommand : VarsCommandBase<int?>
    {
        public VarsGunMasterWeaponsPresetCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsGunMasterWeaponsPreset; }
        }
    }
}