using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.Calculations.Interfaces;

namespace ExperimentalProbability.Calculations.Types
{
    public class ColoredBallsCalculation : ICalculationType
    {
        public ColoredBallsCalculation(CalculationData data)
        {
            Data = data;
        }

        private CalculationData Data { get; set; }

        private CalculationResultData ResultData { get; set; } = new CalculationResultData();

        public CalculationResultData Calculate()
        {
            if (!ValidateData(Data))
            {
            }

            return ResultData;
        }

        public bool ValidateData(CalculationData data)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateTypeData(BasicData data)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateConditionData(BasicData data)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateInteger(int value, int minVale, int maxValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
