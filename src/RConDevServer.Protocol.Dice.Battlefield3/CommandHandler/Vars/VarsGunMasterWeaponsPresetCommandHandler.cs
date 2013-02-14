namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command;
    using Command.Vars;
    using Util;

    public class VarsGunMasterWeaponsPresetCommandHandler :
        VarsDefaultCommandHandler<VarsGunMasterWeaponsPresetCommand, int?>
    {
        /// <summary>
        ///     gets the string command for which the current
        ///     <see cref="T:RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ICanHandleClientCommands`1" />
        ///     implementation is responsible for
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsGunMasterWeaponsPreset; }
        }

        protected override int? ConvertToValue(string valueString)
        {
            return Int.SafeParse(valueString);
        }
    }
}