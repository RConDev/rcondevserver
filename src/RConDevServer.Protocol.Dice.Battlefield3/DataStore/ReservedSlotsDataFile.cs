using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public class ReservedSlotsDataFile : IReservedSlotsDataFile
    {
        public ReservedSlotsDataFile(IDataFile dataFile)
        {
            this.DataFile = dataFile;
        }

        public IDataFile DataFile { get; private set; }

        public void Add(ReservedSlot slot)
        {
            var dataString = slot.ToDataString();
            this.DataFile.AppendLine(dataString);
        }

        public IEnumerable<ReservedSlot> GetAll()
        {
            var lines = this.DataFile.GetAllLines();
            return lines.Select(ReservedSlot.FromDataString);
        }

        public void Clear()
        {
            this.DataFile.Clear();
        }
    }
}
