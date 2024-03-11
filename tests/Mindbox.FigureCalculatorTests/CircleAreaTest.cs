using Mindbox.FigureCalculator;

namespace Mindbox.FigureCalculatorTests
{
    public class CircleAreaTest
    {
        [Fact]
        public void WithRadius2AreaIs12_57()
        {
            var circleArea = FigureArea.CalculateCircleArea(2);
            Assert.Equal(12.57, circleArea, 2);
        }

        [Fact]
        public void RadiusValidationException1()
        {
            Assert.Throws<ArgumentException>(() => FigureArea.CalculateCircleArea(-1));
        }

        [Fact]
        public void RadiusValidationException2()
        {
            Assert.Throws<ArgumentException>(() => FigureArea.CalculateCircleArea(0));
        }
    }
}
