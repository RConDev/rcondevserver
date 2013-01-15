namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System;
    using System.Collections.Generic;
    using Command;
    using Common;
    using log4net;

    public class CommandHandlers
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (CommandHandlers));

        protected readonly IDictionary<string, ICanHandleClientCommands> CommandReveiverAccess;

        #region Constructor

        public CommandHandlers()
        {
            this.CommandReveiverAccess = new Dictionary<string, ICanHandleClientCommands>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Adds a new <see cref="ICanHandleClientCommands" /> instance to the handler list
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>true if it was successfully added, false if it is already registered</returns>
        public bool RegisterCommandHandler(ICanHandleClientCommands handler)
        {
            string commandName = handler.Command.ToLower();
            bool isAlreadyRegistered = this.CommandReveiverAccess.ContainsKey(commandName);
            if (!isAlreadyRegistered)
            {
                this.CommandReveiverAccess.Add(commandName, handler);
                return true;
            }
            return false;
        }

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
                if (this.CommandReveiverAccess.ContainsKey(currentCommand.ToLower()))
                {
                    ICanHandleClientCommands commandHandler = this.CommandReveiverAccess[currentCommand.ToLower()];
                    var responsePacket = new Packet(requestPacket.Origin,
                                                    true,
                                                    requestPacket.SequenceId.Value);

                    bool responseCreated = false;
                    try
                    {
                        responseCreated = commandHandler.OnCreatingResponse(session, requestPacket, responsePacket,
                                                                            args.Command);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed to create command response", ex);
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
    }
}