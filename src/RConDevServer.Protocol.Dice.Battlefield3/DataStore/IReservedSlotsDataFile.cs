namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;

    public interface IReservedSlotsDataFile
    {
        IDataFile DataFile { get; }

        void Add(ReservedSlot slot);

        IEnumerable<ReservedSlot> GetAll();

        void Clear();
    }
}