using Mindbox.FigureCalculator.Figures;
using Mindbox.FigureCalculator.Operations;

namespace Mindbox.FigureCalculator
{
    public static class FigureArea
    {
        public static double CalculateCircleArea(int circleRadius)
        {
            return CalculateArea(new Circle { Radius = circleRadius });
        }

        public static double CalculateTriangleArea(int sideA, int sideB, int sideC)
        {
            return CalculateArea(new Triangle { SideA = sideA, SideB = sideB, SideC = sideC });
        }

        public static double CalculateArea<TFigure>(TFigure figure)
        {
            var area = Calculate<TFigure, Area>(figure);
            return area.Value;
        }

        // В общем-то, можно было сделать тот же финт с MakeGenericMetod на этом уровне для метода CalculateArea<TFigure>
        public static double CalculateArea(object figure)
        {
            var calculator = new Calculator();
            var area = calculator.Calculate<Area>(figure);
            return area.Value;
        }

        public static TOperation Calculate<TFigure, TOperation>(TFigure figure) 
        {
            var calculator = new Calculator();
            var operationResult = calculator.Calculate<TFigure, TOperation>(figure);
            return operationResult;
        }
    }
}
