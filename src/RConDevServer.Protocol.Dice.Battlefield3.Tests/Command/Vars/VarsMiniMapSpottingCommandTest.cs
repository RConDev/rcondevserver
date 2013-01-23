namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsMiniMapSpottingCommandTest : VarsCommandTestBase<VarsMiniMapSpottingCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsMiniMapSpotting; }
        }

        public override VarsMiniMapSpottingCommand CreateCommandWithValue()
        {
            return new VarsMiniMapSpottingCommand(true);
        }

        public override VarsMiniMapSpottingCommand CreateCommandWithoutValue()
        {
            return new VarsMiniMapSpottingCommand();
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