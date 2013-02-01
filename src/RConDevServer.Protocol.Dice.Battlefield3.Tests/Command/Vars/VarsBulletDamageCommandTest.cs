namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsBulletDamageCommandTest : IntVarsCommandTestBase<VarsBulletDamageCommand>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsBulletDamage; }
        }
    }
}