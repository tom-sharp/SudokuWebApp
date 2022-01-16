using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SudokuWebApp.Models;
using Sudoku.Puzzle;
using Sudoku.DataStore;

namespace SudokuWebApp.Controllers
{
	public class SudokuController : Controller
	{
		public SudokuController(ISudokuDb dbctx) {
			this.db = dbctx;
		}

		public IActionResult Index() {
			return View();
		}

		public async Task<IActionResult> NewPuzzle() {
			var puzzle = new CreateSudoku().GetSudokuPuzzle();
			var model = new SudokuPuzzleModel(puzzle);
			if (await this.db.AddAsync(puzzle.GetPuzzle())) await this.db.SaveChangesAsync();
			return View("Puzzle",model);
		}

		public async Task<IActionResult> Puzzle(int difficultycategory) {
			if ((difficultycategory < 1) || (difficultycategory > 5)) {
				return RedirectToAction("NewPuzzle");
			}
			var puzzle = await this.db.GetRandomPuzzleAsync(difficultycategory);
			if (puzzle == null) return RedirectToAction("NewPuzzle");
			var model = new SudokuPuzzleModel(puzzle);
			return View(model);
		}


		public IActionResult PuzzleSolver(string SolvePuzzle) {
			var puzzle = new SudokuPuzzle(SolvePuzzle);
			var model = new SudokuPuzzleModel(puzzle);
			if (puzzle.ResolveNumPass()) model.PuzzleSolved = puzzle.GetPuzzle();
			else model.PuzzleSolved = "Bad puzzle";
			return View(model);
		}



		public IActionResult Privacy()
		{
			return View();
		}


		ISudokuDb db = null;

	}
}
