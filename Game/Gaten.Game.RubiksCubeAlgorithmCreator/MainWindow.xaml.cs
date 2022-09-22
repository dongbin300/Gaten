using Gaten.Net.GameRule.RubiksCube;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gaten.Game.RubiksCubeAlgorithmCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RubiksCube333 cube = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rotate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            switch (button.Name.Split('_')[1])
            {
                case "L": cube.Rotate(FaceRotation.Left); break;
                case "L1": cube.Rotate(FaceRotation.CounterLeft); break;
                case "L2": cube.Rotate(FaceRotation.Left); cube.Rotate(FaceRotation.Left); break;
                case "R": cube.Rotate(FaceRotation.Right); break;
                case "R1": cube.Rotate(FaceRotation.CounterRight); break;
                case "R2": cube.Rotate(FaceRotation.Right); cube.Rotate(FaceRotation.Right); break;
                case "U": cube.Rotate(FaceRotation.Up); break;
                case "U1": cube.Rotate(FaceRotation.CounterUp); break;
                case "U2": cube.Rotate(FaceRotation.Up); cube.Rotate(FaceRotation.Up); break;
                case "F": cube.Rotate(FaceRotation.Front); break;
                case "F1": cube.Rotate(FaceRotation.CounterFront); break;
                case "F2": cube.Rotate(FaceRotation.Front); cube.Rotate(FaceRotation.Front); break;
                case "D": cube.Rotate(FaceRotation.Down); break;
                case "D1": cube.Rotate(FaceRotation.CounterDown); break;
                case "D2": cube.Rotate(FaceRotation.Down); cube.Rotate(FaceRotation.Down); break;
                case "B": cube.Rotate(FaceRotation.Back); break;
                case "B1": cube.Rotate(FaceRotation.CounterBack); break;
                case "B2": cube.Rotate(FaceRotation.Back); cube.Rotate(FaceRotation.Back); break;
                case "M": break;
                case "M1": break;
                case "M2": break;
                case "E": break;
                case "E1": break;
                case "E2": break;
                case "S": break;
                case "S1": break;
                case "S2": break;
            }

            RefreshCube();
        }

        private Brush PieceColorToWpfCube(PieceColor pieceColor) =>
            pieceColor switch
            {
                PieceColor.Red => Brushes.DeepSkyBlue,
                PieceColor.Yellow => Brushes.Yellow,
                PieceColor.Green => Brushes.LimeGreen,
                PieceColor.White => Brushes.Orange,
                PieceColor.Magenta => Brushes.Red,
                PieceColor.Cyan => Brushes.White,
                _ => Brushes.Black
            };

        private void RefreshCube()
        {
            R1.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[0]);
            R2.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[1]);
            R3.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[2]);
            R4.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[3]);
            R5.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[4]);
            R6.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[5]);
            R7.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[6]);
            R8.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[7]);
            R9.Fill = PieceColorToWpfCube(cube.Sides[0].PieceColors[8]);
            L1.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[0]);
            L2.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[1]);
            L3.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[2]);
            L4.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[3]);
            L5.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[4]);
            L6.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[5]);
            L7.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[6]);
            L8.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[7]);
            L9.Fill = PieceColorToWpfCube(cube.Sides[1].PieceColors[8]);
            U1.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[0]);
            U2.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[1]);
            U3.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[2]);
            U4.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[3]);
            U5.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[4]);
            U6.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[5]);
            U7.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[6]);
            U8.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[7]);
            U9.Fill = PieceColorToWpfCube(cube.Sides[2].PieceColors[8]);
            D1.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[0]);
            D2.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[1]);
            D3.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[2]);
            D4.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[3]);
            D5.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[4]);
            D6.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[5]);
            D7.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[6]);
            D8.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[7]);
            D9.Fill = PieceColorToWpfCube(cube.Sides[3].PieceColors[8]);
            F1.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[0]);
            F2.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[1]);
            F3.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[2]);
            F4.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[3]);
            F5.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[4]);
            F6.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[5]);
            F7.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[6]);
            F8.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[7]);
            F9.Fill = PieceColorToWpfCube(cube.Sides[4].PieceColors[8]);
            B1.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[0]);
            B2.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[1]);
            B3.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[2]);
            B4.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[3]);
            B5.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[4]);
            B6.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[5]);
            B7.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[6]);
            B8.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[7]);
            B9.Fill = PieceColorToWpfCube(cube.Sides[5].PieceColors[8]);
        }
    }
}
