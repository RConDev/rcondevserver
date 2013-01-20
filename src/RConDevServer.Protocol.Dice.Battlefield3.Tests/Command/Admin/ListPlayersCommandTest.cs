namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using Battlefield3.Data;
    using NUnit.Framework;

    [TestFixture]
    public class ListPlayersCommandTest
    {
        [Test]
        public void Ctor_WithSubsetAll_ReturnsInstance()
        {
            var command = new ListPlayersCommand(new PlayerSubset(PlayerSubsetType.All));
            Assert.IsNotNull(command);
            Assert.AreEqual(CommandNames.AdminListPlayers, command.Command);
            Assert.AreEqual(PlayerSubsetType.All, command.PlayerSubset.Type);
            Assert.IsNull(command.PlayerSubset.TeamId);
            Assert.IsNull(command.PlayerSubset.SquadId);
            Assert.IsNull(command.PlayerSubset.PlayerName);
        }

        [Test]
        public void Ctor_WithSubsetPlayerName_ReturnsInstance()
        {
            var command = new ListPlayersCommand(new PlayerSubset(PlayerSubsetType.Player, playerName: "a_Player_Name"));
            Assert.IsNotNull(command);
            Assert.AreEqual(CommandNames.AdminListPlayers, command.Command);
            Assert.AreEqual(PlayerSubsetType.Player, command.PlayerSubset.Type);
            Assert.IsNull(command.PlayerSubset.TeamId);
            Assert.IsNull(command.PlayerSubset.SquadId);
            Assert.AreEqual("a_Player_Name", command.PlayerSubset.PlayerName);
        }

        [Test]
        public void Ctor_WithSubsetTeamId_ReturnsInstance()
        {
            var command = new ListPlayersCommand(new PlayerSubset(PlayerSubsetType.Team, teamId: 1));
            Assert.IsNotNull(command);
            Assert.AreEqual(CommandNames.AdminListPlayers, command.Command);
            Assert.AreEqual(PlayerSubsetType.Team, command.PlayerSubset.Type);
            Assert.AreEqual(1, command.PlayerSubset.TeamId);
            Assert.IsNull(command.PlayerSubset.SquadId);
            Assert.IsNull(command.PlayerSubset.PlayerName);
        }

    }
}