using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.GameRule.GITADORA
{
    public class Phrase
    {
        // 마디 번호
        public int Num;

        // 마디 플레이 시간
        public double Duration;

        // 노트
        public List<Path> Note;

        public Phrase()
        {
            Note = new List<Path>();
        }
    }
}
