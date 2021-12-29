using ExperimentalProbability.Calculations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProbability.Calculations.Types
{
    public class BagOfColoredBalls : IType
    {
        private const string Red = "red";

        private const string Green = "green";

        private const string Blue = "blue";

        private readonly List<string> Bag = new List<string>(9) { Red, Red, Red, Green, Green, Green, Blue, Blue, Blue };

        private readonly Random Random = new Random();

        public async Task<CalculationResultData> Calculate(int condition, int simulationsRun)
        {
            int conditionsMet = 0;

            for (int i = 0; i < simulationsRun; i++)
            {
                List<ColoredBall> takenBalls = new List<ColoredBall>(3);
                string[] tempBag = new string[9];
                Bag.CopyTo(tempBag);
                List<string> bag = tempBag.ToList();

                for (int j = 0; j < takenBalls.Capacity; j++)
                {
                    takenBalls.Add(await GetBallFromBag(bag));
                    bag.RemoveAt(takenBalls[j].Index);
                }

                if (await CheckChosenCondition(condition, takenBalls))
                {
                    conditionsMet++;
                }
            }

            return new CalculationResultData(simulationsRun, conditionsMet, await GetProbability(conditionsMet, simulationsRun));
        }

        private Task<ColoredBall> GetBallFromBag(List<string> bag)
        {
            int random = Random.Next(0, bag.Count);
            string color = bag[random];

            return Task.FromResult(new ColoredBall(color, random));
        }

        public async Task<bool> CheckChosenCondition(int condition, List<ColoredBall> data)
        {
            bool result = false;

            switch (condition)
            {
                case 0:
                    result = await CheckFirstCondition(data);
                    break;
                case 1:
                    result = await CheckSecondCondition(data);
                    break;
            }

            return result;
        }

        private Task<bool> CheckFirstCondition(List<ColoredBall> data)
        {
            bool result = data[0].Color != data[1].Color
                && data[0].Color != data[2].Color
                && data[1].Color != data[2].Color;

            return Task.FromResult(result); 
        }

        private Task<bool> CheckSecondCondition(List<ColoredBall> data)
        {
            bool result = data[0].Color == data[1].Color
                && data[0].Color == data[2].Color
                && data[1].Color == data[2].Color;

            return Task.FromResult(result);
        }

        public Task<double> GetProbability(int conditionsMet, int simulationsRun)
        {
            return Task.FromResult(Math.Round(Convert.ToSingle(conditionsMet) / Convert.ToSingle(simulationsRun) * 100, 2));
        }
    }
}
