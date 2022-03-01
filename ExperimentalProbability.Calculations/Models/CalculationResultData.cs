using System;

namespace ExperimentalProbability.Calculation.Models
{
    public class CalculationResultData
    {
        public int SimulationsRun { get; set; } = 0;

        public int ConditionsMet { get; set; } = 0;

        public double Probability => GetProbability();

        public double GetProbability()
        {
            return Math.Round(Convert.ToDouble(ConditionsMet) / Convert.ToDouble(SimulationsRun), 4);
        }
    }
}