using ExperimentalProbability.Calculations.Validation;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Properties.Resources;
using ExperimentalProbability.Contracts.Properties.Resources.Validation.BaseCalculationData;

namespace ExperimentalProbability.Calculation.Validation.Pool
{
    public abstract class BasePoolCalculationDataValidator : BaseCalculationDataValidator
    {
        public override void Validate(CalculationData data)
        {
            ValidateNumber(data.SimulationsToRun, IntegerResources.MIN_SIMULATIONS, IntegerResources.MAX_SIMULATIONS, Resources.ElementName_Simulations);
            ValidateTypeData(data);
            ValidateConditionData(data);
        }

        protected abstract void ValidateTypeData(CalculationData data);

        protected abstract void ValidateConditionData(CalculationData data);
    }
}
