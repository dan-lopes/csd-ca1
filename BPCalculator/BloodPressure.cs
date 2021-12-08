using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        private const int SystolicMin = 70;
        private const int SystolicMax = 190;
        private const int DiastolicMin = 40;
        private const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                if (Systolic <= 90 && Diastolic <= 60)
                {
                    return BPCategory.Low;
                }

                if(Systolic <= 120 && Diastolic <= 80)
                {
                    return BPCategory.Ideal;
                }

                if(Systolic <= 140 && Diastolic <= 90)
                {
                    return BPCategory.PreHigh;
                }

                return BPCategory.High;
            }
        }
    }
}
