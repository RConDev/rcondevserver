namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System;
    using System.Linq;
    using Command;
    using Command.Admin;
    using CommandResponse;
    using Common;
    using Data;

    /// <summary>
    /// Implementation of <see cref="ICanHandleClientCommands{TCommand}"/> for <see cref="AdminMovePlayerCommand"/>
    /// </summary>
    public class AdminMovePlayerCommandHandler : CommandHandlerBase<AdminMovePlayerCommand>
    {
        public override string Command
        {
            get { return CommandNames.AdminMovePlayer; }
        }

        public override ICommandResponse ProcessCommand(AdminMovePlayerCommand command, IPacketSession session)
        {
            var players = session.Server.PlayerList.Players;
            if (players.Any(x => x.Name == command.SoldierName))
            {
                if (command.TeamId < 0 || command.TeamId > 2)
                {
                    return new InvalidTeamIdResponse();
                }
                return new OkResponse();
            }

            return new InvalidPlayerNameResponse();
        }

        public override bool OnCreatingResponse(PacketSession session, AdminMovePlayerCommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count != 5)
            {
                return this.ResponseInvalidArguments(responsePacket);
            }

            var playerName = requestPacket.Words[1];
            if (session.Server.PlayerList.Players.All(x => x.Name != playerName))
            {
                return this.ResponseInvalidPlayerName(responsePacket);
            }
            PlayerInfo player = session.Server.PlayerList.Players.FirstOrDefault(x => x.Name == playerName);

            var teamIdString = requestPacket.Words[2];
            int teamId;
            if (!Int32.TryParse(teamIdString, out teamId))
            {
                return this.ResponseInvalidTeamId(responsePacket);
            }

            var squadIdString = requestPacket.Words[3];
            int squadId;
            if (!Int32.TryParse(squadIdString, out squadId))
            {
                return this.ResponseInvalidSquadId(responsePacket);
            }

            player.TeamId = teamId;
            player.SquadId = squadId;

            return this.ResponseSuccess(responsePacket);
        }
    }
}