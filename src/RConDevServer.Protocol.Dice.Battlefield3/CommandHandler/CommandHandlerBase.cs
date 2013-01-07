using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Event;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using Util;

    public abstract class CommandHandlerBase : ICanHandleClientCommands
    {
        public IList<IEvent> CommandEvents { get; private set; }

        public abstract string Command { get; }

        protected CommandHandlerBase()
        {
            this.CommandEvents = new SynchronizedCollection<IEvent>();
        }

        public abstract bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket);

        public virtual void AddEvent(IEvent anEvent)
        {
            if (anEvent != null)
            {
                CommandEvents.Add(anEvent);
            }
        }

        protected bool ResponseSuccess(Packet responsePacket)
        {
            responsePacket.Words.AddRange(new[] { Constants.RESPONSE_SUCCESS });
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