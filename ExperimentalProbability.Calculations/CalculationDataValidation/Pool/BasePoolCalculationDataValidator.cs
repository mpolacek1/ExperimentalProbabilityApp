using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Utilities;

namespace ExperimentalProbability.Calculations.CalculationDataValidation.Pool
{
    public abstract class BasePoolCalculationDataValidator : CalculationDataValidator
    {
        public override void Validate(CalculationData data)
        {
            base.Validate(data);
            ValidatePoolData(data);
            ValidateConditionData(data);
        }

        protected abstract void ValidatePoolData(CalculationData data);

        protected abstract void ValidateConditionData(CalculationData data);

        protected string AppendNumberPositionToString(int index, string elementName)
        {
            return string.Concat(NumberTranslater.NumberToPosition[index], ' ', elementName);
        }
    }
}
