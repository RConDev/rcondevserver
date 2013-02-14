namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System.Collections.Generic;
    using Common;
    using log4net;

    public class CommandHandlersList : List<CommandHandlers>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (CommandHandlersList));
        private readonly CommandHandlers commandHandlers;

        public CommandHandlersList(CommandHandlers commandHandlers)
        {
            this.commandHandlers = commandHandlers;
        }

        public void OnCommandReceived(object sender, ClientCommandEventArgs args)
        {
            if (args.Command == null)
            {
                logger.InfoFormat("Command not recognized: {0}", args.PacketData.Words.DisplayWords());
            }

            var session = sender as PacketSession;
            if (session == null
                || (session.Server == null
                    || !session.Server.IsAutomaticResponse))
            {
                return;
            }

            var handled = this.commandHandlers.ProcessCommand(sender, args);
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