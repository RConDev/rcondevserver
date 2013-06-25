namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using System.Linq;
    using Command;
    using Command.BanList;
    using Common;

    public class BanListRemoveCommandHandler : CommandHandlerBase<BanListRemoveCommand>
    {
        public override string Command
        {
            get { return CommandNames.BanListRemove; }
        }

        public override bool OnCreatingResponse(PacketSession session, BanListRemoveCommand command, Packet requestPacket, Packet responsePacket)
        {
            
            if (this.ValidateRequest(requestPacket))
            {
                var idValue = requestPacket.Words[2];

                var banListItem =
                    session.Server.BanList.FirstOrDefault(x => x.IdType == command.IdType && x.IdValue == idValue);
                if (banListItem != null)
                {
                    session.Server.BanList.Remove(banListItem);
                    responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                }
                else
                {
                    responsePacket.Words.Add(Constants.RESPONSE_NOT_FOUND);
                }
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        protected bool ValidateRequest(Packet requestPacket)
        {
            // TODO: Validieren des Requests
            return true;
        }
    }
}