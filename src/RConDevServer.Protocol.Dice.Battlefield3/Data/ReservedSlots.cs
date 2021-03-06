﻿namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RConDevServer.Util;

    /// <summary>
    ///     the player names, for whom reserved slots exist
    /// </summary>
    public class ReservedSlots : List<ReservedSlot>, IUpdatable
    {
        private readonly object syncRoot = new object();
        private bool isAggressiveJoin;

        #region Public Properties

        public bool IsAggressiveJoin
        {
            get { return this.isAggressiveJoin; }
            set
            {
                this.isAggressiveJoin = value;
                this.InvokeUpdated();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Adds a player's name to the list for reserved slots
        /// </summary>
        /// <param name="playerName"></param>
        public void Add(string playerName)
        {
            lock (this.syncRoot)
            {
                this.Add(new ReservedSlot {PlayerName = playerName});
                this.InvokeUpdated();
            }
        }

        /// <summary>
        ///     Removes a players name to the list of reserved slots
        /// </summary>
        /// <param name="playerName"></param>
        public void Remove(string playerName)
        {
            lock (this.syncRoot)
            {
                if (this.Any(x => x.PlayerName == playerName))
                {
                    ReservedSlot item = this.FirstOrDefault(x => x.PlayerName == playerName);
                    this.Remove(item);
                    this.InvokeUpdated();
                }
            }
        }

        /// <summary>
        ///     Clears the collection of reserved slots
        /// </summary>
        public new void Clear()
        {
            lock (this.syncRoot)
            {
                base.Clear();
                this.InvokeUpdated();
            }
        }

        public IEnumerable<string> ToWords(int offset = 0)
        {
            return this.Skip(offset).Take(100).Select(playerName => playerName.PlayerName).ToArray();
        }

        #endregion

        public event EventHandler<EventArgs> Updated;

        internal void InvokeUpdated()
        {
            if (this.Updated == null)
            {
                return;
            }
            this.Updated.InvokeAll(this, new EventArgs());
        }
    }
}