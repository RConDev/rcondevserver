namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsOnlySquadLeaderSpawnCommandTest : VarsCommandTestBase<VarsOnlySquadLeaderSpawnCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsOnlySquadLeaderSpawn; }
        }

        public override VarsOnlySquadLeaderSpawnCommand CreateCommandWithValue()
        {
            return new VarsOnlySquadLeaderSpawnCommand(true);
        }

        public override VarsOnlySquadLeaderSpawnCommand CreateCommandWithoutValue()
        {
            return new VarsOnlySquadLeaderSpawnCommand();
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