using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Game.CDRPG
{
    public class Ground
    {
        int size = 10;
        int turn;
        int turnLimit;
        int[][] isEnemy;

        List<Enemy> enemy = new List<Enemy>();
        List<Card> playerCards = new List<Card>();

        public Ground()
        {
            isEnemy = new int[size][];
            for (int i = 0; i < size; i++)
            {
                isEnemy[i] = new int[size];
            }
        }

        public void NewLevel()
        {
            turn = 0;
            turnLimit = 10;
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int x = random.Next(size);
                int y = random.Next(size);
                if (isEnemy[y][x] != 0)
                {
                    i--;
                    continue;
                }
                enemy.Add(new Enemy(new Enemy.Position(x, y), 100, Card.Tiers.Bronze, Card.Properties.None, Card.Species.Human));
                isEnemy[y][x] = 1;
            }
        }

        public void Attack()
        {
            Random random = new Random();
            Enemy targetEnemy = enemy[random.Next(enemy.Count)];

            for (int c = 0; c < playerCards.Count; c++)
            {
                for (int i = 0; i < 25; i++)
                {
                    CardAttack(targetEnemy, playerCards[c], new Card().rangeString[i], i % 5 - 2, i / 5 - 2);
                }
            }
        }

        bool CardAttack(Enemy targetEnemy, Card playerCard, char rangeCode, int x, int y)
        {
            if(rangeCode == 'm')
            {
                Enemy addTargetEnemy = GetEnemy(new Enemy.Position(targetEnemy.position.X + x, targetEnemy.position.Y + y));
                if (addTargetEnemy.Damage(playerCard.power))
                {
                    enemy.Remove(addTargetEnemy);
                }
                return true;
            }

            if (targetEnemy.position.X + x >= 0 && targetEnemy.position.X + x <= size &&
                targetEnemy.position.Y + y >= 0 && targetEnemy.position.Y + y <= size)
            {
                if (playerCard.range.Contains(rangeCode) &&
                    isEnemy[targetEnemy.position.Y + y][targetEnemy.position.X + x] != 0)
                {
                    Enemy addTargetEnemy = GetEnemy(new Enemy.Position(targetEnemy.position.X + x, targetEnemy.position.Y + y));
                    if (addTargetEnemy.Damage(playerCard.power))
                    {
                        enemy.Remove(addTargetEnemy);
                    }
                    return true;
                }
            }
            return false;
        }

        public bool NewCard(Card card)
        {
            int characterCardCount = 0;
            int weaponCardCount = 0;
            foreach (Card c in playerCards)
            {
                switch (c.type)
                {
                    case Card.Types.Character:
                        characterCardCount++;
                        break;
                    case Card.Types.Weapon:
                        weaponCardCount++;
                        break;
                }
            }
            if (card.type == Card.Types.Character && characterCardCount >= 4)
                return false;
            if (card.type == Card.Types.Weapon && weaponCardCount >= 4)
                return false;

            playerCards.Add(card);
            return true;
        }

        public Enemy GetEnemy(Enemy.Position position)
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i].position.X == position.X && enemy[i].position.Y == position.Y)
                {
                    return enemy[i];
                }
            }
            return null;
        }

        public override string ToString()
        {
            string str = string.Empty;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    str += isEnemy[i][j] == 0 ? "□" : "■";
                }
                str += "\n";
            }
            return str;
        }
    }
}
