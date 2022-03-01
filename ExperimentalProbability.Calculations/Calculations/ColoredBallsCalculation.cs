using System;
using System.ComponentModel;
using ExperimentalProbability.Calculation.Interfaces;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.Calculation.Validation;

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
            }

            return ResultData;
        }
    }
}
