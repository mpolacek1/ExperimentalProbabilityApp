using System;

namespace ExperimentalProbability.Calculation.Models
{
    public class CalculationResultData
    {
        public int SimulationsRun { get; set; } = 0;

        public int ConditionsMet { get; set; } = 0;

        public double Probability { get => GetProbability(); }

        public double GetProbability()
        {
            return Math.Round(Convert.ToSingle(ConditionsMet) / Convert.ToSingle(SimulationsRun) * 100, 2);
        }
    }
}