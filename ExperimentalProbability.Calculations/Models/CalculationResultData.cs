using System;

namespace ExperimentalProbability.Calculation.Models
{
    public class CalculationResultData
    {
        public int SimulationsRun { get; set; } = 0;

        public int ConditionMet { get; set; } = 0;

        public decimal Probability => GetProbability();

        public decimal GetProbability()
        {
            return Math.Round(Convert.ToDecimal(ConditionMet) / Convert.ToDecimal(SimulationsRun), 5);
        }
    }
}