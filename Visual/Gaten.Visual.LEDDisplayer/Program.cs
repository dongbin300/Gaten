using Gaten.Visual.LEDDisplayer;

Random r = new Random();

StandardCharacter sc = new StandardCharacter();
Block b1 = sc.Make("MOMO");
b1.X = 10;
b1.Y = 10;
//Block b2 = sc.Make("A");

DisplayBoard db = new DisplayBoard();
db.Blocks.Add(b1);
db.Display();

b1.SetPixelColor(ConsoleColor.Green);

for (int i = 0; i < 10000; i++)
{
    b1.SetPixelColor((ConsoleColor)r.Next(15));
    int step = 2;
    int duration = 50;
    switch (r.Next(4))
    {
        case 0: b1.Move(step, 0, duration); break;
        case 1: b1.Move(0, step, duration); break;
        case 2: if (b1.X > 0) b1.Move(-step, 0, duration); break;
        case 3: if (b1.Y > 0) b1.Move(0, -step, duration); break;
    }
    db.Display();
}