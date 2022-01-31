using System.Collections.Generic;

namespace ExperimentalProbability.Calculations.Models
{
    public class CalculationData
    {
        public CalculationData(TypeSettings typeSettings, List<string> conditionSettings, int simulationsToRun)
        {
            TypeSettings = typeSettings;
            ConditionSettings = conditionSettings;
            SimulationsToRun = simulationsToRun;
        }

        public TypeSettings TypeSettings { get; set; }

        public object ConditionSettings { get; set; }

        public int SimulationsToRun { get; set; }
    }
}