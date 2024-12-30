namespace backend.Models
{
    public class UserInput
    {
        public bool UsingOwnEggs { get; set; }
        public bool PreviouslyAttemptedIVF { get; set; }
        public bool ReasonForInfertilityKnown { get; set; }
        public int Age { get; set; }
        private double _weightInLbs;
        private double _weightInKg;
        public double WeightInLbs
        {
            get => _weightInLbs;
            set
            {
                _weightInLbs = value;
                _weightInKg = LbsToKg(value);
            }
        }

        public double WeightInKg
        {
            get => _weightInKg;
            set
            {
                _weightInKg = value;
                _weightInLbs = KgToLbs(value);
            }
        }
        private double KgToLbs(double kg) => Math.Round(kg * 2.20462, 2);
        private double LbsToKg(double lbs) => Math.Round(lbs / 2.20462, 2);
        public int Feet { get; set; }
        public double Inches { get; set; }
        public double HeightInCm { get; set; }
        public double BMI => CalculateBMI();
        private double CalculateBMI()
        {
            double heightInInches = UsingMetric
                ? HeightInCm / 2.54
                : (Feet * 12) + Inches;

            if (_weightInLbs > 0 && heightInInches > 0)
            {
                return Math.Round(_weightInLbs / Math.Pow(heightInInches, 2) * 703, 2);
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
