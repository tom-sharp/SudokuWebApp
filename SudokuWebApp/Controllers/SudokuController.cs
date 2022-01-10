using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SudokuWebApp.Models;
using Sudoku.Puzzle;

namespace SudokuWebApp.Controllers
{
	public class SudokuController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult NewPuzzle()
		{
			var puzzle = new CreateSudoku().GetSudokuPuzzle();
			var model = new SudokuPuzzleModel() { PuzzleString = puzzle.GetPuzzle(), SudokuString = "" };
//			puzzle.ResolveNumPass();
//			model.SudokuString = puzzle.GetPuzzle();
			return View(model);
		}


		public IActionResult PuzzleSolver(string SolvePuzzle) {
			var puzzle = new SudokuPuzzle(SolvePuzzle);
			var model = new SudokuPuzzleModel() { PuzzleString = puzzle.GetPuzzle(), SudokuString = "" };
			if (puzzle.ResolveNumPass()) model.SudokuString = puzzle.GetPuzzle();
			else model.SudokuString = "Bad puzzle";
			return View(model);
		}



		public IActionResult Privacy()
		{
			return View();
		}


	}
}
