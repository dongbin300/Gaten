namespace Gaten.Game.IdleUtaite.Studio
{
    public class Studio
    {
        public List<Music> musics = new List<Music>();
        public Music recordedMusic;
        public List<Effector> effectors = new List<Effector>();

        public Studio() { }

        public void AddMusic()
        {
            musics.Add(new Music(0, "모래의 행성", 9, 2));
            musics.Add(new Music(1, "로미오와 신데렐라", 12, 3));
            musics.Add(new Music(2, "위풍당당", 13, 5));
            musics.Add(new Music(3, "Gears of Love", 13, 3));
            musics.Add(new Music(4, "금요일의 아침인사", 13, 2));
            musics.Add(new Music(5, "사요코", 13, 4));
            musics.Add(new Music(6, "패배의 소년", 13, 5));
        }

        public void AddEffector()
        {
            effectors.Add(new Effector("게인", 2000, 10));
            effectors.Add(new Effector("딜레이", 10000, 30));
            effectors.Add(new Effector("페이드인", 25000, 50));
            effectors.Add(new Effector("페이드아웃", 80000, 75));
            effectors.Add(new Effector("노멀라이저", 200000, 100));
            effectors.Add(new Effector("노이즈게이트", 500000, 150));
            effectors.Add(new Effector("게이트", 2000, 10));
            effectors.Add(new Effector("이퀄라이저", 2000, 10));
            effectors.Add(new Effector("패너", 2000, 10));
            effectors.Add(new Effector("필터", 2000, 10));
            effectors.Add(new Effector("디에서", 2000, 10));
            effectors.Add(new Effector("컴프레서", 2000, 10));
            effectors.Add(new Effector("리미터", 2000, 10));
            effectors.Add(new Effector("튜너", 2000, 10));
            effectors.Add(new Effector("피치시프터", 2000, 10));
            effectors.Add(new Effector("서라운드", 2000, 10));
            effectors.Add(new Effector("리버브", 2000, 10));
            effectors.Add(new Effector("디스토션", 2000, 10));
            effectors.Add(new Effector("멀티밴드컴프레서", 2000, 10));
            effectors.Add(new Effector("코러스", 2000, 10));
            effectors.Add(new Effector("플랜저", 2000, 10));
            effectors.Add(new Effector("페이저", 2000, 10));
        }
    }
}
