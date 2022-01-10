// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var c = document.getElementById("sudokuBoard");
var p = document.getElementById("sudokuPuzzle");
var puzzle = p.firstChild.textContent;
var cellsize = 35;
var textrowoffset = 25;
var textcoloffset = 12;
var ctx = c.getContext("2d");
ctx.font = "20px Arial";
var row = 0, col = 0, cell = 0;
ctx.lineWidth = "1";
ctx.beginPath();
for (var cell = 0; cell < 81; cell++) {
	if (cell % 3 == 0) { col += 10; }
	if (cell % 27 == 0) { row += 10; }
	if (cell % 9 == 0) { col = 10; if (cell > 0) row += cellsize + 5; }
	ctx.rect(col, row, cellsize, cellsize);
	if (puzzle[cell] != '.') ctx.fillText(puzzle[cell], col + textcoloffset, row + textrowoffset);
	col += cellsize + 5;
}
ctx.stroke();

