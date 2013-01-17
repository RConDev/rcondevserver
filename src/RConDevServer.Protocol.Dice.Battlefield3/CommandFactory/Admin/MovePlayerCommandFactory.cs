using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using Command;
    using Command.Admin;
    using Util;

    /// <summary>
    /// implementation of <see cref="ICommandFactory{TCommand}"/> for <see cref="MovePlayerCommand"/>
    /// </summary>
    public class MovePlayerCommandFactory : CommandFactoryBase<MovePlayerCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MovePlayerCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            Requires.SequenceLength(words, 5, "words");
            Requires.Equal(words[0], CommandNames.AdminMovePlayer, "commandName");

            var soldierName = words[1];
            Requires.NotNullOrEmpty(soldierName, "soldierName");

            var teamId = Int.SafeParse(words[2]);
            Requires.NotNull(teamId, "teamId");

            var squadId = Int.SafeParse(words[3]);
            Requires.NotNull(squadId, "squadId");

            var force = Bool.SafeParse(words[4]);
            Requires.NotNull(force, "force");

            return new MovePlayerCommand(soldierName, teamId.Value, squadId.Value, force.Value);
        }
    }
}
