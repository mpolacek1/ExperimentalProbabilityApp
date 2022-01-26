using ExperimentalProbability.Calculations.Models;

namespace ExperimentalProbability.Calculations.Types
{
    public interface IPoolType
    {
        CalculationResultData Calculate(int condition, int simulations);

        double GetResult(int conditionsMet, int simulationsRun);
    }
}
