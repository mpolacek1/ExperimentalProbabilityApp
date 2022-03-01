﻿using ExperimentalProbability.Calculation.Models;
using System.Collections.Generic;
using ExperimentalProbability.Contracts.Utilities;
using LocalResx = ExperimentalProbability.Contracts.Properties.DiceResources;

namespace ExperimentalProbability.Calculation.Validation
{
    public class DiceValidator : BaseCalculationValidator
    {
        private const int _minSides = 4;

        private const int _maxSides = 20;

        private const int _minRolls = 1;

        private const int _maxRolls = 10;

        private const int _minRollCount = 1;

        private const int _minRollResult = 1;

        protected override void ValidateTypeData(CalculationData data)
        {
            ValidateNumber(data.TypeData.NumberOf, _minSides, _maxSides, LocalResx.ElementName_DiceType);
        }

        protected override void ValidateConditionData(CalculationData data)
        {
            ValidateNumber(data.ConditionData.NumberOf, _minRolls, _maxRolls, LocalResx.ElementName_DiceRolls);
            ValidateNumber(((List<int>)data.ConditionData.Items).Count, _minRollCount, data.ConditionData.NumberOf, LocalResx.ElementName_DiceRollsResults);
            ValidateConditionItems(data);
        }

        private void ValidateConditionItems(CalculationData data)
        {
            var items = (List<int>)data.ConditionData.Items;

            for (int i = 0; i < items.Count; i++)
            {
                ValidateNumber(items[i], _minRollResult, data.TypeData.NumberOf, $"{NumberTranslater.NumberToPosition[i]} {LocalResx.ElementName_DiceRoll}");
            }
        }
    }
}