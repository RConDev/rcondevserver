namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Linq;
    using Command;
    using Command.Admin;
    using CommandFactory;
    using Interface;

    public class AdminKickPlayerCommandHandler : CommandHandlerBase
    {
        public AdminKickPlayerCommandHandler(IServiceLocator serviceLocator) : base(serviceLocator)
        {
            this.CommandFactory = this.ServiceLocator.GetService<ICommandFactory<ICommand>>(this.Command);
        }

        public override string Command
        {
            get { return CommandNames.AdminKickPlayer; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count > 3)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }
            
            var command = this.CommandFactory.FromWords(requestPacket.Words) as KickPlayerCommand;
            var playerList = session.Server.PlayerList.Players;
            if (playerList.All(x => x.Name != command.SoldierName))
            {
                responsePacket.Words.Add(Constants.RESPONSE_PLAYER_NOT_FOUND);
                return true;
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}