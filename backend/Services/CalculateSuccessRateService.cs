using backend.Models;

namespace backend.Services
{
    public class CalculateSuccessRateService : ICalculateSuccessRateService
    {
        private readonly ICSVReaderService _csvReader;
        private readonly IWebHostEnvironment _env;

        public CalculateSuccessRateService(ICSVReaderService csvReader, IWebHostEnvironment env)
        {
            _csvReader = csvReader;
            _env = env;
        }

        public async Task<double> CalculateIVFSuccessRate(UserInput input)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Resources", "ivf_success_formulas.csv");
            var formulaRows = await _csvReader.ReadCSVFileAsync(filePath);

            var formulaRow = formulaRows
                .FirstOrDefault(row => row.ParamUsingOwnEggs == input.UsingOwnEggs.ToString().ToUpper() &&
                                       row.ParamAttemptedIVFPreviously == input.PreviouslyAttemptedIVF.ToString().ToUpper() &&
                                       row.ParamIsReasonForInfertilityKnown == input.ReasonForInfertilityKnown.ToString().ToUpper());

            if (formulaRow == null)
            {
                throw new Exception("Matching formula row not found for the given input.");
            }

            return CalculateSuccessRatePercentage(formulaRow, input);
        }

        private int CalculateSuccessRatePercentage(FileInput formulaRow, UserInput input)
        {
            double score = formulaRow.FormulaIntercept;

            var ageTerm = formulaRow.FormulaAgeLinearCoefficient * input.Age;
            var agePowerTerm = formulaRow.FormulaAgePowerCoefficient * Math.Pow(input.Age, formulaRow.FormulaAgePowerFactor);
            score += ageTerm + agePowerTerm;

            var bmiTerm = formulaRow.FormulaBMILinearCoefficient * input.BMI;
            var bmiPowerTerm = formulaRow.FormulaBMIPowerCoefficient * Math.Pow(input.BMI, formulaRow.FormulaBMIPowerFactor);
            score += bmiTerm + bmiPowerTerm;

            score += input.TubalFactor ? formulaRow.FormulaTubalFactorTrueValue : formulaRow.FormulaTubalFactorFalseValue;

            score += input.MaleFactorInfertility ? formulaRow.FormulaMaleFactorInfertilityTrueValue : formulaRow.FormulaMaleFactorInfertilityFalseValue;

            score += input.Endometriosis ? formulaRow.FormulaEndometriosisTrueValue : formulaRow.FormulaEndometriosisFalseValue;

            score += input.OvulatoryDisorder ? formulaRow.FormulaOvulatoryDisorderTrueValue : formulaRow.FormulaOvulatoryDisorderFalseValue;

            score += input.DiminishedOvarianReserve ? formulaRow.FormulaDiminishedOvarianReserveTrueValue : formulaRow.FormulaDiminishedOvarianReserveFalseValue;

            score += input.UterineFactor ? formulaRow.FormulaUterineFactorTrueValue : formulaRow.FormulaUterineFactorFalseValue;

            score += input.OtherReason ? formulaRow.FormulaOtherReasonTrueValue : formulaRow.FormulaOtherReasonFalseValue;

            score += input.UnexplainedInfertility ? formulaRow.FormulaUnexplainedInfertilityTrueValue : formulaRow.FormulaUnexplainedInfertilityFalseValue;

            var gravidaTerm = input.Gravida == 0 ? formulaRow.FormulaPriorPregnancies0Value :
                              input.Gravida == 1 ? formulaRow.FormulaPriorPregnancies1Value :
                              formulaRow.FormulaPriorPregnancies2PlusValue;
            score += gravidaTerm;

            var priorLiveBirthTerm = input.PriorLiveBirths == 0 ? formulaRow.FormulaPriorLiveBirths0Value :
                                     input.PriorLiveBirths == 1 ? formulaRow.FormulaPriorLiveBirths1Value :
                                     formulaRow.FormulaPriorLiveBirths2PlusValue;
            score += priorLiveBirthTerm;

            var successRate = Math.Exp(score) / (1 + Math.Exp(score));

            var roundedSuccessRate = Math.Round(successRate * 100, 2);

            return (int)roundedSuccessRate;
        }
    }
}
