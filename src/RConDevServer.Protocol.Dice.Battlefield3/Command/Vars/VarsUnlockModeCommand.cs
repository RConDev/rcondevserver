namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    using System.Collections.Generic;
    using Data;
    using Util;

    /// <summary>
    ///     Set which group of weapons/unlock should be available to players on an unranked server
    ///     Delay: Instantaneous, but if changed while players are on the server, strange things will happen
    /// </summary>
    public class VarsUnlockModeCommand : VarsCommandBase<UnlockMode?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsUnlockModeCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsUnlockModeCommand(UnlockMode? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsUnlockMode; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> ToWords()
        {
            var list = new List<string> {this.Command};
            if (this.Value == null)
            {
                return list;
            }

            string converted = UnlockModeConvert.ToString(this.Value.Value);
            list.Add(converted);
            return list;
        }
    }
}