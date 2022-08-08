using Gaten.Game.NGDG2.GameRule.Character;
using Gaten.Game.NGDG2.GameRule.Dungeon;
using Gaten.Game.NGDG2.GameRule.Item;
using Gaten.Game.NGDG2.GameRule.Monster;
using Gaten.Game.NGDG2.Screen;

namespace Gaten.Game.NGDG2.Engine
{
    public class GameEngine
    {
        /// <summary>
        /// 게임 엔진의 ID
        /// </summary>
        public string Name;

        /// <summary>
        /// 엔진이 작동 중인지 아닌지 구분
        /// </summary>
        public bool IsRunning;

        /// <summary>
        /// 업데이트 간격 (틱, 단위: ms)
        /// </summary>
        public int UpdateInterval;

        /// <summary>
        /// 콘솔창 Clear 간격 (단위: 틱)
        /// </summary>
        public int ClearInterval = 10;


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="name"></param>
        /// <param name="updateInterval"></param>
        public GameEngine(string name, int updateInterval)
        {
            Name = name;
            UpdateInterval = updateInterval;

            // 리소스 로드
            if (!LoadResource())
            {
                throw new Exception("리소스 로드 실패!"); // 실패 
            }

            Initialize();
        }

        /// <summary>
        /// 게임 엔진의 기본값을 설정한다.
        /// </summary>
        public void Initialize()
        {
            // 기본화면은 인트로
            ScreenManager.CurrentScreen = ScreenManager.Screen.Intro;
        }

        /// <summary>
        /// 게임에 필요한 리소스를 불러온다.
        /// 리소스가 하나라도 정상적으로 불러와지지않을 경우 즉시 종료한다.
        /// </summary>
        public bool LoadResource()
        {
            try
            {
                // 몬스터 리소스 로드
                _ = new NgdgMonsterDictionary();

                // 던전 리소스 로드
                _ = new NgdgDungeonDictionary();

                // 장비 리소스 로드
                // 재료 리소스 로드
                // 포션 리소스 로드
                _ = new NgdgItemDictionary();

                // 화면 리소스 로드
                _ = new ScreenManager();
            }
            catch
            {
                // 로드 실패
                return false;
            }

            // 로드 성공
            return true;
        }

        /// <summary>
        /// 게임 엔진을 작동시킨다.
        /// 게임 엔진이 작동하기 시작하면 IsRunning의 값이 false가 되기 전까지는 다른 코드에 접근할 수 없다.
        /// </summary>
        public void Start()
        {
            IsRunning = true;

            int ClearCount = 0;

            // 게임이 시작되고 나서 완전히 종료되기 전까지 IsRunning의 값은 true로 고정
            // 게임이 종료 될 때, 비정상적으로 종료될 때만 IsRunning의 값을 false로 넣어준다.
            while (IsRunning)
            {
                // UpdateInterval밀리초 대기
                Thread.Sleep(UpdateInterval);

                // ClearInterval틱마다 콘솔창을 Clear해줌
                if (++ClearCount >= ClearInterval)
                {
                    ClearCount -= ClearInterval;
                    Console.Clear();
                }

                // 게임 데이터 업데이트
                Update();

                // 키보드 입력값 받아서 처리
                KeyboardInput();
            }

            // 계속하려면 아무 키나 누르십시오...
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// 게임 데이터를 업데이트한다.
        /// </summary>
        public void Update()
        {
            // 캐릭터 정보 연산
            NgdgCharacter.Calculate();

            // 화면 업데이트
            ScreenManager.Redraw();
        }

        /// <summary>
        /// [비동기]키보드 입력값을 받아서 처리한다.
        /// 화면이 계속 키보드 입력값을 받으려고 대기할 수는 없으므로 비동기로 구현한다.
        /// </summary>
        private async void KeyboardInput()
        {
            await Task.Factory.StartNew(() =>
            {
                switch (ScreenManager.React())
                {
                    case "GameExit": // 게임 종료
                        IsRunning = false;
                        break;

                    default:
                        break;
                }
            });
        }
    }
}
