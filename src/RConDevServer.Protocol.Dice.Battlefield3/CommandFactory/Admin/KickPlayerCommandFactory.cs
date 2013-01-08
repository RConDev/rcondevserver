using System.Collections.Generic;
using System.Linq;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using Command;
    using Command.Admin;
    using Util;

    public class KickPlayerCommandFactory : CommandFactoryBase<KickPlayerCommand>
    {
        public override KickPlayerCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            ////Requires.Equal(words[0], CommandNames.AdminKickPlayer, "commandWords[0]");
            ////Requires.Equal(words.Length, 3, "commandWords.Length");
            return new KickPlayerCommand(words[1], words[2]);
        }

        public override KickPlayerCommand Parse(string commandString)
        {
            Requires.NotNullOrEmpty(commandString, "commandString");
            return null;
        }
    }
}
