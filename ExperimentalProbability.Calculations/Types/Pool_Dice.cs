using ExperimentalProbability.Calculations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProbability.Calculations.Types
{
    public class Pool_Dice : IPoolType
    {
        private int Repeats { get; set; }

        private readonly int NumberOfSides = 6;

        private readonly Random Random = new Random();

        public Pool_Dice(int condition)
        {
            Repeats = GetRepeats(condition);
        }

        private int GetRepeats(int condition)
        {
            switch (condition)
            {
                default:
                    return 1;
                case 1:
                    return 2;
            }
        }

        public CalculationResultData Calculate(int condition, int simulationsRun)
        {
            int conditionsMet = 0;

            for (int i = 0; i < simulationsRun; i++)
            {
                List<int> sides = RollDice(Repeats);

                if (CheckChosenCondition(condition, sides))
                {
                    conditionsMet++;
                }
            }

            return new CalculationResultData(simulationsRun, conditionsMet, GetResult(conditionsMet, simulationsRun));
        }

        private List<int> RollDice(int repeats)
        {
            var sides = new List<int>(repeats);

            for (int i = 0; i < repeats; i++)
            {
                sides.Add(Random.Next(1, NumberOfSides + 1));
            }

            return sides;
        }

        private bool CheckChosenCondition(int condition, List<int> sides)
        {
            switch (condition)
            {
                default :
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

        public double GetResult(int conditionsMet, int simulationsRun)
        {
            return Math.Round(Convert.ToSingle(conditionsMet) / Convert.ToSingle(simulationsRun) * 100, 2);
        }
    }
}
