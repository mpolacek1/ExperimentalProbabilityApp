using ExperimentalProbability.Calculations.CalculationDataValidation;
using ExperimentalProbability.Contracts.Models;
using System;
using System.ComponentModel;

namespace ExperimentalProbability.Calculations.Calculations.TwoDPlane
{
    public class PiCalculation : BaseCalculation
    {
        public PiCalculation(BackgroundWorker worker)
            : base(new CalculationDataValidator(), worker)
        {
        }

        public override decimal CalculateResult(CalculationResultData data)
        {
            return Convert.ToDecimal(data.ConditionMet) / Convert.ToDecimal(data.SimulationsRan) * 4;
        }

        protected override bool CheckCondition(CalculationData data, object simResult)
        {
            var result = default(double);
            var points = (double[])simResult;

            for (int i = default; i < points.Length; i++)
            {
                result += Math.Pow(points[i], 2);
            }

            return result <= 1;
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
