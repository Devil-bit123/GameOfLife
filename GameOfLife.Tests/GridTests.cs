using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
    public class GridTests
    {
        [Fact]
        public void Grid_Should_Initialize_With_Dead_Cells()
        {
            // Arrange
            var grid = new Grid(5, 5);

            // Act & Assert
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Assert.False(grid.Cells[i, j].IsAlive);
                }
            }
        }

        /**
         * Using block patron
         */
        [Fact]
        public void Grid_Should_Change_State_According_To_NextGeneration_using_block_patron()
        {
            // Arrange
            var grid = new Grid(10, 10);

            grid.Cells[0, 0].IsAlive = true;
            grid.Cells[0, 1].IsAlive = true;
            grid.Cells[1, 0].IsAlive = true;
            grid.Cells[1, 1].IsAlive = true;



            // Act
            grid.NextGeneration();

            // Assert
            Assert.True(grid.Cells[0, 0].IsAlive);
            Assert.True(grid.Cells[0, 1].IsAlive);
            Assert.True(grid.Cells[1, 0].IsAlive);
            Assert.True(grid.Cells[1, 1].IsAlive);

        }

        [Fact]
        public void Grid_Should_Change_State_According_To_NextGeneration_using_Blinker_patron()
        {
            // Arrange
            var grid = new Grid(10, 10);

            // Set up the initial state for the Blinker pattern
            grid.Cells[0, 0].IsAlive = false;
            grid.Cells[0, 1].IsAlive = false;
            grid.Cells[0, 2].IsAlive = false;
            grid.Cells[0, 3].IsAlive = false;
            grid.Cells[0, 4].IsAlive = false;

            grid.Cells[1, 0].IsAlive = false;
            grid.Cells[1, 1].IsAlive = false;
            grid.Cells[1, 2].IsAlive = false;
            grid.Cells[1, 3].IsAlive = false;
            grid.Cells[1, 4].IsAlive = false;

            grid.Cells[2, 0].IsAlive = false;
            grid.Cells[2, 1].IsAlive = true;
            grid.Cells[2, 2].IsAlive = true;
            grid.Cells[2, 3].IsAlive = true;
            grid.Cells[2, 4].IsAlive = false;

            grid.Cells[3, 0].IsAlive = false;
            grid.Cells[3, 1].IsAlive = false;
            grid.Cells[3, 2].IsAlive = false;
            grid.Cells[3, 3].IsAlive = false;
            grid.Cells[3, 4].IsAlive = false;

            // Act
            grid.NextGeneration();

            // Assert
            Assert.False(grid.Cells[0, 0].IsAlive);
            Assert.False(grid.Cells[0, 1].IsAlive);
            Assert.False(grid.Cells[0, 2].IsAlive);
            Assert.False(grid.Cells[0, 3].IsAlive);
            Assert.False(grid.Cells[0, 4].IsAlive);

            Assert.False(grid.Cells[1, 0].IsAlive);
            Assert.False(grid.Cells[1, 1].IsAlive);
            Assert.True(grid.Cells[1, 2].IsAlive);
            Assert.False(grid.Cells[1, 3].IsAlive);
            Assert.False(grid.Cells[1, 4].IsAlive);

            Assert.False(grid.Cells[2, 0].IsAlive);
            Assert.False(grid.Cells[2, 1].IsAlive);
            Assert.True(grid.Cells[2, 2].IsAlive);
            Assert.False(grid.Cells[2, 3].IsAlive);
            Assert.False(grid.Cells[2, 4].IsAlive);

            Assert.False(grid.Cells[3, 0].IsAlive);
            Assert.False(grid.Cells[3, 1].IsAlive);
            Assert.True(grid.Cells[3, 2].IsAlive);
            Assert.False(grid.Cells[3, 3].IsAlive);
            Assert.False(grid.Cells[3, 4].IsAlive);
        }

    }
}
