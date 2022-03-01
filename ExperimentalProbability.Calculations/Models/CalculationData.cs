using System.ComponentModel;

namespace ExperimentalProbability.Calculation.Models
{
    public class CalculationData
    {
        public CalculationData(BasicData typeData, BasicData conditionData, int simulationsToRun)
        {
            TypeData = typeData;
            ConditionData = conditionData;
            SimulationsToRun = simulationsToRun;
        }

        public BasicData TypeData { get; set; }

        public BasicData ConditionData { get; set; }

        public int SimulationsToRun { get; set; }
    }
}