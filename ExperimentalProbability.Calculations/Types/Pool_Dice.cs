using System;
using System.Collections.Generic;
using ExperimentalProbability.Calculations.Models;

namespace ExperimentalProbability.Calculations.Types
{
    public class Pool_Dice : IPoolType
    {
        public Pool_Dice(CalculationData data)
        {
            Data = data;
        }

        private CalculationData Data { get; set; }

        private CalculationResultData ResultData { get; set; } = new CalculationResultData();

        public CalculationResultData Calculate()
        {
            for (int i = 0; i < Data.SimulationsToRun; i++)
            {
                /*var sides = RollDice(Repeats);

                if (CheckChosenCondition(condition, sides))
                {
                    conditionsMet++;
                }*/
            }

            return new CalculationResultData();
        }

        private List<int> RollDice(int repeats)
        {
            var sides = new List<int>(repeats);

            for (int i = 0; i < repeats; i++)
            {
                sides.Add(new Random().Next(1, 6 + 1));
            }

            return sides;
        }

        private bool CheckChosenCondition(int condition, List<int> sides)
        {
            switch (condition)
            {
                default:
                    return false;
                case 0:
                    return CheckFirstCondition(sides);
                case 1:
                    return CheckSecondCondition(sides);
            }
        }

        private bool CheckFirstCondition(List<int> sides)
        {
            return sides[0].Equals(6);
        }

        private bool CheckSecondCondition(List<int> sides)
        {
            return sides[0].Equals(6)
                && sides[1].Equals(6);
        }
    }
}
