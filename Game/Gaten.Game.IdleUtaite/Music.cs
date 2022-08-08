namespace Gaten.Game.IdleUtaite
{
    public class Music
    {
        /// <summary>
        /// 노래 번호
        /// </summary>
        public int index;
        /// <summary>
        /// 노래 제목
        /// </summary>
        public string title;
        /// <summary>
        /// 최고음 1: 1옥타브도 7: 1옥타브파# 13: 2옥타브도 19: 2옥타브파# 25: 3옥타브도 31: 3옥타브파# 37: 4옥타브도
        /// </summary>
        public int highestNote;
        /// <summary>
        /// 박자/빠르기 난이도 1~10
        /// </summary>
        public int rhythmDifficulty;
        /// <summary>
        /// 조회 부스트: 높을수록 조회수가 빨리 증가할 확률이 높다
        /// </summary>
        public int hitBoost;

        public Music() { }

        public Music(int index, string title, int highestNote, int rhythmDifficulty)
        {
            this.index = index;
            this.title = title;
            this.highestNote = highestNote;
            this.rhythmDifficulty = rhythmDifficulty;
            hitBoost = (int)(Math.Pow(highestNote, 2.1) * (0.5 + (0.1 * rhythmDifficulty)));
        }
    }
}
