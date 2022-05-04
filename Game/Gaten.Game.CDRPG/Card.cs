using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Game.CDRPG
{
    public class Card
    {
        public enum Types { Character, Weapon }
        public enum Properties { None, Water, Fire, Light, Dark, Electricity }
        public enum Species { Human, Machine, Reptile, Monster, Food }
        public enum Tiers { Bronze, Silver, Gold, Rainbow }

        int no;
        string code;
        string name;
        int turn;
        public int power;
        public readonly string rangeString = "abcdefghijklmnopqrstuvwxy";
        public string range;
        public Types type;
        Properties property;
        Species species;
        Tiers tier;
        string effect;

        List<Card> cards = new List<Card>();

        public Card()
        {

        }
        public Card(int no, string code, string name, int turn, int power, string range, Types type, Properties property, Species species, Tiers tier, string effect)
        {
            this.no = no;
            this.code = code;
            this.name = name;
            this.turn = turn;
            this.power = power;
            this.range = range;
            this.type = type;
            this.property = property;
            this.species = species;
            this.tier = tier;
            this.effect = effect;
        }

        public void AddCard()
        {
            /*
     * abcde
     * fghij
     * klmno
     * pqrst
     * uvwxy
     * 
     * m은 필수적으로 포함됨
     */
            cards.Add(new Card(1, "CC0010001", "인간", 3, 300, "ln", Types.Character, Properties.None, Species.Human, Tiers.Bronze, ""));
            cards.Add(new Card(2, "CC0010002", "괴물", 2, 200, "hr", Types.Character, Properties.None, Species.Monster, Tiers.Bronze, ""));
            cards.Add(new Card(3, "CC0010003", "젤리", 5, 150, "", Types.Character, Properties.Water, Species.Food, Tiers.Bronze, ""));
            cards.Add(new Card(4, "CC0010004", "거대한 젤리", 6, 260, "g", Types.Character, Properties.Water, Species.Food, Tiers.Silver, ""));
            cards.Add(new Card(5, "CC0010005", "검은 젤리", 7, 480, "ginstp", Types.Character, Properties.Dark, Species.Food, Tiers.Gold, ""));
            cards.Add(new Card(6, "CC0010006", "신성한 젤리", 8, 850, "mrwxyafkpu", Types.Character, Properties.Light, Species.Food, Tiers.Rainbow, ""));
        }

        public override string ToString()
        {
            return code + "\n" + name + "\n" + turn + "\n" + power + "\n" + type + "\n" + property + "\n" + species + "\n" + tier;
        }

        public Card GetCard(int cardNo)
        {
            return cards[cardNo - 1];
        }
    }
}
