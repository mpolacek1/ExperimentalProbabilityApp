using ExperimentalProbability.Calculations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProbability.Calculations.Types
{
    public interface IType
    {
        Task<CalculationResultData> Calculate(int condition, int simulations);

        Task<double> GetProbability(int conditionsMet, int simulationsRun);
    }
}
