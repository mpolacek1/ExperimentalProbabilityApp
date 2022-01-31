using System;
using System.Collections.Generic;
using System.Linq;
using ExperimentalProbability.Calculations.Models;

namespace ExperimentalProbability.Calculations.Types
{
    public class Pool_ColoredBalls : IPoolType
    {
        public Pool_ColoredBalls(CalculationData data)
        {
            Data = data;
        }

        private CalculationData Data { get; set; }

        private CalculationResultData ResultData { get; set; } = new CalculationResultData();

        public CalculationResultData Calculate()
        {
            for (int i = 0; i < Data.SimulationsToRun; i++)
            {
                var takenBalls = new List<ColoredBall>(3);
                string[] tempBag = new string[9];

                // Bag.CopyTo(tempBag);
                var bag = tempBag.ToList();

                for (int j = 0; j < takenBalls.Capacity; j++)
                {
                    takenBalls.Add(GetBallFromBag(bag));
                    bag.RemoveAt(takenBalls[j].Index);
                }

                /*if (CheckChosenCondition(condition, takenBalls))
                {
                    conditionsMet++;
                }*/
            }

            return new CalculationResultData();
        }

        public bool CheckChosenCondition(int condition, List<ColoredBall> data)
        {
            bool result = false;

            switch (condition)
            {
                case 0:
                    result = CheckFirstCondition(data);
                    break;
                case 1:
                    result = CheckSecondCondition(data);
                    break;
            }

            return result;
        }

        private ColoredBall GetBallFromBag(List<string> bag)
        {
            var random = new Random();
            int randomNum = random.Next(0, bag.Count);
            string color = bag[randomNum];

            return new ColoredBall(color, randomNum);
        }

        private bool CheckFirstCondition(List<ColoredBall> data)
        {
            return data[0].Color != data[1].Color
                && data[0].Color != data[2].Color
                && data[1].Color != data[2].Color;
        }

        private bool CheckSecondCondition(List<ColoredBall> data)
        {
            return data[0].Color == data[1].Color
                && data[0].Color == data[2].Color
                && data[1].Color == data[2].Color;
        }
    }
}
