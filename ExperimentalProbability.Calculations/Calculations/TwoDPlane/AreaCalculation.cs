using ExperimentalProbability.Calculations.CalculationDataValidation;
using ExperimentalProbability.Contracts.Extensions;
using ExperimentalProbability.Contracts.Models;
using System;
using System.ComponentModel;

namespace ExperimentalProbability.Calculations.Calculations.TwoDPlane
{
    public class AreaCalculation : BaseCalculation
    {
        private const decimal BORDER_OBJECT_AREA = 1;

        public AreaCalculation(BackgroundWorker worker)
            : base(new CalculationDataValidator(), worker)
        {
        }

        public override decimal CalculateResult(CalculationResultData data)
        {
            return BORDER_OBJECT_AREA * (Convert.ToDecimal(data.ConditionMet) / Convert.ToDecimal(data.SimulationsRan));
        }

        protected override bool CheckCondition(CalculationData data, object simResult)
        {
            var points = (double[])simResult;

            if (Math.Pow(points[0], 4) >= points[1])
            {
                return true;
            }

            return false;
        }

        protected override object GetSimulationResult(CalculationData data, Random random)
        {
            return new double[2]
            {
                random.NextDouble(),
                random.NextDouble(),
            };
        }
    }
}
