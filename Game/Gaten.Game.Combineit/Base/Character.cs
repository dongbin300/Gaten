using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gaten.Game.Combineit.Base
{
    public class Character : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<PossessionItem> PossessionItems { get; set; }

        public Character()
        {
            PossessionItems = new ObservableCollection<PossessionItem>();
            Load();
        }

        void Load()
        {
            string characterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\user.ca");

            using FileStream stream = new FileStream(characterPath, FileMode.Open);
            using StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            reader.ReadLine();
            reader.ReadLine();

            try
            {
                while (true)
                {
                    // [Format] Id;개수
                    string possessionItemString = reader.ReadLine();
                    if (possessionItemString == null)
                    {
                        break;
                    }

                    string[] data = possessionItemString.Split(';');
                    int itemId = int.Parse(data[0]);
                    int itemCount = int.Parse(data[1]);

                    GetItem(itemId, itemCount);
                }
            }
            catch
            {

            }
        }

        public static void Save()
        {
            string characterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\user.ca");

            using FileStream stream = new FileStream(characterPath, FileMode.Open);
            using StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);

            writer.WriteLine("// Combineit Account 파일");
            writer.WriteLine();

            foreach(PossessionItem pi in PossessionItems)
            {
                writer.WriteLine($"{pi.Item.Id};{pi.Count}");
            }
        }

        public static void GetItem(Item item, int count = 1)
        {
            var match = PossessionItems.Where(i => i.Item.Equals(item)).ToList();

            if (match.Count == 0)
            {
                PossessionItems.Add(new PossessionItem(item, count));
            }
            else
            {
                match.First().Count += count;
            }
        }
            
        public static void GetItem(int itemId, int count = 1) => GetItem(ItemDictionary.GetItem(itemId), count);

        public static void GetItem(string itemName, int count = 1) => GetItem(ItemDictionary.GetItem(itemName), count);

        public static bool IsPossessItem(Item item)
        {
            var match = PossessionItems.Where(i => i.Item.Equals(item)).ToList();

            return match.Count == 0 ? false : true;
        }

        public static bool IsPossessItem(int itemId) => IsPossessItem(ItemDictionary.GetItem(itemId));

        public static bool IsPossessItem(string itemName) => IsPossessItem(ItemDictionary.GetItem(itemName));

        public static int GetPossessionItemCount(Item item)
        {
            var match = PossessionItems.Where(i => i.Item.Equals(item)).ToList();

            return match.Count == 0 ? 0 : match.First().Count;
        }

        public static int GetPossessionItemCount(int itemId) => GetPossessionItemCount(ItemDictionary.GetItem(itemId));

        public static int GetPossessionItemCount(string itemName) => GetPossessionItemCount(ItemDictionary.GetItem(itemName));

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
