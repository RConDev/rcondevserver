namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System.Collections.Generic;
    using Command;
    using Common;
    using Event;
    using Interface;
    using Util;

    public abstract class CommandHandlerBase<TCommand> : ICanHandleClientCommands<TCommand>
        where TCommand : class, ICommand
    {
        protected CommandHandlerBase(IServiceLocator serviceLocator = null)
        {
            this.CommandEvents = new SynchronizedCollection<IEvent>();
            this.ServiceLocator = serviceLocator;
        }

        public IServiceLocator ServiceLocator { get; protected set; }

        public IList<IEvent> CommandEvents { get; private set; }

        public abstract string Command { get; }

        public abstract bool OnCreatingResponse(PacketSession session, TCommand command, Packet requestPacket,
                                                Packet responsePacket);

        /// <summary>
        /// </summary>
        /// <param name="session"></param>
        /// <param name="command"></param>
        /// <param name="requestPacket"></param>
        /// <param name="responsePacket"></param>
        public bool OnCreatingResponse(PacketSession session,
                                       ICommand command,
                                       Packet requestPacket,
                                       Packet responsePacket)
        {
            return this.OnCreatingResponse(session, (TCommand) command, requestPacket, responsePacket);
        }

        public virtual void AddEvent(IEvent anEvent)
        {
            if (anEvent != null)
            {
                this.CommandEvents.Add(anEvent);
            }
        }

        protected bool ResponseSuccess(Packet responsePacket)
        {
            responsePacket.Words.AddRange(new[] {Constants.RESPONSE_SUCCESS});
            return true;
        }

        protected bool ResponseInvalidArguments(Packet responsePacket)
        {
            responsePacket.Words.AddRange(new[] {Constants.RESPONSE_INVALID_ARGUMENTS});
            return true;
        }

        protected bool ResponseInvalidPlayerName(Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_INVALID_PLAYER_NAME);
            return true;
        }

        protected bool ResponseInvalidTeamId(Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_INVALID_TEAM_ID);
            return true;
        }

        protected bool ResponseInvalidSquadId(Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_INVALID_SQUAD_ID);
            return true;
        }
    }
}