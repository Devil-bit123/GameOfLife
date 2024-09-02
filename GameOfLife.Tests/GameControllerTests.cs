using GameOfLife.Controllers;
using GameOfLife.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
    public class GameControllerTests
    {

        private GameController CreateController()
        {
            return new GameController();
        }

        [Fact]
        public void Index_Should_Return_View_With_Grid()
        {
            // Arrange
            var controller = CreateController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Grid>(result.Model);
        }

        [Fact]
        public void NextGeneration_Should_Update_Grid()
        {
            var controller = CreateController();

            // Configurar el estado inicial de la cuadrícula
            controller.ToggleCell(1, 0); // Activa la celda (1,0)
            controller.ToggleCell(1, 1); // Activa la celda (1,1)
            controller.ToggleCell(1, 2); // Activa la celda (1,2)
            controller.ToggleCell(2, 1); // Activa la celda (2,1)

            var initialResult = controller.Index() as ViewResult;
            var initialGrid = initialResult.Model as Grid;

            Assert.False(initialGrid.Cells[2, 0].IsAlive); // Estado inicial de la celulua muerta

            // Act
            controller.NextGeneration();
            var result = controller.Index() as ViewResult;
            var updatedGrid = result.Model as Grid;            
            // Assert
            Assert.NotNull(updatedGrid);        
            Assert.True(updatedGrid.Cells[2, 0].IsAlive); // Verifica que la celda está viva después de NextGeneration

        }

        [Fact]
        public void ToggleCell_Should_Change_Cell_State()
        {
            // Arrange
            var controller = CreateController();
            var initialResult = controller.Index() as ViewResult;
            var grid = initialResult.Model as Grid;

            // Act
            controller.ToggleCell(0, 0);
            var result = controller.Index() as ViewResult;
            var updatedGrid = result.Model as Grid;

            // Assert
            Assert.NotNull(updatedGrid);
            Assert.True(updatedGrid.Cells[0, 0].IsAlive);
        }

    }
}
