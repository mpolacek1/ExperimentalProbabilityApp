using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.UI.Models;
using System.Collections.Generic;

namespace ExperimentalProbability.UI.Interfaces
{
    public interface ITypeCondition
    {
        DescriptionData GetDescriptionData();

        List<Dictionary<string, string>> GetDescriptionItems();

        void UpdateSelectorsItemsSources();

        BasicData GetCalculationData();
    }
}
