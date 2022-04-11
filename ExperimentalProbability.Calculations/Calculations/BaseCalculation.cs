using System;
using System.ComponentModel;
using ExperimentalProbability.Calculations.CalculationDataValidation;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Interfaces;
using ExperimentalProbability.Contracts.Models;

namespace ExperimentalProbability.Calculations.Calculations
{
    public abstract class BaseCalculation : ICalculation
    {
        private readonly CalculationDataValidator _validator;

        private readonly BackgroundWorker _worker;

        private readonly Random _random;

        private CalculationResultData _resultData;

        public BaseCalculation(CalculationDataValidator validator, BackgroundWorker worker)
        {
            _validator = validator;
            _worker = worker;
            _random = new Random();
            _resultData = new CalculationResultData();
        }

        public virtual CalculationResultData Run(CalculationData data, DoWorkEventArgs workerEventArgs)
        {
            ValidateData(data);
            return Calculate(data, workerEventArgs);
        }

        public abstract decimal CalculateResult(CalculationResultData data);

        public void ClearResultData()
        {
            _resultData = new CalculationResultData();
        }

        protected void ValidateData(CalculationData data)
        {
            _validator.Validate(data);
        }

        protected CalculationResultData Calculate(CalculationData data, DoWorkEventArgs workerEventArgs)
        {
            var updateProgress = data.SimulationsToRun / (int)GeneralNumbers.MaxProgress;
            var progress = default(int);

            for (int i = default; i < data.SimulationsToRun; i++)
            {
                if (_worker.CancellationPending)
                {
                    workerEventArgs.Cancel = true;
                    return null;
                }

                RunSimulation(data, _random, _resultData);

                progress = TryUpdateWorkerProgress(i, updateProgress, _resultData, data, progress);
            }

            CalculateResult(_resultData);
            return _resultData;
        }

        protected abstract bool CheckCondition(CalculationData data, object simResult);

        protected abstract object GetSimulationResult(CalculationData data, Random random);

        private void RunSimulation(CalculationData data, Random random, CalculationResultData resultData)
        {
            if (CheckCondition(data, GetSimulationResult(data, random)))
            {
                resultData.ConditionMet++;
            }

            resultData.SimulationsRan++;
        }

        private int TryUpdateWorkerProgress(int currentSim, int updateProgress, CalculationResultData resultData, CalculationData data, int currentProgress)
        {
            if ((currentSim != 0 && currentSim % updateProgress == 0)
                || resultData.SimulationsRan == data.SimulationsToRun)
            {
                currentProgress++;
                resultData.Result = CalculateResult(resultData);
                _worker.ReportProgress(currentProgress, resultData.Result);
            }

            return currentProgress;
        }
    }
}
