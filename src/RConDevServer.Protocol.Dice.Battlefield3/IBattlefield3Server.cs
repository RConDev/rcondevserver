namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using System;
    using System.Collections.Generic;
    using Data;
    using DataStore;
    using Event;
    using Interface;

    /// <summary>
    /// This interface describes the Battlefield 3 server instance
    /// </summary>
    public interface IBattlefield3Server
    {
        IPlayerList PlayerList { get; }
        IServiceLocator ServiceLocator { get; set; }
        Battlefield3Protocol Battlefield3Protocol { get; set; }
        IReservedSlotsDataFile ReservedSlotsStore { get; }
        IMapListDataFile MapListStore { get; }
        IList<PacketSession> PacketSessions { get; }

        /// <summary>
        ///     the rcon password for the server
        /// </summary>
        string Password { get; set; }

        /// <summary>
        ///     the data for serverInfo Command
        /// </summary>
        ServerInfo ServerInfo { get; set; }

        /// <summary>
        ///     gets or sets the value for active automatic responses to client commands
        /// </summary>
        bool IsAutomaticResponse { get; set; }

        string ServerDescription { get; set; }
        MapList MapList { get; }
        IBanList BanList { get; }
        Vars Vars { get; }
        MapListItem CurrentMapListItem { get; }
        ReservedSlots ReservedSlots { get; }
        TeamScores TeamScores { get; }
        Maps AvailableMaps { get; }
        GameModes AvailableModes { get; }
        BanTypes BanTypes { get; }
        IList<Country> Countries { get; }
        int EffectiveMaxPlayerCount { get; set; }

        event EventHandler<PacketSessionEventArgs> ClientConnected;
        event EventHandler Stopped;
        void Initialize();
        void PublishEvents(IEnumerable<IEvent> events);
        void PublishEvent(IEvent anEvent);
        void OnClientConnected(object sender, ClientEventArgs e);
        void OnStopped(object sender, EventArgs e);
    }
}