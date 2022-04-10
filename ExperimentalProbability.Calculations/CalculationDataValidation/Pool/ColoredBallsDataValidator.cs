using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Exceptions;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Models.Pool;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.ColoredBalls;

namespace ExperimentalProbability.Calculations.CalculationDataValidation.Pool
{
    public class ColoredBallsDataValidator : BasePoolCalculationDataValidator
    {
        protected override void ValidatePoolData(CalculationData data)
        {
            var calcData = (ColoredBallsCalculationData)data;
            var ballCount = calcData.BallCount;

            ValidateNumber(
                ballCount,
                (int)ColoredBallsNumbers.MinNumberOfBalls,
                (int)ColoredBallsNumbers.MaxNumberOfBalls,
                Resources.ElementName_NumberOfBalls);

            var maxNumberOfColors = (int)ColoredBallsNumbers.MaxNumberOfColors;

            ValidateNumber(
                calcData.PoolColors.Length,
                (int)ColoredBallsNumbers.MinNumberOfColors,
                ballCount < maxNumberOfColors ? ballCount : maxNumberOfColors,
                Resources.ElementName_NumberOfColors);

            ValidateColors(calcData.PoolColors, Resources.ElementName_PoolColor);
            ValidateColorCounts(calcData);
        }

        protected override void ValidateConditionData(CalculationData data)
        {
            var calcData = (ColoredBallsCalculationData)data;
            var ballCount = calcData.BallCount;
            var maxNumberOfTakenBalls = (int)ColoredBallsNumbers.MaxNumberOfTakenBalls;

            ValidateNumber(
                calcData.ConditionColors.Length,
                (int)ColoredBallsNumbers.MinNumberOfTakenBalls,
                ballCount < maxNumberOfTakenBalls ? ballCount : maxNumberOfTakenBalls,
                Resources.ElementName_NumberOfTakenBalls);

            ValidateColors(calcData.ConditionColors, Resources.ElementName_ConditionColor);
        }

        private void ValidateColorCounts(ColoredBallsCalculationData data)
        {
            var sum = default(int);
            var counts = data.ColorCounts;
            var ballCount = data.BallCount;

            for (int i = default; i < counts.Length; i++)
            {
                var count = counts[i];

                ValidateNumber(
                    count,
                    (int)ColoredBallsNumbers.MinColorCount,
                    ballCount - 1,
                    AppendNumberPositionToString(i, Resources.ElementName_Counter));

                sum += count;
            }

            ValidateNumber(sum, ballCount, ballCount, Resources.ElementName_CounterSum);
        }

        private void ValidateColors(object[] colors, string elementName)
        {
            for (int i = default; i < colors.Length; i++)
            {
                if (colors[i] == null)
                {
                    throw new ValidationException(AppendNumberPositionToString(i, elementName));
                }
            }
        }
    }
}
