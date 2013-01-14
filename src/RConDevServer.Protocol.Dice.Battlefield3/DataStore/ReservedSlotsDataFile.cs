namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class ReservedSlotsDataFile : IReservedSlotsDataFile
    {
        public ReservedSlotsDataFile(IDataFile dataFile)
        {
            this.DataFile = dataFile;
        }

        public IDataFile DataFile { get; private set; }

        public void Add(ReservedSlot slot)
        {
            string dataString = slot.ToDataString();
            this.DataFile.AppendLine(dataString);
        }

        public IEnumerable<ReservedSlot> GetAll()
        {
            IEnumerable<string> lines = this.DataFile.GetAllLines();
            return lines.Select(ReservedSlot.FromDataString);
        }

        public void Clear()
        {
            this.DataFile.Clear();
        }
    }
}