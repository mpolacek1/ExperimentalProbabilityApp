using ExperimentalProbability.Calculations.CalculationDataValidation;
using ExperimentalProbability.Contracts.Extensions;
using ExperimentalProbability.Contracts.Models;
using System;
using System.ComponentModel;

namespace ExperimentalProbability.Calculations.Calculations.TwoDPlane
{
    public class AreaCalculation : BaseCalculation
    {
        private const double MIN_X_VALUE = -5;

        private const double MAX_X_VALUE = 5;

        private const double MIN_Y_VALUE = -20;

        private const double MAX_Y_VALUE = 20;

        private const decimal BORDER_OBJECT_AREA = 400;

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

            if ((Math.Pow(points[0], 2) - 4) * Math.Sin(points[0]) >= points[1])
            {
                return true;
            }

            return false;
        }

        protected override object GetSimulationResult(CalculationData data, Random random)
        {
            return new double[2]
            {
                random.NextDouble(MIN_X_VALUE, MAX_X_VALUE),
                random.NextDouble(MIN_Y_VALUE, MAX_Y_VALUE),
            };
        }
    }
}
