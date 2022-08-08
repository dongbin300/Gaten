namespace Gaten.Game.CDRPG
{
    public class Character
    {
        private readonly List<Card> deck = new();
        private readonly List<Card> hand = new();
        public Character()
        {
        }

        public void ObtainCard(Card card)
        {
            deck.Add(card);
        }

        public void PrintDeck()
        {
            foreach (Card c in deck)
            {
                Console.WriteLine(c.ToString());
            }
        }

        public void Draw()
        {
            Random random = new();
            for (int i = 0; i < 5; i++)
            {
                int idx = random.Next(deck.Count);
                deck.RemoveAt(idx);
                hand.Add(deck[idx]);
            }
        }

        public void Place(Card card)
        {
            _ = new Ground().NewCard(card);
        }

        public void Attack()
        {

        }
    }
}
