using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameOfLife.Tests
{
    public class CellTests
    {
        [Fact]
        public void Cell_Should_Initialize_With_IsAlive_Set()
        {
            // Arrange
            var cell = new Cell(true);

            // Act
            var isAlive = cell.IsAlive;

            // Assert
            Assert.True(isAlive);
        }

    }
}
