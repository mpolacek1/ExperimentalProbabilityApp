using ExperimentalProbability.Contracts.Models;

namespace ExperimentalProbability.Calculations.CalculationDataValidation.Pool
{
    public abstract class BasePoolCalculationDataValidator : BaseCalculationDataValidator
    {
        public override void Validate(CalculationData data)
        {
            base.Validate(data);
            ValidatePoolData(data);
            ValidateConditionData(data);
        }

        protected abstract void ValidatePoolData(CalculationData data);

        protected abstract void ValidateConditionData(CalculationData data);
    }
}
