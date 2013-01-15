namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System.Collections.Generic;
    using Common;

    public class CommandHandlersList : List<CommandHandlers>
    {
        public void OnCommandReceived(object sender, ClientCommandEventArgs args)
        {
            var session = sender as PacketSession;
            if (session == null
                || (session.Server == null 
                || !session.Server.IsAutomaticResponse))
            {
                return;
            }

            bool handled = false;
            foreach (var commandHandlers in this)
            {
                handled = commandHandlers.ProcessCommand(sender, args);
                if (handled)
                {
                    break;
                }
            }

            if (!handled)
            {
                this.HandleUnknownCommand(session, args.PacketData);
            }
        }

        #region Private Methods

        private void HandleUnknownCommand(PacketSession session, Packet packetData)
        {
            if (packetData.SequenceId == null || packetData.Words.Count <= 0)
            {
                return;
            }

            var responsePacket = new Packet(packetData.Origin, true, packetData.SequenceId.Value,
                                            new List<string>
                                                {
                                                    Constants.RESPONSE_UNKNOWN_COMMAND
                                                });
            session.SendToClient(responsePacket);
        }

        #endregion
    }
}