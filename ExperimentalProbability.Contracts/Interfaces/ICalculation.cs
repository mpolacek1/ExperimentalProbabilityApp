using ExperimentalProbability.Contracts.Models;
using System.ComponentModel;

namespace ExperimentalProbability.Contracts.Interfaces
{
    public interface ICalculation
    {
        CalculationResultData Run(CalculationData data, DoWorkEventArgs workerEventArgs);

        void ClearResultData();

        decimal CalculateResult(CalculationResultData data);
    }
}
