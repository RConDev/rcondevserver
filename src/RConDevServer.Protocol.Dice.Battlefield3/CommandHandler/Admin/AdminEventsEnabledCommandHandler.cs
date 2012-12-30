namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    public class AdminEventsEnabledCommandHandler : ICanHandleClientCommands
    {
        #region ICommandHandler Members

        public string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_ADMIN_EVENTS_ENABLED; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            // decide between get or set option
            if (requestPacket.Words.Count == 1)
            {
                // get option
                responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
                responsePacket.Words.Add(session.IsEventsEnabled.ToString().ToLower());
            }
            else if (requestPacket.Words.Count == 2)
            {
                // set option
                bool enabled = false;
                string enabledValue = requestPacket.Words[1];
                if (bool.TryParse(enabledValue, out enabled))
                {
                    session.IsEventsEnabled = enabled;
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
                    return true;
                }
                else
                {
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_ARGUMENTS);
                }
            }
            else
            {
                responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        #endregion
    }
}