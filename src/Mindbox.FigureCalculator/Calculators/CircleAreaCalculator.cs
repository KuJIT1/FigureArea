using Mindbox.FigureCalculator.Figures;
using Mindbox.FigureCalculator.Operations;
using System.Runtime.ExceptionServices;

namespace Mindbox.FigureCalculator.Calculators
{
    internal class CircleAreaCalculator : OperationCalculator<Circle, Area>
    {
        protected override Area InternalCalculate(Circle figure)
        {
            return new Area { Value = Math.PI * figure.Radius * figure.Radius };
        }

        protected override void Validate(Circle figure)
        {
            ArgumentNullException.ThrowIfNull(figure, nameof(figure));
            if (figure.Radius <= 0)
            {
                throw new ArgumentException($"Некорректные радиус круга: {figure.Radius}");
            }
        }
    }
}
