using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using DataStore;

    public class PlayersViewModel : ViewModelBase
    {
        private readonly DataContractSerializer serializer = new DataContractSerializer(typeof(IEnumerable<Player>));

        private readonly PlayerList players;

        private readonly Battlefield3Server server;

        #region Constructor

        public PlayersViewModel(Battlefield3Server server, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            this.server = server;
            this.players = server.PlayerList;


            this.InitializePlayers(this.players.Players);
            this.NewPlayer = new Player();

            Initialize();
        }

        private void InitializePlayers (IEnumerable<Player> playersList)
        {
            if (this.Players != null)
            {
                this.Players.CollectionChanged -= this.PlayersOnCollectionChanged;
            }
            this.Players = new ObservableCollection<Player>(playersList);
            this.Players.CollectionChanged += this.PlayersOnCollectionChanged;
            this.InvokePropertyChanged(null);
        }

        #endregion

        public ObservableCollection<PlayerListStoreItem> PlayerListStore { get; private set; } 

        public ObservableCollection<Player> Players { get; private set; }

        public Player NewPlayer { get; set; }

        #region Public Methods

        public void Initialize()
        {
            var playerListRepository = server.ServiceLocator.GetService<IPlayerListStoreRepository>();
            var playerListStore = playerListRepository.GetAll();

            this.PlayerListStore = new ObservableCollection<PlayerListStoreItem>(playerListStore);
            this.InvokePropertyChanged("PlayerListStore");
        }

        public void SavePlayerList(string listName, bool overrideExisting)
        {
            var playerListRepository = server.ServiceLocator.GetService<IPlayerListStoreRepository>();

            PlayerListStoreItem existingItem = null;
            if (this.PlayerListStore.Any(x => x.Label == listName))
            {
                if (!overrideExisting) return;

                existingItem = this.PlayerListStore.FirstOrDefault(x => x.Label == listName);
            }

            byte[] bytes = null;
            using (var memoryStream = new MemoryStream())
            {
                serializer.WriteObject(memoryStream, this.Players);
                bytes = memoryStream.ToArray();
            }

            if (bytes != null)
            {
                existingItem = existingItem ?? new PlayerListStoreItem()
                                                   {
                                                       Label = listName,
                                                  };
                existingItem.Store = bytes;

                playerListRepository.Save(existingItem);
            }
        }

        public void LoadPlayerList(long playerListStoreId)
        {
            var playerStore = this.server.ServiceLocator.GetService<IPlayerListStoreRepository>();
            var item = playerStore.Get(playerListStoreId);

            LoadPlayerList(item);
        }

        public void LoadPlayerList(PlayerListStoreItem storeItem)
        {
            using (var memoryStream = new MemoryStream(storeItem.Store))
            {
                var players = serializer.ReadObject(memoryStream) as IEnumerable<Player>;
                if (players != null)
                {
                    this.players.Clear();
                    foreach (var player in players)
                    {
                        this.players.AddPlayer(player);
                    }
                    this.InitializePlayers(this.players.Players);
                }
            }
        }

        #endregion

        #region Event Handler

        private void PlayersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Player item in args.NewItems)
                    {
                        players.AddPlayer(item);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Player item in args.OldItems)
                    {
                        if (players.Players.Contains(item))
                        {
                            players.RemovePlayer(item);
                        }
                    }
                    break;
            }
            this.InvokePropertyChanged("Players");
        }

        #endregion
    }
}
