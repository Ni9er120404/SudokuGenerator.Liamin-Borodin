using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SudokuGenerator.Liamin_Borodin
{
	public partial class StartWindow : Window
	{
		private readonly int[,] puzzle = new Sudoku().Generate();

		public StartWindow()
		{
			InitializeComponent();

			for (int row = 0; row < puzzle.GetLength(0); row++)
			{
				for (int col = 0; col < puzzle.GetLength(1); col++)
				{
					TextBox cell = new()
					{
						Text = puzzle[row, col].ToString(),
						Width = 30,
						Height = 30,
						FontFamily = new FontFamily("Arial"),
						FontSize = 16,
						HorizontalContentAlignment = HorizontalAlignment.Center,
						VerticalContentAlignment = VerticalAlignment.Center
					};

					Grid.SetRow(cell, row);
					Grid.SetRowSpan(cell, 1);

					Grid.SetColumn(cell, col);
					Grid.SetColumnSpan(cell, 1);

					_ = PuzzleGrid.Children.Add(cell);
				}
			}
		}
	}
}