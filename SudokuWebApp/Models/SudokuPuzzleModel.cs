using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sudoku.Puzzle;
using Sudoku.DataStore;

namespace SudokuWebApp.Models
{
	public class SudokuPuzzleModel {
		public SudokuPuzzleModel() { this.Puzzle = ""; this.PuzzleSolved = ""; this.DifficultyCategory = 0; }
		public SudokuPuzzleModel(SudokuPuzzle puzzle):this() { this.Puzzle = puzzle.GetPuzzle(); }
		public SudokuPuzzleModel(SudokuEntity puzzle): this() { this.Puzzle = puzzle.PuzzleId; this.DifficultyCategory = puzzle.Category; }

		public string Puzzle { get; set; }
		public string PuzzleSolved { get; set; }
		public int DifficultyCategory { get; set; }

	}
}
