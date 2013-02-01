namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsVehicleSpawnAllowedCommandTest : VarsCommandTestBase<VarsVehicleSpawnAllowedCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsVehicleSpawnAllowed; }
        }

        public override VarsVehicleSpawnAllowedCommand CreateCommandWithValue()
        {
            return new VarsVehicleSpawnAllowedCommand(true);
        }

        public override VarsVehicleSpawnAllowedCommand CreateCommandWithoutValue()
        {
            return new VarsVehicleSpawnAllowedCommand();
        }

        public override bool? GetValue()
        {
            return true;
        }

        public override string GetStringValue()
        {
            return "true";
        }
    }
}