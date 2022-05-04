namespace Gaten.GameTool.GITADORA.GDMSM
{
    internal class Player
    {
        public string name;
        public MainForm.Mode mode;
        public int[] gearStarts;
        public int[] gearWidths;
        public int speedStartsX;
        public int speedStartsY;
        public int trimScreenShotStartY;
        public int trimScreenShotLengthY;
        public int frame;
        public int[] heights;
        public int oneColumnCount;
        public int margin;
        public int scI;
        public int startThreshold;
        public int endThreshold;
        public int guitarEndY;

        public Player(string name, MainForm.Mode mode, int frame, int oneColumnCount, int margin, int[] heights, int[] gearStarts, int[] gearWidths, int speedStartsX, int speedStartsY, int trimScreenShotStartY, int trimScreenShotLengthY, int scI, int startThreshold, int endThreshold, int guitarEndY = 720)
        {
            this.name = name;
            this.mode = mode;
            this.frame = frame;
            this.oneColumnCount = oneColumnCount;
            this.margin = margin;
            this.heights = heights;
            this.gearStarts = gearStarts;
            this.gearWidths = gearWidths;
            this.speedStartsX = speedStartsX;
            this.speedStartsY = speedStartsY;
            this.trimScreenShotStartY = trimScreenShotStartY;
            this.trimScreenShotLengthY = trimScreenShotLengthY;
            this.scI = scI;
            this.startThreshold = startThreshold;
            this.endThreshold = endThreshold;
            this.guitarEndY = guitarEndY;
        }
    }
}
