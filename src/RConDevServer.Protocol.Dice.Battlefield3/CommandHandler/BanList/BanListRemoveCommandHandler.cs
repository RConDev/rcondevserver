namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using System.Linq;
    using Command;
    using Common;
    using Data;

    public class BanListRemoveCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_BAN_LIST_REMOVE; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            IdTypes idTypes = session.Server.IdTypes;
            if (this.ValidateRequest(requestPacket))
            {
                IdType idType = idTypes.FirstOrDefault(x => x.Code == requestPacket.Words[1]);
                var idValue = requestPacket.Words[2];

                BanListItem banListItem =
                    session.Server.BanList.FirstOrDefault(x => x.IdType.Code == idType.Code && x.IdValue == idValue);
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