using System;
using System.Collections.Generic;
using System.Linq;
using RConDevServer.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class MapList : IUpdatable
    {
        private const int MaxNumListItems = 100;

        private readonly IList<MapListItem> items = new List<MapListItem>();
        private MapListItem currentItem;

        #region Public Properties

        public IList<MapListItem> Items { get { return this.items; } } 

        public int CurrentIndex { get; set; }

        public MapListItem CurrentItem
        {
            get { return this.currentItem; }
            set
            {
                this.currentItem = value;
                this.InvokeUpdated();
            }
        }

        public int NextIndex { get; set; }

        public int CurrentRound { get; set; }

        public int Count
        {
            get { return items.Count; }
        }

        #endregion

        #region Constructors

        public MapList()
        {
            this.CurrentIndex = 0;
            this.NextIndex = 0;
            this.CurrentRound = 1;
            this.CurrentItem = items.Count > 0 ? this.items[0] : null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an item to the MapList
        /// </summary>
        /// <param name="mapListItem"></param>
        public void Add(MapListItem mapListItem)
        {
            items.Add(mapListItem);
            InvokeUpdated();
        }

        /// <summary>
        /// Inserts an item at defined index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="mapListItem"></param>
        public void Insert(int index, MapListItem mapListItem)
        {
            items.Insert(index, mapListItem);
            InvokeUpdated();
        }

        /// <summary>
        /// Clears the map list
        /// </summary>
        public void Clear()
        {
            items.Clear();
            InvokeUpdated();
        }

        /// <summary>
        /// removes an item at the index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
            InvokeUpdated();
        }

        /// <summary> 
        /// Converts the whole maplist into words
        /// </summary>
        /// <returns></returns>
        public IList<string> ToWords(int startIndex = 0)
        {
            var itemsToList = items.Skip(startIndex).Take(MaxNumListItems).ToList();
            var words = new List<string>
                            {
                                Convert.ToString(itemsToList.Count),
                                Convert.ToString(MapListItem.PROPERTIES_COUNT)
                            };

            if (itemsToList.Count > 0)
            {
                foreach (var mapListItem in itemsToList)
                {
                    words.Add(mapListItem.Map.Code);
                    words.Add(mapListItem.Mode.Code);
                    words.Add(Convert.ToString(mapListItem.Rounds));
                }
            }

            return words;
        }

        public void NextMap()
        {
            this.CurrentIndex = (CurrentIndex + 1) >= items.Count ? 0 : CurrentIndex + 1;
            this.CurrentItem = this.items[CurrentIndex];
            this.CurrentRound = 1;
            this.InvokeUpdated();
        }

        public void NextRound()
        {
            if (CurrentRound == CurrentItem.Rounds)
            {
                // switch to the next map
                NextMap();
            }
            else
            {
                this.CurrentRound++;
            }
        }

        /// <summary>
        /// removes an existing <see cref="MapListItem"/> from the <see cref="MapList"/>
        /// </summary>
        /// <param name="item"></param>
        public void Remove(MapListItem item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                InvokeUpdated();
            }
        }

        #endregion

        public event EventHandler<EventArgs> Updated;

        private void InvokeUpdated()
        {
            if (this.Updated == null) return;
            Updated.InvokeAll(this, new EventArgs());
        }
    }
}