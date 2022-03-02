using System;
using System.Collections.Generic;
using System.ComponentModel;
using ExperimentalProbability.Calculation.Interfaces;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.Calculation.Validation;
using Newtonsoft.Json;

namespace ExperimentalProbability.Calculation.Calculations
{
    public class ColoredBallsCalculation : ICalculationType
    {
        private readonly BaseCalculationValidator _validator;

        private readonly CalculationData _data;

        private readonly BackgroundWorker _worker;

        private readonly Random _random;

        public ColoredBallsCalculation(CalculationData data, BackgroundWorker worker)
        {
            _validator = new ColoredBallsValidator();
            _data = data;
            _worker = worker;
            _random = new Random();
            ResultData = new CalculationResultData();
        }

        private List<object> CurrentPool { get; set; }

        private CalculationResultData ResultData { get; set; }

        public CalculationResultData Calculate(DoWorkEventArgs e)
        {
            _validator.Validate(_data);

            for (int i = 0; i < _data.SimulationsToRun; i++)
            {
                if (_worker.CancellationPending)
                {
                    e.Cancel = true;
                    return null;
                }

                GenerateCurrentBag();

                if (CheckCondition(GetTakenBalls()))
                {
                    ResultData.ConditionMet++;
                }

                ResultData.SimulationsRun++;
            }

            return ResultData;
        }

        private object[] GetTakenBalls()
        {
            var numberOfTakenBalls = (int)_data.ConditionData.NumberOf;
            var takenBalls = new object[numberOfTakenBalls];

            for (int i = 0; i < numberOfTakenBalls; i++)
            {
                takenBalls[i] = TakeBallFromBag();
            }

            return takenBalls;
        }

        private void GenerateCurrentBag()
        {
            var numberOfBalls = ((Dictionary<string, int>)_data.TypeData.NumberOf)["balls"];

            CurrentPool = new List<object>(numberOfBalls);
            var bag = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(_data.TypeData.Items));

            for (int i = 0; i < numberOfBalls; i++)
            {
                CurrentPool.Add(GetBall(bag));
            }
        }

        private object GetBall(List<Dictionary<string, object>> bag)
        {
            var index = _random.Next(bag.Count);

            var ball = bag[index]["color"];

            var count = (long)bag[index]["count"];
            count--;
            bag[index]["count"] = count;

            if (count == 0)
            {
                bag.RemoveAt(index);
            }

            return ball;
        }

        private object TakeBallFromBag()
        {
            var index = _random.Next(CurrentPool.Count);

            var ball = CurrentPool[index];
            CurrentPool.RemoveAt(index);

            return ball;
        }

        private bool CheckCondition(object[] takenBalls)
        {
            for (int i = 0; i < takenBalls.Length; i++)
            {
                if (!takenBalls[i].Equals(((List<object>)_data.ConditionData.Items)[i].ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
