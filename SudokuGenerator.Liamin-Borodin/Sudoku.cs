using System;

namespace SudokuGenerator.Liamin_Borodin
{
	public class Sudoku
	{
		private const int _size = 9;

		private const int _boxSize = 3;

		private const int _minEmptyCells = 17;

		private const int _maxEmptyCells = 30;

		private readonly int[,] _grid;

		private readonly Random _random;

		public Sudoku()
		{
			_grid = new int[_size, _size];
			_random = new Random();
		}

		public int[,] Generate()
		{
			Clear();

			GenerateSolution();

			RemoveCells();

			return _grid;
		}

		private void Clear()
		{
			for (int row = 0; row < _size; row++)
			{
				for (int col = 0; col < _size; col++)
				{
					_grid[row, col] = 0;
				}
			}
		}

		private void GenerateSolution()
		{
			_ = GenerateSolution(0, 0);
		}

		private bool GenerateSolution(int row, int col)
		{
			if (row == _size)
			{
				row = 0;

				if (++col == _size)
				{
					return true;
				}
			}

			if (_grid[row, col] != 0)
			{
				return GenerateSolution(row + 1, col);
			}

			for (int number = 1; number <= _size; number++)
			{
				if (IsValid(row, col, number))
				{
					_grid[row, col] = number;

					if (GenerateSolution(row + 1, col))
					{
						return true;
					}
				}
			}

			_grid[row, col] = 0;

			return false;
		}

		private bool IsValid(int row, int col, int number)
		{
			for (int i = 0; i < _size; i++)
			{
				if (_grid[row, i] == number)
				{
					return false;
				}
			}

			for (int i = 0; i < _size; i++)
			{
				if (_grid[i, col] == number)
				{
					return false;
				}
			}

			int startRow = row - (row % _boxSize);

			int startCol = col - (col % _boxSize);

			for (int i = startRow; i < startRow + _boxSize; i++)
			{
				for (int j = startCol; j < startCol + _boxSize; j++)
				{
					if (_grid[i, j] == number)
					{
						return false;
					}
				}
			}

			return true;
		}

		private void RemoveCells()
		{
			int emptyCells = _random.Next(_minEmptyCells, _maxEmptyCells + 1);

			for (int i = 0; i < emptyCells; i++)
			{
				int row = _random.Next(0, _size);

				int col = _random.Next(0, _size);

				_grid[row, col] = 0;
			}
		}
	}
}