using Xunit;

namespace BPCalculator.UnitTests
{
    public class BPCalculatorTests
    {
        [Fact]
        public void BloodPressure_with_90_Systolic_and_60_Diastolic_returns_Category_Low()
        {
            //Arrange
            var bp = new BloodPressure
            {
                Systolic = 90,
                Diastolic = 60
            };

            //Act

            //Assert
            Assert.Equal(BPCategory.Low, bp.Category);
        }

        [Fact]
        public void BloodPressure_with_120_Systolic_and_80_Diastolic_returns_Category_Ideal()
        {
            //Arrange
            var bp = new BloodPressure
            {
                Systolic = 120,
                Diastolic = 80
            };

            //Act

            //Assert
            Assert.Equal(BPCategory.Ideal, bp.Category);
        }

        [Fact]
        public void BloodPressure_with_140_Systolic_and_90_Diastolic_returns_Category_PreHigh()
        {
            //Arrange
            var bp = new BloodPressure
            {
                Systolic = 140,
                Diastolic = 90
            };

            //Act

            //Assert
            Assert.Equal(BPCategory.PreHigh, bp.Category);
        }

        [Fact]
        public void BloodPressure_with_190_Systolic_and_100_Diastolic_returns_Category_High()
        {
            //Arrange
            var bp = new BloodPressure
            {
                Systolic = 190,
                Diastolic = 100
            };

            //Act

            //Assert
            Assert.Equal(BPCategory.High, bp.Category);
        }
    }
}
