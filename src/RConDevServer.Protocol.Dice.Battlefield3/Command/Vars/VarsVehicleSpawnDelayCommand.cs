namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set vehicle spawn delay scale factor, in percent
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsVehicleSpawnDelayCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsVehicleSpawnDelayCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsVehicleSpawnDelayCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsVehicleSpawnDelay; }
        }
    }
}