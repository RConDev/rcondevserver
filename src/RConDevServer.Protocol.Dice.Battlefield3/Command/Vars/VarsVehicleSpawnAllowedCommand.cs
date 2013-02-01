namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set whether vehicles should spawn in-game
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsVehicleSpawnAllowedCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsVehicleSpawnAllowedCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsVehicleSpawnAllowedCommand(bool? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsVehicleSpawnAllowed; }
        }
    }
}