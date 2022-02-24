using ExperimentalProbability.UI.Models;

namespace ExperimentalProbability.UI.Interfaces
{
    public interface ITypeDescription
    {
        void UpdateDescription(DescriptionData typeData, DescriptionData conditionData, char separator = ' ');
    }
}
