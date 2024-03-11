
namespace Mindbox.FigureCalculator.Calculators
{
    abstract public class OperationCalculator<TFigure, TOperation>
    {

        public TOperation Calculate(TFigure figure)
        {
            this.Validate(figure);
            return this.InternalCalculate(figure);
        }

        abstract protected TOperation InternalCalculate(TFigure figure);

        virtual protected void Validate(TFigure figure)
        {
            throw new NotImplementedException();
        }
    }
}
