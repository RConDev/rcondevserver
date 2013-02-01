namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsGunMasterWeaponsPresetCommandTest : IntVarsCommandTestBase<VarsGunMasterWeaponsPresetCommand>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsGunMasterWeaponsPreset; }
        }
    }
}