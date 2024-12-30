using CsvHelper.Configuration;

public class FileInput
{
    public string ParamUsingOwnEggs { get; set; }
    public string ParamAttemptedIVFPreviously { get; set; }
    public string ParamIsReasonForInfertilityKnown { get; set; }
    public string CDCFormula { get; set; }
    public double FormulaIntercept { get; set; }
    public double FormulaAgeLinearCoefficient { get; set; }
    public double FormulaAgePowerCoefficient { get; set; }
    public double FormulaAgePowerFactor { get; set; }
    public double FormulaBMILinearCoefficient { get; set; }
    public double FormulaBMIPowerCoefficient { get; set; }
    public double FormulaBMIPowerFactor { get; set; }
    public double FormulaTubalFactorTrueValue { get; set; }
    public double FormulaTubalFactorFalseValue { get; set; }
    public double FormulaMaleFactorInfertilityTrueValue { get; set; }
    public double FormulaMaleFactorInfertilityFalseValue { get; set; }
    public double FormulaEndometriosisTrueValue { get; set; }
    public double FormulaEndometriosisFalseValue { get; set; }
    public double FormulaOvulatoryDisorderTrueValue { get; set; }
    public double FormulaOvulatoryDisorderFalseValue { get; set; }
    public double FormulaDiminishedOvarianReserveTrueValue { get; set; }
    public double FormulaDiminishedOvarianReserveFalseValue { get; set; }
    public double FormulaUterineFactorTrueValue { get; set; }
    public double FormulaUterineFactorFalseValue { get; set; }
    public double FormulaOtherReasonTrueValue { get; set; }
    public double FormulaOtherReasonFalseValue { get; set; }
    public double FormulaUnexplainedInfertilityTrueValue { get; set; }
    public double FormulaUnexplainedInfertilityFalseValue { get; set; }
    public double FormulaPriorPregnancies0Value { get; set; }
    public double FormulaPriorPregnancies1Value { get; set; }
    public double FormulaPriorPregnancies2PlusValue { get; set; }
    public double FormulaPriorLiveBirths0Value { get; set; }
    public double FormulaPriorLiveBirths1Value { get; set; }
    public double FormulaPriorLiveBirths2PlusValue { get; set; }
}


public sealed class FileInputMap : ClassMap<FileInput>
{
    public FileInputMap()
    {
        Map(m => m.ParamUsingOwnEggs).Name("param_using_own_eggs");
        Map(m => m.ParamAttemptedIVFPreviously).Name("param_attempted_ivf_previously");
        Map(m => m.ParamIsReasonForInfertilityKnown).Name("param_is_reason_for_infertility_known");
        Map(m => m.CDCFormula).Name("cdc_formula");
        Map(m => m.FormulaIntercept).Name("formula_intercept");
        Map(m => m.FormulaAgeLinearCoefficient).Name("formula_age_linear_coefficient");
        Map(m => m.FormulaAgePowerCoefficient).Name("formula_age_power_coefficient");
        Map(m => m.FormulaAgePowerFactor).Name("formula_age_power_factor");
        Map(m => m.FormulaBMILinearCoefficient).Name("formula_bmi_linear_coefficient");
        Map(m => m.FormulaBMIPowerCoefficient).Name("formula_bmi_power_coefficient");
        Map(m => m.FormulaBMIPowerFactor).Name("formula_bmi_power_factor");
        Map(m => m.FormulaTubalFactorTrueValue).Name("formula_tubal_factor_true_value");
        Map(m => m.FormulaTubalFactorFalseValue).Name("formula_tubal_factor_false_value");
        Map(m => m.FormulaMaleFactorInfertilityTrueValue).Name("formula_male_factor_infertility_true_value");
        Map(m => m.FormulaMaleFactorInfertilityFalseValue).Name("formula_male_factor_infertility_false_value");
        Map(m => m.FormulaEndometriosisTrueValue).Name("formula_endometriosis_true_value");
        Map(m => m.FormulaEndometriosisFalseValue).Name("formula_endometriosis_false_value");
        Map(m => m.FormulaOvulatoryDisorderTrueValue).Name("formula_ovulatory_disorder_true_value");
        Map(m => m.FormulaOvulatoryDisorderFalseValue).Name("formula_ovulatory_disorder_false_value");
        Map(m => m.FormulaDiminishedOvarianReserveTrueValue).Name("formula_diminished_ovarian_reserve_true_value");
        Map(m => m.FormulaDiminishedOvarianReserveFalseValue).Name("formula_diminished_ovarian_reserve_false_value");
        Map(m => m.FormulaUterineFactorTrueValue).Name("formula_uterine_factor_true_value");
        Map(m => m.FormulaUterineFactorFalseValue).Name("formula_uterine_factor_false_value");
        Map(m => m.FormulaOtherReasonTrueValue).Name("formula_other_reason_true_value");
        Map(m => m.FormulaOtherReasonFalseValue).Name("formula_other_reason_false_value");
        Map(m => m.FormulaUnexplainedInfertilityTrueValue).Name("formula_unexplained_infertility_true_value");
        Map(m => m.FormulaUnexplainedInfertilityFalseValue).Name("formula_unexplained_infertility_false_value");
        Map(m => m.FormulaPriorPregnancies0Value).Name("formula_prior_pregnancies_0_value");
        Map(m => m.FormulaPriorPregnancies1Value).Name("formula_prior_pregnancies_1_value");
        Map(m => m.FormulaPriorPregnancies2PlusValue).Name("formula_prior_pregnancies_2+_value");
        Map(m => m.FormulaPriorLiveBirths0Value).Name("formula_prior_live_births_0_value");
        Map(m => m.FormulaPriorLiveBirths1Value).Name("formula_prior_live_births_1_value");
        Map(m => m.FormulaPriorLiveBirths2PlusValue).Name("formula_prior_live_births_2+_value");
    }
}

