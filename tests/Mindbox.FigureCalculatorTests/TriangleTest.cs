using Mindbox.FigureCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox.FigureCalculatorTests
{
    public class TriangleTest
    {
        [Fact]
        public void WithSides5_5_9AreaIs9_81()
        {
            var area = FigureArea.CalculateTriangleArea(5, 5, 9);
            Assert.Equal(9.81, area, 2);
        }

        [Fact]
        public void CheckByRightTriangleWithSides3_4_5AreaIs6()
        {
            // Этот тест, кажется, недостоверный. Не понятно как проверить проходку по нужной ветке кода,
            // кроме как добавление логов или типа того
            var area = FigureArea.CalculateTriangleArea(3, 4, 5);
            Assert.Equal(6, area, 0F);
        }

        [Fact]
        public void SidesValidationException1()
        {
            Assert.Throws<ArgumentException>(() => FigureArea.CalculateTriangleArea(3, 2, 6));
        }

        [Fact]
        public void SidesValidationException2()
        {
            Assert.Throws<ArgumentException>(() => FigureArea.CalculateTriangleArea(1, 0, 2));
        }
    }
}
