using System;
using System.Collections.Generic;
using System.ComponentModel;
using ExperimentalProbability.Calculations.CalculationDataValidation.Pool;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Models.Pool;

namespace ExperimentalProbability.Calculations.Calculations.Pool
{
    public class ColoredBallsCalculation : BasePoolCalculation
    {
        public ColoredBallsCalculation(BackgroundWorker worker)
            : base(new ColoredBallsDataValidator(), worker)
        {
        }

        protected override bool CheckCondition(CalculationData data, object simResult)
        {
            var takenBalls = (object[])simResult;

            for (int i = default; i < takenBalls.Length; i++)
            {
                if (!takenBalls[i].Equals(((ColoredBallsCalculationData)data).ConditionColors[i]))
                {
                    return false;
                }
            }

            return true;
        }

        protected override object GetSimulationResult(CalculationData data, Random random)
        {
            var calcData = (ColoredBallsCalculationData)data;
            var numberOfTakenBalls = calcData.ConditionColors.Length;

            return GetTakenBalls(
                GetIndexesOfTakenBalls(numberOfTakenBalls, random, calcData.Bag.Length),
                calcData.Bag);
        }

        private HashSet<int> GetIndexesOfTakenBalls(int numberOfTakenBalls, Random random, int numberOfBalls)
        {
            var indexes = new HashSet<int>();

            for (int i = default; i < numberOfTakenBalls; i++)
            {
                var index = random.Next(numberOfBalls);

                while (indexes.Contains(index))
                {
                    index = random.Next(numberOfBalls);
                }

                indexes.Add(index);
            }

            return indexes;
        }

        private object[] GetTakenBalls(HashSet<int> indexes, object[] bag)
        {
            var takenBalls = new List<object>(indexes.Count);

            foreach (var index in indexes)
            {
                takenBalls.Add(bag[index]);
            }

            return takenBalls.ToArray();
        }
    }
}
