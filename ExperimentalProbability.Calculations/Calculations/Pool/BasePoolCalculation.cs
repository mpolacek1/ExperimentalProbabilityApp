using ExperimentalProbability.Calculations.CalculationDataValidation.Pool;
using ExperimentalProbability.Contracts.Models;
using System;
using System.ComponentModel;

namespace ExperimentalProbability.Calculations.Calculations.Pool
{
    public abstract class BasePoolCalculation : BaseCalculation
    {
        public BasePoolCalculation(BasePoolCalculationDataValidator validator, BackgroundWorker worker)
            : base(validator, worker)
        {
        }

        public override decimal CalculateResult(CalculationResultData data)
        {
            return Convert.ToDecimal(data.ConditionMet) / Convert.ToDecimal(data.SimulationsRan);
        }
    }
}
