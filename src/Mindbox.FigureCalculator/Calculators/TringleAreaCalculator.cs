using Mindbox.FigureCalculator.Figures;
using Mindbox.FigureCalculator.Operations;

namespace Mindbox.FigureCalculator.Calculators
{
    internal class TringleAreaCalculator : OperationCalculator<Triangle, Area>
    {
        private Area getBaseTriangleArea(Triangle figure)
        {
            // Если треугольник не валидировали, тут может упасть ошибка извлечения корня из отрицательного числа
            var p = (double)(figure.SideA + figure.SideB + figure.SideC) / 2;
            return new Area() { Value = Math.Sqrt(p * (p - figure.SideA) * (p - figure.SideB) * (p - figure.SideC)) };
        }

        private Area getRightTriangleArea(Triangle figure)
        {
            var sides = this.getSortedTriangleSides(figure);
            return new Area { Value = (double)(sides[0] * sides[1]) / 2 };
        }

        private bool isTriangleRight(Triangle figure)
        {
            var sides = this.getSortedTriangleSides(figure);
            return sides[0] * sides[0] + sides[1] * sides[1] == sides[2] * sides[2];
        }

        private int[] getSortedTriangleSides(Triangle figure)
        {
            var sides = new int[3] { figure.SideA, figure.SideB, figure.SideC };
            Array.Sort(sides);
            return sides;
        }

        protected override Area InternalCalculate(Triangle figure)
        {
            if (this.isTriangleRight(figure))
            {
                return this.getRightTriangleArea(figure);
            }

            return this.getBaseTriangleArea(figure);
        }

        protected override void Validate(Triangle figure)
        {
            ArgumentNullException.ThrowIfNull(figure, nameof(figure));
            var sides = this.getSortedTriangleSides(figure);
            foreach( var side in sides)
            {
                if (side <= 0)
                {
                    throw new ArgumentException($"Стороны треугольника должны быть больше нуля");
                }
            }
            if (sides[0] + sides[1] <= sides[2])
            {
                throw new ArgumentException(
                    $"Сумма длин двух сторон треугольника должна быть больше" +
                    $" длины третьей стороны: {sides[0]} + {sides[1]} <= {sides[2]}");
            }
        }
    }
}
