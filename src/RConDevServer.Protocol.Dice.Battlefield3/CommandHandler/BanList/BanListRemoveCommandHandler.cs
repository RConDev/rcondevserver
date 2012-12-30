using System.Linq;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    public class BanListRemoveCommandHandler : ICanHandleClientCommands
    {
        public string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_BAN_LIST_REMOVE; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            var idTypes = session.Server.IdTypes;
            if (ValidateRequest(requestPacket))
            {
                var idType = idTypes.FirstOrDefault(x => x.Code == requestPacket.Words[1]);
                var idValue = requestPacket.Words[2];

                var banListItem = session.Server.BanList.FirstOrDefault(x => x.IdType.Code == idType.Code && x.IdValue == idValue);
                if (banListItem != null)
                {
                    session.Server.BanList.Remove(banListItem);
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
                }
                else
                {
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_NOT_FOUND);
                }
            }
            else
            {
                responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_ARGUMENTS);
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
