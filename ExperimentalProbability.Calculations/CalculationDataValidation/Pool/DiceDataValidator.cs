using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Models.Pool;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.Dice;

namespace ExperimentalProbability.Calculations.CalculationDataValidation.Pool
{
    public class DiceDataValidator : BasePoolCalculationDataValidator
    {
        protected override void ValidatePoolData(CalculationData data)
        {
            ValidateNumber(
                ((DiceCalculationData)data).SideCount,
                (int)DiceNumbers.SideCountTetrahedron,
                (int)DiceNumbers.SideCountIcosahedron,
                Resources.ElementName_Dice);
        }

        protected override void ValidateConditionData(CalculationData data)
        {
            var calcData = (DiceCalculationData)data;

            ValidateNumber(
                calcData.ConditionSides.Length,
                (int)DiceNumbers.MinNumberOfRolls,
                (int)DiceNumbers.MaxNumberOfRolls,
                Resources.ElementName_NumberOfRolls);

            ValidateConditionSides(calcData);
        }

        private void ValidateConditionSides(DiceCalculationData data)
        {
            var conditionSides = data.ConditionSides;

            for (int i = default; i < conditionSides.Length; i++)
            {
                ValidateNumber(
                    conditionSides[i],
                    (int)DiceNumbers.MinRollResult,
                    data.SideCount,
                    AppendNumberPositionToString(i, Resources.ElementName_Roll));
            }
        }
    }
}
