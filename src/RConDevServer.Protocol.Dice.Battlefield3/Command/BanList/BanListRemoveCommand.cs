﻿namespace RConDevServer.Protocol.Dice.Battlefield3.Command.BanList
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    ///     Remove name/ip/guid from banlist
    /// </summary>
    public class BanListRemoveCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="BanListRemoveCommand" /> instance
        /// </summary>
        /// <param name="idType"></param>
        /// <param name="id"></param>
        public BanListRemoveCommand(IdType idType, string id)
        {
            this.IdType = idType;
            this.Id = id;
        }

        /// <summary>
        ///     the type of id to identify the banned player
        /// </summary>
        public IdType IdType { get; private set; }

        /// <summary>
        ///     the player's identifier
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.BanListRemove; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command, this.IdType.ToWord(), this.Id};
        }
    }
}