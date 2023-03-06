using System.Collections.Generic;

namespace Gaten.GameTool.Baduk.Paejak
{
    internal class BadukBoard
    {
        public List<System.Windows.Point> WindowPositions { get; set; } = new();

        public BadukBoard()
        {

        }

        public BadukBoard(int x, int y, int w, int h)
        {
            MappingPositions(x, y, w, h);
        }

        public void MappingPositions(int x, int y, int w, int h)
        {
            int entryX = x + 44;
            int entryY = y + 63;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    var point = new System.Windows.Point(entryX + j * 59, entryY + i * 59);
                    WindowPositions.Add(point);
                }
            }
        }

        /// <summary>
        /// 바둑판 좌표로 실제 윈도우 좌표 가져오기
        /// (1,1) ~ (19,19)
        /// </summary>
        /// <param name="boardX"></param>
        /// <param name="boardY"></param>
        /// <returns></returns>
        public System.Windows.Point GetWindowPosition(int boardX, int boardY)
        {
            return WindowPositions[(boardY - 1) * 19 + (boardX - 1)];
        }

        public (int, int) GetWindowPositionInteger(int boardX, int boardY)
        {
            var p = GetWindowPosition(boardX, boardY);
            return ((int)p.X, (int)p.Y);
        }
    }
}
