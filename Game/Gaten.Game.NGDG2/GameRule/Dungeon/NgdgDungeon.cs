using Gaten.Game.NGDG2.GameRule.Item;
using Gaten.Game.NGDG2.GameRule.Monster;
using Gaten.Game.NGDG2.Util.Math;

namespace Gaten.Game.NGDG2.GameRule.Dungeon
{
    /// <summary>
    /// 던전
    /// 
    /// - 던전 정보
    /// [웨이브 수]/[등장 몬스터]/[한 웨이브에 나오는 몬스터 수]
    /// 
    /// - 던전 보상
    /// 던전 안에서 몬스터를 잡으면 EXP와 골드를 얻는다. (아이템도 확률적으로 드랍)
    /// 이 EXP와 골드는 계속 축적되며 던전 클리어시 던전 클리어 보상과 함께 주어진다.
    /// 클리어 보상은 던전에서 잡은 몬스터들의 총 EXP와 골드의 20%이다.
    /// 
    /// - 던전 즉시 퇴장
    /// 던전을 진행하다가 나가고 싶으면 ESC키를 눌러서 나갈 수 있다.
    /// 던전을 퇴장하면 잡았던 몬스터들의 보상도 날아가게 된다.
    /// </summary>
    public class NgdgDungeon
    {
        /// <summary>
        /// 던전 이름(ID)
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// 입장 권장레벨
        /// </summary>
        public int Level;

        /// <summary>
        /// 던전 웨이브
        /// </summary>
        public List<NgdgDungeonWave> Waves = new();

        /// <summary>
        /// 출현 몬스터 목록
        /// </summary>
        public List<Monster.NgdgMonster> MonsterBounds = new();

        /// <summary>
        /// 출현 몬스터 수
        /// </summary>
        public Bounds MonsterCountBounds = default!;

        /// <summary>
        /// 누적된 경험치
        /// </summary>
        public long AccumulatedExp;

        /// <summary>
        /// 누적된 골드
        /// </summary>
        public long AccumulatedGold;

        /// <summary>
        /// 누적된 아이템
        /// </summary>
        public NgdgInventory AccumulatedItems = default!;

        /// <summary>
        /// 던전 정보
        /// </summary>
        public string FormattedDungeonInfo = string.Empty;

        public NgdgDungeon()
        {

        }

        /// <summary>
        /// [생성자] 던전 정보를 설정한다.
        /// </summary>
        /// <param name="name">이름</param>
        /// <param name="formattedDungeonInfo">던전 정보, ex) "3/고블린이병,고블린일병/3~5"</param>
        public NgdgDungeon(string name, string formattedDungeonInfo)
        {
            Name = name;
            FormattedDungeonInfo = formattedDungeonInfo;
        }

        /// <summary>
        /// 던전을 만든다.
        /// </summary>
        public NgdgDungeon Make(NgdgDungeon frame)
        {
            Name = frame.Name;
            FormattedDungeonInfo = frame.FormattedDungeonInfo;

            // 인포 파싱
            string[] infos = FormattedDungeonInfo.Split('/');

            int waveCount = int.Parse(infos[0]);
            string[] monsterNames = infos[1].Split(',');
            string[] monsterCounts = infos[2].Split('~');

            // 몬스터 수 범위 구성
            Bounds? bound = new(int.Parse(monsterCounts[0]), int.Parse(monsterCounts[1]));

            // 몬스터 출현 목록 구성
            List<Monster.NgdgMonster> monsterList = new();
            foreach (string monsterName in monsterNames)
            {
                monsterList.Add(NgdgMonsterDictionary.MakeMonster(monsterName));
            }

            // 던전 웨이브 생성
            Waves = new List<NgdgDungeonWave>();
            for (int i = 0; i < waveCount; i++)
            {
                Waves.Add(new NgdgDungeonWave(monsterList, bound.Get()));
            }

            // 던전 보상 초기화
            AccumulatedExp = 0;
            AccumulatedGold = 0;
            AccumulatedItems = new NgdgInventory(20); // 한 던전에서의 아이템 획득 종류 최대 20

            return this;
        }
    }
}
