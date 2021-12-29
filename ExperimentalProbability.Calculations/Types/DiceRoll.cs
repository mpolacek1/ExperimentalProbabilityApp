using ExperimentalProbability.Calculations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProbability.Calculations.Types
{
    public class DiceRoll : IType
    {
        private int Repeats { get; set; }

        private int NumberOfSides = 6;

        private readonly Random Random = new Random();

        public DiceRoll(int condition)
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

        public async Task<CalculationResultData> Calculate(int condition, int simulationsRun)
        {
            int conditionsMet = 0;

            for (int i = 0; i < simulationsRun; i++)
            {
                List<int> sides = await RollDice(Repeats);

                if (await CheckChosenCondition(condition, sides))
                {
                    conditionsMet++;
                }
            }

            return new CalculationResultData(simulationsRun, conditionsMet, await GetProbability(conditionsMet, simulationsRun));
        }

        private Task<List<int>> RollDice(int repeats)
        {
            List<int> sides = new List<int>(repeats);

            for (int i = 0; i < repeats; i++)
            {
                sides.Add(Random.Next(1, NumberOfSides + 1));
            }

            return Task.FromResult(sides);
        }

        private async Task<bool> CheckChosenCondition(int condition, List<int> sides)
        {
            bool result = false;

            switch (condition)
            {
                case 0:
                    result = await CheckFirstCondition(sides);
                    break;
                case 1:
                    result = await CheckSecondCondition(sides);
                    break;
            }

            return result;
        }

        private Task<bool> CheckFirstCondition(List<int> sides)
        {
            bool result = sides[0].Equals(6);

            return Task.FromResult(result);
        }

        private Task<bool> CheckSecondCondition(List<int> sides)
        {
            bool result = sides[0].Equals(6)
                && sides[1].Equals(6);

            return Task.FromResult(result);
        }

        public Task<double> GetProbability(int conditionsMet, int simulationsRun)
        {
            return Task.FromResult(Math.Round(Convert.ToSingle(conditionsMet) / Convert.ToSingle(simulationsRun) * 100, 2));
        }
    }
}
