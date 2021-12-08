using System;
using TechTalk.SpecFlow;
using Xunit;

namespace BPCalculator.BDDTests
{
    [Binding]
    public class CalculateBloodPressureFeature
    {
        private int _systolic;
        private int _diastolic;
        private BPCategory _bpCategory;

        [Given("a patient with blood pressure readings of (.*) mm Hg systolic and (.*) mm Hg diastolic")]
        public void GivenAPatientWithBloodPressureReadingsOfSystolicMmHgSystolicAndDiastolicMmHgDiastolic(int systolic, int diastolic)
        {
            _systolic = systolic;
            _diastolic = diastolic;
        }

        [When("I request the blood pressure calculation")]
        public void WhenIRequestTheBloodPressureCalculation()
        {
            var bpCalculator = new BloodPressure
            {
                Systolic = _systolic,
                Diastolic = _diastolic
            };

            _bpCategory = bpCalculator.Category;
        }

        [Then("the blood pressure is considered (.*)")]
        public void ThenTheBloodPressureIsConsideredCategory(string category)
        {
            Enum.TryParse(category, out BPCategory bpCategory);

            Assert.Equal(bpCategory, _bpCategory);
        }
    }
}