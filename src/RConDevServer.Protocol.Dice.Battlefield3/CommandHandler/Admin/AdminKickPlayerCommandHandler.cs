namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using CommandResponse;
    using Data;
    using Interface;

    /// <summary>
    /// Implementation of <see cref="ICanHandleClientCommands{TCommand}"/> for <see cref="AdminKickPlayerCommand"/>
    /// </summary>
    public class AdminKickPlayerCommandHandler : CommandHandlerBase<AdminKickPlayerCommand>
    {
        /// <summary>
        /// creates a new <see cref="AdminKickPlayerCommandHandler"/> instance
        /// </summary>
        /// <param name="serviceLocator"></param>
        public AdminKickPlayerCommandHandler(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        /// <summary>
        ///     gets the string command for which the current 
        ///     <see cref="ICanHandleClientCommands{TCommand}" /> implementation
        ///     is responsible for
        /// </summary>
        public override string Command
        {
            get { return CommandNames.AdminKickPlayer; }
        }

        /// <summary>
        /// Processes the <see cref="ICommand"/> the current handler is responsible for
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        public override ICommandResponse ProcessCommand(AdminKickPlayerCommand command,
                                                        IPacketSession session)
        {
            IList<PlayerInfo> players = session.Server.PlayerList.Players;
            if (players.All(x => x.Name != command.SoldierName))
            {
                return new PlayerNotFoundResponse();
            }

            return new OkResponse();
        }
    }
}