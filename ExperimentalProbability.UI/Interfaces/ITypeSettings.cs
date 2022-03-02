using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.UI.Models;

namespace ExperimentalProbability.UI.Interfaces
{
    public interface ITypeSettings
    {
        DescriptionData GetDescriptionData();

        BasicData GetCalculationData();
    }
}
