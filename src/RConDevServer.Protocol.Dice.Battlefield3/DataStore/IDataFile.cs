namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;

    public interface IDataFile
    {
        /// <summary>
        ///     name of the file incl. path
        /// </summary>
        string FileName { get; }

        /// <summary>
        ///     appends a line to the data file
        /// </summary>
        /// <param name="dataString">Datenzeile</param>
        void AppendLine(string dataString);

        /// <summary>
        ///     gets all lines from the datafile
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetAllLines();

        /// <summary>
        ///     Clears the data file
        /// </summary>
        void Clear();
    }
}