using BPCalculator.Pages;
using Xunit;

namespace BPCalculator.UnitTests
{
    public class BloodPressureModelTests
    {
        [Fact]
        public void BloodPressureModel_OnGet_initialises_BP()
        {
            //Arrange
            var bpModel = new BloodPressureModel();

            //Act
            bpModel.OnGet();

            //Assert
            Assert.NotNull(bpModel.BP);
            Assert.Equal(100, bpModel.BP.Systolic);
            Assert.Equal(60, bpModel.BP.Diastolic);
        }

        [Fact]
        public void BloodPressureModel_OnPost_with_valid_input_returns_not_null()
        {
            //Arrange
            var bpModel = new BloodPressureModel
            {
                BP = new BloodPressure
                {
                    Systolic = 120,
                    Diastolic = 80
                }
            };

            //Act
            var result = bpModel.OnPost();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void BloodPressureModel_OnPost_with_invalid_input_returns_not_null()
        {
            //Arrange
            var bpModel = new BloodPressureModel
            {
                BP = new BloodPressure
                {
                    Diastolic = 120,
                    Systolic = 80
                }
            };

            //Act
            var result = bpModel.OnPost();

            //Assert
            Assert.NotNull(result);
        }
    }
}
