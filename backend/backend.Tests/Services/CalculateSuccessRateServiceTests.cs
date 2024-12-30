using backend.Models;
using backend.Services;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Hosting;

public class CalculateSuccessRateServiceTests
{
    private readonly Mock<ICSVReaderService> _mockCSVReader;
    private readonly Mock<IWebHostEnvironment> _mockEnv;
    private readonly CalculateSuccessRateService _service;

    public CalculateSuccessRateServiceTests()
    {
        _mockCSVReader = new Mock<ICSVReaderService>();
        _mockEnv = new Mock<IWebHostEnvironment>();
        _service = new CalculateSuccessRateService(_mockCSVReader.Object, _mockEnv.Object);

        _mockEnv.Setup(env => env.ContentRootPath).Returns("some/fake/path");

        var formulaRows = new List<FileInput>
        {
            new()
            {
                ParamUsingOwnEggs = "TRUE",
                ParamAttemptedIVFPreviously = "FALSE",
                ParamIsReasonForInfertilityKnown = "TRUE",
                CDCFormula = "1-3",
                FormulaIntercept = -6.8392144,
                FormulaAgeLinearCoefficient = 0.3347309,
                FormulaAgePowerCoefficient = -0.0003249,
                FormulaAgePowerFactor = 2.763313,
                FormulaBMILinearCoefficient = 0.06997997,
                FormulaBMIPowerCoefficient = -0.0015045,
                FormulaBMIPowerFactor = 2,
                FormulaTubalFactorTrueValue = 0.09373152,
                FormulaTubalFactorFalseValue = 0,
                FormulaMaleFactorInfertilityTrueValue = 0.24104423,
                FormulaMaleFactorInfertilityFalseValue = 0,
                FormulaEndometriosisTrueValue = 0.02773216,
                FormulaEndometriosisFalseValue = 0,
                FormulaOvulatoryDisorderTrueValue = 0.27949598,
                FormulaOvulatoryDisorderFalseValue = 0,
                FormulaDiminishedOvarianReserveTrueValue = -0.5780511,
                FormulaDiminishedOvarianReserveFalseValue = 0,
                FormulaUterineFactorTrueValue = -0.1354896,
                FormulaUterineFactorFalseValue = 0,
                FormulaOtherReasonTrueValue = -0.1018557,
                FormulaOtherReasonFalseValue = 0,
                FormulaUnexplainedInfertilityTrueValue = 0.2252616,
                FormulaUnexplainedInfertilityFalseValue = 0,
                FormulaPriorPregnancies0Value = 0,
                FormulaPriorPregnancies1Value = 0.03514055,
                FormulaPriorPregnancies2PlusValue = -0.0059006,
                FormulaPriorLiveBirths0Value = 0,
                FormulaPriorLiveBirths1Value = 0.15787934,
                FormulaPriorLiveBirths2PlusValue = 0.03077479
            },
            new()
            {
                ParamUsingOwnEggs = "TRUE",
                ParamAttemptedIVFPreviously = "FALSE",
                ParamIsReasonForInfertilityKnown = "FALSE",
                CDCFormula = "4-6",
                FormulaIntercept = -7.5545223,
                FormulaAgeLinearCoefficient = 0.37931798,
                FormulaAgePowerCoefficient = -0.0003752,
                FormulaAgePowerFactor = 2.763313,
                FormulaBMILinearCoefficient = 0.08057661,
                FormulaBMIPowerCoefficient = -0.0015304,
                FormulaBMIPowerFactor = 2,
                FormulaTubalFactorTrueValue = 0.09373152,
                FormulaTubalFactorFalseValue = 0,
                FormulaMaleFactorInfertilityTrueValue = 0,
                FormulaMaleFactorInfertilityFalseValue = 0,
                FormulaEndometriosisTrueValue = 0,
                FormulaEndometriosisFalseValue = 0,
                FormulaOvulatoryDisorderTrueValue = 0,
                FormulaOvulatoryDisorderFalseValue = 0,
                FormulaDiminishedOvarianReserveTrueValue = 0,
                FormulaDiminishedOvarianReserveFalseValue = 0,
                FormulaUterineFactorTrueValue = 0,
                FormulaUterineFactorFalseValue = 0,
                FormulaOtherReasonTrueValue = 0,
                FormulaOtherReasonFalseValue = 0,
                FormulaUnexplainedInfertilityTrueValue = 0,
                FormulaUnexplainedInfertilityFalseValue = 0,
                FormulaPriorPregnancies0Value = 0,
                FormulaPriorPregnancies1Value = 0.02240271,
                FormulaPriorPregnancies2PlusValue = -0.054699,
                FormulaPriorLiveBirths0Value = 0,
                FormulaPriorLiveBirths1Value = 0.16421628,
                FormulaPriorLiveBirths2PlusValue = 0.05435658
            },
            new()
            {
                ParamUsingOwnEggs = "TRUE",
                ParamAttemptedIVFPreviously = "TRUE",
                ParamIsReasonForInfertilityKnown = "TRUE",
                CDCFormula = "7-8",
                FormulaIntercept = -8.102508,
                FormulaAgeLinearCoefficient = 0.37506646,
                FormulaAgePowerCoefficient = -0.0003171,
                FormulaAgePowerFactor = 2.784619,
                FormulaBMILinearCoefficient = 0.04565965,
                FormulaBMIPowerCoefficient = -0.0008793,
                FormulaBMIPowerFactor = 2,
                FormulaTubalFactorTrueValue = 0.06858044,
                FormulaTubalFactorFalseValue = 0,
                FormulaMaleFactorInfertilityTrueValue = 0.23958731,
                FormulaMaleFactorInfertilityFalseValue = 0,
                FormulaEndometriosisTrueValue = -0.0128023,
                FormulaEndometriosisFalseValue = 0,
                FormulaOvulatoryDisorderTrueValue = 0.27559287,
                FormulaOvulatoryDisorderFalseValue = 0,
                FormulaDiminishedOvarianReserveTrueValue = -0.4806452,
                FormulaDiminishedOvarianReserveFalseValue = 0,
                FormulaUterineFactorTrueValue = -0.1649105,
                FormulaUterineFactorFalseValue = 0,
                FormulaOtherReasonTrueValue = -0.0770044,
                FormulaOtherReasonFalseValue = 0,
                FormulaUnexplainedInfertilityTrueValue = 0.18150326,
                FormulaUnexplainedInfertilityFalseValue = 0,
                FormulaPriorPregnancies0Value = 0,
                FormulaPriorPregnancies1Value = 0.15884291,
                FormulaPriorPregnancies2PlusValue = 0.16420575,
                FormulaPriorLiveBirths0Value = 0,
                FormulaPriorLiveBirths1Value = 0.32698183,
                FormulaPriorLiveBirths2PlusValue = 0.21325721
            }
        };

        _mockCSVReader.Setup(reader => reader.ReadCSVFileAsync(It.IsAny<string>())).ReturnsAsync(formulaRows);

    }

