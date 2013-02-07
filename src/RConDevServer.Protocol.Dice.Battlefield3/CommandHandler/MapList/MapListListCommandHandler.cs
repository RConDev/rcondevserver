namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;
    using Command.MapList;
    using Common;
    using Util;

    public class MapListListCommandHandler : CommandHandlerBase<MapListListCommand>
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_LIST; }
        }

        public override bool OnCreatingResponse(PacketSession session, MapListListCommand command, Packet requestPacket, Packet responsePacket)
        {
            int startIndex = 0;
            if (requestPacket.Words.Count == 2)
            {
                if (!int.TryParse(requestPacket.Words[1], out startIndex))
                {
                    responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                    return true;
                }
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            StringListExtensions.AddRange(responsePacket.Words, session.Server.MapList.ToWords(startIndex));
            return true;
        }

        #endregion
    }
}