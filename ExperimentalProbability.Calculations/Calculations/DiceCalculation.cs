using ExperimentalProbability.Calculation.Interfaces;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.Calculation.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExperimentalProbability.Calculation.Calculations
{
    public class DiceCalculation : ICalculationType
    {
        private const int _minRollResult = 1;

        private readonly BaseCalculationValidator _validator;

        private readonly CalculationData _data;

        private readonly BackgroundWorker _worker;

        private readonly Random _random;

        public DiceCalculation(CalculationData data, BackgroundWorker worker)
        {
            _validator = new DiceValidator();
            _data = data;
            _worker = worker;
            _random = new Random();
            ResultData = new CalculationResultData();
        }

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

                if (CheckCondition(GetRolls()))
                {
                    ResultData.ConditionMet++;
                }

                ResultData.SimulationsRun++;
            }

            return ResultData;
        }

        private List<int> GetRolls()
        {
            var numberOfRolls = (int)_data.ConditionData.NumberOf;
            var rolls = new List<int>(numberOfRolls);

            for (int i = 0; i < numberOfRolls; i++)
            {
                rolls.Add(_random.Next(_minRollResult, (int)_data.TypeData.NumberOf + 1));
            }

            return rolls;
        }

        private bool CheckCondition(List<int> rolls)
        {
            for (int i = 0; i < rolls.Count; i++)
            {
                if (rolls[i] != ((List<int>)_data.ConditionData.Items)[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
