using Gaten.Net.Windows;

using System.Drawing;
using System.Runtime.Versioning;

namespace Gaten.Game.MapAdventureConsole
{
    [SupportedOSPlatform("windows")]
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
        public int ClearInterval = 5;


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="name"></param>
        /// <param name="updateInterval"></param>
        public GameEngine(string name, int updateInterval)
        {
            Name = name;
            UpdateInterval = updateInterval;

            Initialize();
        }

        /// <summary>
        /// 게임 엔진의 기본값을 설정한다.
        /// </summary>
        private void Initialize()
        {
            // 스크린매니저 초기화
            //_ = new ScreenManager();

            // 기본화면은 인트로
            //ScreenManager.CurrentScreen = ScreenManager.Screen.Intro;
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

                // 게임 화면 업데이트
                Render();

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
        private void Update()
        {
            // 캐릭터 정보 연산
            //Character.Calculate();
        }

        /// <summary>
        /// 게임 화면을 업데이트한다.
        /// </summary>
        private void Render()
        {
            using Graphics g = Graphics.FromHwnd(WinApi.GetConsoleWindow());
            using Image image = Image.FromFile("me.png");
            g.DrawImage(image, new System.Drawing.Point(Character.X, Character.Y));
        }

        /// <summary>
        /// [비동기]키보드 입력값을 받아서 처리한다.
        /// 화면이 계속 키보드 입력값을 받으려고 대기할 수는 없으므로 비동기로 구현한다.
        /// </summary>
        private async void KeyboardInput()
        {
            await Task.Factory.StartNew(() =>
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        Character.MoveUp();
                        break;

                    case ConsoleKey.DownArrow:
                        Character.MoveDown();
                        break;

                    case ConsoleKey.LeftArrow:
                        Character.MoveLeft();
                        break;

                    case ConsoleKey.RightArrow:
                        Character.MoveRight();
                        break;

                    case ConsoleKey.C:
                        Character.Jump();
                        break;

                    default:
                        break;
                }
            });
        }
    }
}
