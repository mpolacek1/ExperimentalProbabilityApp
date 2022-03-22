using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Properties.Resources;
using ExperimentalProbability.Contracts.Properties.Resources.Validation.BaseCalculationData;

namespace ExperimentalProbability.Calculations.Validation.Calculations.TwoDPlane
{
    public abstract class BaseTwoDPlaneCalculationDataValidator : BaseCalculationDataValidator
    {
        public override void Validate(CalculationData data)
        {
            ValidateNumber(data.SimulationsToRun, IntegerResources.MIN_SIMULATIONS, IntegerResources.MAX_SIMULATIONS, Resources.ElementName_Simulations);
        }
    }
}
