namespace Gaten.GameTool.StarCraft.BoundMapMaker
{
    public class BoundPanel
    {
        public enum TileType
        {
            Blank,
            BoundZone,
            BoundZone2,
            Creep,
            Pointer
        }

        public TileType[,] Tiles { get; set; }

        public List<BoundZone> BoundZones { get; set; }
        public List<Pattern> Patterns { get; set; }

        public BoundPanel()
        {
            Tiles = new TileType[30, 40];
            BoundZones = new List<BoundZone>();
            Patterns = new List<Pattern>();

            Reset();
        }

        public void Reset()
        {
            // Clear
            for (int i = 0; i < Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Tiles.GetLength(1); j++)
                {
                    Tiles[i, j] = TileType.Blank;
                }
            }

            // Waiting Creep Tile
            Tiles[14, 0] = Tiles[15, 0] = TileType.Creep;
        }

        public void AddBoundZone(int x, int y, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Tiles[y + i, x + j] = TileType.BoundZone;
                }
            }

            BoundZones.Add(new BoundZone()
            {
                ID = BoundZones.Count + 1,
                X = x,
                Y = y,
                Size = size
            });
        }

        public void RefreshPointer(int x, int y, int size = 1)
        {
            for (int i = 0; i < Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Tiles.GetLength(1); j++)
                {
                    if (Tiles[i, j] == TileType.Pointer)
                        Tiles[i, j] = TileType.Blank;
                }
            }

            switch (size)
            {
                case 1:
                    if (Tiles[y, x] == TileType.Blank)
                        Tiles[y, x] = TileType.Pointer;
                    break;
                case 2:
                    if (Tiles[y, x] == TileType.Blank && Tiles[y, x + 1] == TileType.Blank && Tiles[y + 1, x] == TileType.Blank && Tiles[y + 1, x + 1] == TileType.Blank)
                    {
                        Tiles[y, x] = TileType.Pointer;
                        Tiles[y, x + 1] = TileType.Pointer;
                        Tiles[y + 1, x] = TileType.Pointer;
                        Tiles[y + 1, x + 1] = TileType.Pointer;
                    }
                    break;
            }

        }

        /// <summary>
        /// 2차원 배열에서의 정사각형 모양으로 검사한다.
        /// array[y,x]의 크기가 size인 정사각형에 target이 있는지 검사
        /// 하나라도 존재하면 true, 하나도 없으면 false 반환
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool InspectSquare(TileType target, int x, int y, int size = 1)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (Tiles[i, j] == target)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 2차원 배열에서의 주변을 검사한다.
        /// array[y,x]의 크기가 size인 정사각형 주변에 target이 있는지 검사(대각선은 검사 안함)
        /// 하나라도 존재하면 true, 하나도 없으면 false 반환
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool InspectAmbient(TileType target, int x, int y, int size = 1)
        {
            switch (size)
            {
                case 1:
                    if (x > 0)
                    {
                        if (Tiles[y, x - 1] == target)
                            return true;
                    }

                    if (y > 0)
                    {
                        if (Tiles[y - 1, x] == target)
                            return true;
                    }

                    if (x < Tiles.GetLength(1) - 1)
                    {
                        if (Tiles[y, x + 1] == target)
                            return true;
                    }

                    if (y < Tiles.GetLength(0) - 1)
                    {
                        if (Tiles[y + 1, x] == target)
                            return true;
                    }
                    break;
                case 2:
                    if (x > 0)
                    {
                        if (Tiles[y, x - 1] == target)
                            return true;
                        if (y < Tiles.GetLength(0) - 1)
                        {
                            if (Tiles[y + 1, x - 1] == target)
                                return true;
                        }
                    }
                    if (y > 0)
                    {
                        if (Tiles[y - 1, x] == target)
                            return true;
                        if (x < Tiles.GetLength(1) - 1)
                        {
                            if (Tiles[y - 1, x + 1] == target)
                                return true;
                        }
                    }
                    if (x < Tiles.GetLength(1) - 2)
                    {
                        if (Tiles[y, x + 2] == target)
                            return true;
                        if (y < Tiles.GetLength(0) - 1)
                        {
                            if (Tiles[y + 1, x + 2] == target)
                                return true;
                        }
                    }
                    if (y < Tiles.GetLength(0) - 2)
                    {
                        if (Tiles[y + 2, x] == target)
                            return true;
                        if (x < Tiles.GetLength(1) - 1)
                        {
                            if (Tiles[y + 2, x + 1] == target)
                                return true;
                        }
                    }
                    break;
            }


            return false;
        }
    }
}
