﻿namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     This list holds all maps available in Battlefield 3
    /// </summary>
    public class Maps : List<Map>
    {
        #region Constructor

        public Maps()
        {
        }

        public Maps(IEnumerable<Map> maps)
        {
            this.AddRange(maps);
        }

        #endregion

        #region Public Methods

        public Map FindByCode(string mapCode)
        {
            return this.FirstOrDefault(x => x.Code == mapCode);
        }

        #endregion
    }
}