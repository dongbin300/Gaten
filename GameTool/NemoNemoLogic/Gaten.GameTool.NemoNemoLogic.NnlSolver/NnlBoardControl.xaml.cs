using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    /// <summary>
    /// NnlBoardControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NnlBoardControl : UserControl
    {
        public List<NnlBoard> Boards { get; set; } = new List<NnlBoard>();

        public NnlBoardControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void Refresh(int index)
        {
            try
            {
                if (Boards == null)
                {
                    return;
                }

                var board = Boards[index];

                grid.ColumnDefinitions.Clear();
                grid.RowDefinitions.Clear();
                grid.Children.Clear();
                int columnCount = board.Data.GetLength(1);
                int rowCount = board.Data.GetLength(0);

                for (int i = 0; i < columnCount; i++)
                {
                    int lineThickness = i % 5 == 4 ? 2 : 1;
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(lineThickness), MinWidth = lineThickness });
                }
                for (int i = 0; i < rowCount; i++)
                {
                    int lineThickness = i % 5 == 4 ? 2 : 1;
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(lineThickness), MinHeight = lineThickness });
                }

                for (int i = 1; i < columnCount * 2; i += 2)
                {
                    Color color = i % 10 == 9 ? Color.FromRgb(178, 16, 22) : Colors.Black;
                    Rectangle r = new()
                    {
                        Fill = new SolidColorBrush(color)
                    };
                    Grid.SetColumn(r, i);
                    Grid.SetRowSpan(r, rowCount * 2);
                    grid.Children.Add(r);
                }
                for (int i = 1; i < rowCount * 2; i += 2)
                {
                    Color color = i % 10 == 9 ? Color.FromRgb(178, 16, 22) : Colors.Black;
                    Rectangle r = new()
                    {
                        Fill = new SolidColorBrush(color)
                    };
                    Grid.SetRow(r, i);
                    Grid.SetColumnSpan(r, columnCount * 2);
                    grid.Children.Add(r);
                }

                for (int i = 0; i < columnCount; i++)
                {
                    for (int j = 0; j < rowCount; j++)
                    {
                        if (board.Data[j, i])
                        {
                            Rectangle r = new()
                            {
                                Fill = new SolidColorBrush(Colors.Black)
                            };
                            Grid.SetColumn(r, i * 2);
                            Grid.SetRow(r, j * 2);
                            grid.Children.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
