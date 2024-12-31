namespace backend.Models
{
    public class UserInput
    {
        public bool UsingOwnEggs { get; set; }
        public bool PreviouslyAttemptedIVF { get; set; }
        public bool ReasonForInfertilityKnown { get; set; }
        public int Age { get; set; }
        public double WeightInLbs { get; set; }
        public double WeightInKg { get; set; }
        public int Feet { get; set; }
        public double Inches { get; set; }
        public double HeightInCm { get; set; }
        public double BMI => CalculateBMI();
        private double CalculateBMI()
        {
            double heightInInches = UsingMetric
                ? HeightInCm / 2.54
                : (Feet * 12) + Inches;

            if (WeightInLbs > 0 && heightInInches > 0)
            {
                return Math.Round(WeightInLbs / Math.Pow(heightInInches, 2) * 703, 2);
            }
            return 0;
        }
        public bool TubalFactor { get; set; }
        public bool MaleFactorInfertility { get; set; }
        public bool Endometriosis { get; set; }
        public bool OvulatoryDisorder { get; set; }
        public bool DiminishedOvarianReserve { get; set; }
        public bool UterineFactor { get; set; }
        public bool OtherReason { get; set; }
        public bool UnexplainedInfertility { get; set; }
        public int Gravida { get; set; }
        public int PriorLiveBirths { get; set; }
        public bool UsingMetric { get; set; }


    }
}
