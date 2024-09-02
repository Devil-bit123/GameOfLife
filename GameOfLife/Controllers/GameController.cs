
using GameOfLife.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameOfLife.Controllers
{
    public class GameController : Controller
    {
        private static Grid _grid = new Grid(10, 10); // Tamaño de la cuadrícula

        public IActionResult Index()
        {
            return View(_grid);
        }

        [HttpPost]
        public IActionResult NextGeneration()
        {
            _grid.NextGeneration();
            return PartialView("_GridPartial", _grid); // Devuelve solo la tabla
        }

        [HttpPost]
        public IActionResult ToggleCell(int row, int col)
        {
            _grid.Cells[row, col].IsAlive = !_grid.Cells[row, col].IsAlive;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reset()
        {
            _grid.Reset(_grid.Rows, _grid.Columns);
            return PartialView("_GridPartial", _grid);
        }

        [HttpGet]
        public IActionResult About() {
            return View("About");
        }
    }
}
