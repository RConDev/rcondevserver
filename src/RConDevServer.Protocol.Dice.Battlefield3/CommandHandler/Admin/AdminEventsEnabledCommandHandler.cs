namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using Common;

    public class AdminEventsEnabledCommandHandler : CommandHandlerBase
    {
        #region ICommandHandler Members

        public override string Command
        {
            get { return CommandNames.AdminEventsEnabled; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            // decide between get or set option
            if (requestPacket.Words.Count == 1)
            {
                // get option
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
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
                    responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                    return true;
                }
                else
                {
                    responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                }
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        #endregion
    }
}