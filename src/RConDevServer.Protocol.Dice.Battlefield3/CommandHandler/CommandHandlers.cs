namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System;
    using CommandResponse;
    using Common;
    using Interface;
    using log4net;

    public class CommandHandlers
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (CommandHandlers));

        #region Constructor

        public CommandHandlers(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        #endregion

        #region Public Methods

        public bool ProcessCommand(object sender, ClientCommandEventArgs args)
        {
            var session = sender as PacketSession;

            // exit if session is not correctly initialized
            if (session == null || session.Server == null)
            {
                return false;
            }

            // exit if no automatic response is requested
            if (!session.Server.IsAutomaticResponse)
            {
                return false;
            }

            // process registered handlers
            Packet requestPacket = args.PacketData;

            if (requestPacket == null)
            {
                throw new ArgumentNullException("requestPacket");
            }

            if (requestPacket.SequenceId != null && requestPacket.Words.Count > 0)
            {
                string currentCommand = requestPacket.Words[0];

                var commandHandler = this.ServiceLocator.GetService<IHandleClientCommands>(currentCommand);
                if (commandHandler != null)
                {
                    var responsePacket = new Packet(requestPacket.Origin,
                                                    true,
                                                    requestPacket.SequenceId.Value);

                    bool responseCreated = false;
                    if (args.IsFaulted)
                    {
                        responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                        responseCreated = true;
                    }

                    if (!responseCreated)
                    {
                        try
                        {
                            responseCreated = commandHandler.OnCreatingResponse(session, args.Command, requestPacket,
                                                                                responsePacket);
                        }
                        catch (Exception ex)
                        {
                            logger.Error("Failed to create command response", ex);
                        }
                    }

                    if (responseCreated)
                    {
                        session.SendToClient(responsePacket);
                        if (commandHandler.CommandEvents.Count > 0)
                        {
                            session.Server.PublishEvents(commandHandler.CommandEvents);
                            commandHandler.CommandEvents.Clear();
                        }
                        return true;
                    }
                }

                return false;
            }
            return false;
        }

        #endregion

        public IServiceLocator ServiceLocator { get; private set; }
    }
}