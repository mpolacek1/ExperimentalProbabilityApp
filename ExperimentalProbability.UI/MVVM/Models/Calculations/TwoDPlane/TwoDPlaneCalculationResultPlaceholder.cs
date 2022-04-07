using System;
using ExperimentalProbability.Contracts.Properties.Resources.General;

namespace ExperimentalProbability.UI.MVVM.Models.Calculations.TwoDPlane
{
    public class TwoDPlaneCalculationResultPlaceholder : CalculationResultPlaceholder
    {
        public TwoDPlaneCalculationResultPlaceholder(int index)
            : base(index)
        {
        }

        public override string GetFormattedResult()
        {
            return Result.Equals(Resources.NotAvailable) ? (string)Result : Math.Round(Convert.ToDecimal(Result), 5).ToString();
        }
    }
}
