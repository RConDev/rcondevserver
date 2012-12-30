using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public interface IReservedSlotsDataFile
    {
        IDataFile DataFile { get; }

        void Add(ReservedSlot slot);

        IEnumerable<ReservedSlot> GetAll();

        void Clear();
    }
}