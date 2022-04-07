using System;
using ExperimentalProbability.Contracts.Properties.Resources.General;

namespace ExperimentalProbability.UI.MVVM.Models.Calculations.Pool
{
    public class PoolCalculationResultPlaceholder : CalculationResultPlaceholder
    {
        public PoolCalculationResultPlaceholder(int index)
            : base(index)
        {
        }

        public override string GetFormattedResult()
        {
            return Result.Equals(Resources.NotAvailable) ? (string)Result : string.Concat(Math.Round(Convert.ToDecimal(Result) * 100, 5), " %");
        }
    }
}
