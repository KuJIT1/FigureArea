using Mindbox.FigureCalculator.Calculators;
using Mindbox.FigureCalculator.Figures;
using Mindbox.FigureCalculator.Operations;
using System.Reflection;

namespace Mindbox.FigureCalculator
{
    public class Calculator
    {
        private readonly static Dictionary<Type, Type> _calculators = new();


        private readonly static MethodInfo CalculateGenericMethod 
            = typeof(Calculator).GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .First(m => m.Name == nameof(Calculate) && m.ContainsGenericParameters)!;

        public static void RegisterFigureOperation<TCalculator, TFigure, TOperation>()
            where TCalculator : OperationCalculator<TFigure, TOperation>, new()
        {
            // Можно было бы регистрировать несколько калькуляторов операций и проверять их
            // применимость (например, если треугольник прямоугольный, то использовать один вычислитель, иначе - другой)

            _calculators[typeof(OperationCalculator<TFigure, TOperation>)] = typeof(TCalculator);
        }

        static Calculator()
        {
            RegisterFigureOperation<CircleAreaCalculator, Circle, Area>();
            RegisterFigureOperation<TringleAreaCalculator, Triangle, Area>();
        }

        public TOperation Calculate<TFigure, TOperation>(TFigure figure)
        {
            var operationCalculator = this.GetOperationCalculator<TFigure, TOperation>();
            return operationCalculator.Calculate(figure);
        }

        public Toperation Calculate<Toperation>(object figure)
        {
            return (Toperation)CalculateGenericMethod.MakeGenericMethod(typeof(Toperation), figure.GetType())
                .Invoke(this, [figure])!;
        }

        private OperationCalculator<TFigure, TOperation> GetOperationCalculator<TFigure, TOperation>()
        {
            // TODO: можно кэшировать калькуляторы операций в рамках инстанса или в рамках контейнера _calculators
            // TODO: подумать о наследовании фигур
            
            if (_calculators.TryGetValue(typeof(OperationCalculator<TFigure, TOperation>), out var operationCalculatorType))
            {
                return (OperationCalculator<TFigure, TOperation>)Activator.CreateInstance(operationCalculatorType)!;
            }

            throw new ArgumentException($"Не найден вычислитель операции {typeof(TOperation).Name} для фигуры {typeof(TFigure).Name}");
        }
    }
}