    [Fact]
    public async Task CalculateIVFSuccessRate_ShouldReturnCorrectSuccessRate_UsingOwnEggs_DidNotPreviouslyAttemptIVF_KnownInfertilityReason()
    {
        var userInput = new UserInput
        {
            UsingOwnEggs = true,
            PreviouslyAttemptedIVF = false,
            ReasonForInfertilityKnown = true,
            Age = 32,
            Feet = 5,
            Inches = 4,
            WeightInLbs = 130,
            TubalFactor = false,
            MaleFactorInfertility = false,
            Endometriosis = true,
            OvulatoryDisorder = true,
            DiminishedOvarianReserve = false,
            UterineFactor = false,
            OtherReason = false,
            UnexplainedInfertility = false,
            Gravida = 1,
            PriorLiveBirths = 1
        };

        var result = await _service.CalculateIVFSuccessRate(userInput);

        var expectedSuccessRate = 62.21;
        Assert.Equal((int)expectedSuccessRate, result);
    }

    [Fact]
    public async Task CalculateIVFSuccessRate_ShouldReturnCorrectSuccessRate_UsingOwnEggs_DidNotPreviouslyAttemptIVF_UnknownInfertilityReason()
    {
        var userInput = new UserInput
        {
            UsingOwnEggs = true,
            PreviouslyAttemptedIVF = false,
            ReasonForInfertilityKnown = false,
            Age = 32,
            Feet = 5,
            Inches = 4,
            WeightInLbs = 130,
            TubalFactor = false,
            MaleFactorInfertility = false,
            Endometriosis = false,
            OvulatoryDisorder = false,
            DiminishedOvarianReserve = false,
            UterineFactor = false,
            OtherReason = false,
            UnexplainedInfertility = false,
            Gravida = 1,
            PriorLiveBirths = 1
        };

        var result = await _service.CalculateIVFSuccessRate(userInput);

        var expectedSuccessRate = 59.83;
        Assert.Equal((int)expectedSuccessRate, result);
    }

    [Fact]
    public async Task CalculateIVFSuccessRate_ShouldReturnCorrectSuccessRate_UsingOwnEggs_PreviouslyAttemptedIVF_KnownInfertilityReason()
    {
        var userInput = new UserInput
        {
            UsingOwnEggs = true,
            PreviouslyAttemptedIVF = true,
            ReasonForInfertilityKnown = true,
            Age = 32,
            Feet = 5,
            Inches = 4,
            WeightInLbs = 130,
            TubalFactor = true,
            MaleFactorInfertility = false,
            Endometriosis = false,
            OvulatoryDisorder = false,
            DiminishedOvarianReserve = true,
            UterineFactor = false,
            OtherReason = false,
            UnexplainedInfertility = false,
            Gravida = 1,
            PriorLiveBirths = 1
        };

        var result = await _service.CalculateIVFSuccessRate(userInput);

        var expectedSuccessRate = 40.89;
        Assert.Equal((int)expectedSuccessRate, result);
    }
}
