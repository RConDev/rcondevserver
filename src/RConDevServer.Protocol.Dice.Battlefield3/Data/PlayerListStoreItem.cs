﻿namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class PlayerListStoreItem
    {
        public virtual long Id { get; set; }

        public virtual string Label { get; set; }

        public virtual byte[] Store { get; set; }
    }
}