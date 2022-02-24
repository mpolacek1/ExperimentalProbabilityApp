using ExperimentalProbability.Calculations.Interfaces;
using ExperimentalProbability.Calculation.Models;
using System.Collections.Generic;

namespace ExperimentalProbability.Calculations.Types
{
    public class DiceCalculation : ICalculationType
    {
        private const int _maxSims = 100000000;

        private const int _minSims = 1000;

        private const int _maxSides = 20;

        private const int _minSides = 4;

        private const int _maxItems = 10;

        private const int _minItems = 1;

        public DiceCalculation(CalculationData data)
        {
            Data = data;
        }

        private CalculationData Data { get; set; }

        private CalculationResultData ResultData { get; set; } = new CalculationResultData();

        public CalculationResultData Calculate()
        {
            if (!ValidateData(Data))
            {
                var item = 0;
            }

            return ResultData;
        }

        public bool ValidateData(CalculationData data)
        {
            return ValidateTypeData(data.TypeData)
                && ValidateConditionData(data.ConditionData)
                && ValidateInteger(data.SimulationsToRun, _minSims, _maxSims);
        }

        public bool ValidateTypeData(BasicData data)
        {
            return ValidateInteger(data.NumberOf, _minSides, _maxSides)
                && data.Items == null;
        }

        public bool ValidateConditionData(BasicData data)
        {
            return ValidateInteger(data.NumberOf, _minItems, _maxItems)
                && ValidateInteger(((List<int>)data.Items).Count, _minItems, data.NumberOf)
                && ValidateConditionItems((List<int>)data.Items);
        }

        public bool ValidateInteger(int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        private bool ValidateConditionItems(List<int> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (!ValidateInteger(collection[i], _minItems, Data.TypeData.NumberOf))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
