using ExperimentalProbability.Calculation.Models;

namespace ExperimentalProbability.Calculations.Interfaces
{
    public interface ICalculationType
    {
        CalculationResultData Calculate();

        bool ValidateData(CalculationData data);

        bool ValidateTypeData(BasicData data);

        bool ValidateConditionData(BasicData data);

        bool ValidateInteger(int value, int minVale, int maxValue);
    }
}
