using ExperimentalProbability.Calculations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProbability.Calculations.Types
{
    public class Pool_ColoredBalls : ICalculationType
    {
        public CalculationResultData Calculate(int condition, int simulationsRun)
        {
            int conditionsMet = 0;

            for (int i = 0; i < simulationsRun; i++)
            {
                List<ColoredBall> takenBalls = new List<ColoredBall>(3);
                string[] tempBag = new string[9];
                //Bag.CopyTo(tempBag);
                List<string> bag = tempBag.ToList();

                for (int j = 0; j < takenBalls.Capacity; j++)
                {
                    takenBalls.Add(GetBallFromBag(bag));
                    bag.RemoveAt(takenBalls[j].Index);
                }

                if (CheckChosenCondition(condition, takenBalls))
                {
                    conditionsMet++;
                }
            }

            return new CalculationResultData(simulationsRun, conditionsMet, GetProbability(conditionsMet, simulationsRun));
        }

        private ColoredBall GetBallFromBag(List<string> bag)
        {
            Random random = new Random();
            int randomNum = random.Next(0, bag.Count);
            string color = bag[randomNum];

            return new ColoredBall(color, randomNum);
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

        public double GetProbability(int conditionsMet, int simulationsRun)
        {
            return Math.Round(Convert.ToSingle(conditionsMet) / Convert.ToSingle(simulationsRun) * 100, 2);
        }
    }
}
