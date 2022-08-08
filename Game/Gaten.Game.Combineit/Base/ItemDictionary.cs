using Gaten.Net.IO;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Gaten.Game.Combineit.Base
{
    public class ItemDictionary : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public static ObservableCollection<Item> Items { get; set; } = new();

        public ItemDictionary()
        {
            Load();
        }

        public void Load()
        {
            string itemDictionaryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\item.cd");

            string[]? data = GFile.ReadToArray(itemDictionaryPath);
            foreach (string? item in data)
            {
                AddItem(item);
            }
        }

        /// <summary>
        /// 아이템 사전에 아이템 추가
        /// 
        /// [ItemString Format]
        /// ID;이름;[재료1[이름|ID];재료1개수;재료2[이름|ID];재료2개수;...;|]제작시간(ms);[설명|-];제작개수
        /// </summary>
        /// <param name="itemString"></param>
        public void AddItem(string itemString)
        {
            string[] data = itemString.Split(';');

            int id = int.Parse(data[0]);
            string name = data[1];
            ObservableCollection<ItemSet>? materials = new();

            // 생산 아이템
            if (data.Length <= 5)
            {

            }
            // 제작 아이템
            else
            {
                for (int i = 2; i < data.Length - 3; i += 2)
                {
                    int itemCount;

                    // by Item ID
                    if (int.TryParse(data[i], out int itemId))
                    {
                        itemCount = int.Parse(data[i + 1]);
                        materials.Add(new ItemSet(GetItem(itemId), itemCount));
                    }
                    // by Item Name
                    else
                    {
                        string itemName = data[i];
                        itemCount = int.Parse(data[i + 1]);
                        materials.Add(new ItemSet(GetItem(itemName), itemCount));
                    }
                }
            }

            int combineTime = int.Parse(data[^3]);
            string comment = data[^2].Replace("\\n", Environment.NewLine);
            int bundle = int.Parse(data[^1]);

            Items.Add(new Item(
                id,
                name,
                materials,
                combineTime,
                comment,
                bundle
                ));

            Manual.MaterialDictionary.Add(id, materials.ToList());
        }

        public static Item GetItem(int id)
        {
            System.Collections.Generic.IEnumerable<Item>? item = Items.Where(i => i.Id.Equals(id));

            return item == null ? throw new Exception("GetItem Error.") : item.First();
        }

        public static Item GetItem(string name)
        {
            System.Collections.Generic.IEnumerable<Item>? item = Items.Where(i => i.Name.Equals(name));

            return item == null ? throw new Exception("GetItem Error.") : item.First();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
