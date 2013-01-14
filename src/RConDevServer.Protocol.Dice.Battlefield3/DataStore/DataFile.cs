namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    ///     A <see cref="DataFile" /> serves as a data store for several data items of a type.
    ///     The data store is persissted in a file
    /// </summary>
    public class DataFile : IDataFile
    {
        /// <summary>
        ///     creates a new <see cref="DataFile" /> instance
        /// </summary>
        /// <param name="fileName">filename</param>
        public DataFile(string fileName)
        {
            this.FileName = fileName;
        }

        /// <summary>
        ///     name of the file incl. path
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        ///     appends a line to the data file
        /// </summary>
        /// <param name="dataString">Datenzeile</param>
        public void AppendLine(string dataString)
        {
            using (var fileStream = new FileStream(this.FileName, FileMode.Append))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(dataString);
                }
            }
        }

        /// <summary>
        ///     gets all lines from the datafile
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllLines()
        {
            var lines = new List<string>();
            if (File.Exists(this.FileName))
            {
                using (var fileStream = new FileStream(this.FileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(fileStream))
                    {
                        while (!reader.EndOfStream)
                        {
                            lines.Add(reader.ReadLine());
                        }
                    }
                }
            }
            return lines.ToArray();
        }

        public void Clear()
        {
            if (File.Exists(this.FileName))
            {
                File.Delete(this.FileName);
            }
        }
    }
}