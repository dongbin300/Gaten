namespace Gaten.Game.CDRPG
{
    internal class Program
    {
        private static readonly Card c = new();
        private static readonly Character crt = new();
        private static readonly Ground g = new();

        private static void Main(string[] args)
        {
            // 카드 정보를 초기화
            c.AddCard();

            // 캐릭터 카드 획득
            crt.ObtainCard(new Card().GetCard(1));

            // 전장을 초기화
            g.NewLevel();
            Console.WriteLine(g.ToString());

            Turn();
        }

        private static void Turn()
        {
            crt.Draw();

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.A:
                    crt.Attack();
                    break;
                case ConsoleKey.P:
                    //crt.Place();
                    break;
            }
        }
    }
}
