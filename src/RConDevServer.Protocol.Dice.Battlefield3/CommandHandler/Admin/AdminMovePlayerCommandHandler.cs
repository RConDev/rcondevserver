namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Linq;
    using Command;
    using Command.Admin;
    using CommandResponse;

    /// <summary>
    /// Implementation of <see cref="ICanHandleClientCommands{TCommand}"/> for <see cref="AdminMovePlayerCommand"/>
    /// </summary>
    public class AdminMovePlayerCommandHandler : CommandHandlerBase<AdminMovePlayerCommand>
    {
        /// <summary>
        ///     gets the string command for which the current 
        ///     <see cref="ICanHandleClientCommands{TCommand}" /> implementation
        ///     is responsible for
        /// </summary>
        public override string Command
        {
            get { return CommandNames.AdminMovePlayer; }
        }

        /// <summary>
        /// Processes the <see cref="ICommand"/> the current handler is responsible for
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        public override ICommandResponse ProcessCommand(AdminMovePlayerCommand command, IPacketSession session)
        {
            var players = session.Server.PlayerList.Players;
            if (players.Any(x => x.Name == command.SoldierName))
            {
                if (command.TeamId < 0 || command.TeamId > 2)
                {
                    return new InvalidTeamIdResponse();
                }

                if (command.SquadId < 0 || command.SquadId > 32)
                {
                    return new InvalidSquadIdResponse();
                }

                var currentPlayer = players.FirstOrDefault(x => x.Name == command.SoldierName);
                if (currentPlayer != null)
                {
                    currentPlayer.TeamId = command.TeamId;
                    currentPlayer.SquadId = command.SquadId;
                }

                return new OkResponse();
            }

            return new InvalidPlayerNameResponse();
        }
    }
}