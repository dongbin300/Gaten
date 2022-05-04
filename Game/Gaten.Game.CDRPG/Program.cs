using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Game.CDRPG
{
    class Program
    {
        static Card c = new Card();
        static Character crt = new Character();
        static Ground g = new Ground();

        static void Main(string[] args)
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

        static void Turn()
        {
            crt.Draw();

            switch(Console.ReadKey(true).Key)
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
