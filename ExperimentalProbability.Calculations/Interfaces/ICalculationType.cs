using ExperimentalProbability.Calculation.Models;
using System.ComponentModel;

namespace ExperimentalProbability.Calculation.Interfaces
{
    public interface ICalculationType
    {
        CalculationResultData Calculate(DoWorkEventArgs e);
    }
}
