using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Properties.Resources;
using System.Collections.Generic;
using LocalResx = ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.ColoredBallsResources;

namespace ExperimentalProbability.Calculation.Validation.Pool
{
    public class ColoredBallsDataValidator : BasePoolCalculationDataValidator
    {
        private const int _minBalls = 2;

        private const int _maxBalls = 100;

        private const int _minColors = 2;

        private const int _maxColors = 10;

        private const int _minCount = 1;

        private const int _minTakenBalls = 1;

        private const int _maxTakenBalls = 10;

        protected override void ValidateTypeData(CalculationData data)
        {
            var numberOfBalls = ((Dictionary<string, int>)data.TypeData.NumberOf)["balls"];
            var numberOfColors = ((Dictionary<string, int>)data.TypeData.NumberOf)["colors"];

            ValidateNumber(numberOfBalls, _minBalls, _maxBalls, LocalResx.ElementName_NumberOfBalls);
            ValidateNumber(numberOfColors, _minColors, _maxColors, LocalResx.ElementName_NumberOfColors);
            ValidateAllowedMaxValue(new int[2] { numberOfBalls, numberOfColors }, new string[2] { LocalResx.ElementName_NumberOfBalls, LocalResx.ElementName_NumberOfColors });
            ValidateTypeItems(data.TypeData);
        }

        protected override void ValidateConditionData(CalculationData data)
        {
            var numberOfTakenBalls = (int)data.ConditionData.NumberOf;

            ValidateNumber(numberOfTakenBalls, _minTakenBalls, _maxTakenBalls, LocalResx.ElementName_NumberOfTakenBalls);
            ValidateAllowedMaxValue(new int[2] { ((Dictionary<string, int>)data.TypeData.NumberOf)["balls"], numberOfTakenBalls }, new string[2] { LocalResx.ElementName_NumberOfBalls, LocalResx.ElementName_NumberOfTakenBalls });
            ValidateConditionItems(data);
        }

        private void ValidateAllowedMaxValue(int[] values, string[] elementNames)
        {
            if (values[0] < values[1])
            {
                ThrowValidationException(elementNames[1], GeneralResources.Error_Number_Max, elementNames[0]);
            }
        }

        private void ValidateTypeItems(BasicData data)
        {
            var items = (List<Dictionary<string, object>>)data.Items;
            var countSum = 0;

            for (int i = 0; i < items.Count; i++)
            {
                var count = (int)items[i]["count"];

                ValidateColor(items[i]["color"], AppendNumberPositionToString(i, LocalResx.ElementName_PoolColor));
                ValidateNumber(count, _minCount, ((Dictionary<string, int>)data.NumberOf)["balls"] - 1, AppendNumberPositionToString(i, LocalResx.ElementName_ColorCount));

                countSum += count;
            }

            ValidateNumber(countSum, ((Dictionary<string, int>)data.NumberOf)["balls"], ((Dictionary<string, int>)data.NumberOf)["balls"], LocalResx.ElementName_ColorCountSum);
        }

        private void ValidateConditionItems(CalculationData data)
        {
            var items = (List<object>)data.ConditionData.Items;

            for (int i = 0; i < items.Count; i++)
            {
                ValidateColor(items[i], AppendNumberPositionToString(i, LocalResx.ElementName_ConditionColor));
            }
        }

        private void ValidateColor(object color, string elementName)
        {
            if (color.Equals(null))
            {
                ThrowValidationException(elementName, GeneralResources.Error_CannotBeEmpty);
            }
        }
    }
}
