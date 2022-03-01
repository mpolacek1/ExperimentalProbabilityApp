using ExperimentalProbability.UI.Interfaces;
using ExperimentalProbability.UI.Models;
using ExperimentalProbability.UI.Utilities;
using System.Windows.Controls;
using LocalResx = ExperimentalProbability.Contracts.Properties.DiceResources;

namespace ExperimentalProbability.UI.CustomElements.Views.Types.Dice
{
    public partial class DescriptionView : UserControl, ITypeDescription
    {
        public DescriptionView()
        {
            InitializeComponent();
        }

        public void UpdateDescription(DescriptionData typeData, DescriptionData conditionData, char separator = ' ')
        {
            var descriptions = ((Panel)Content).Children;

            ((TextBlock)descriptions[0]).Text = DescriptionBuilder.BuildTypeDescription(LocalResx.String_TypeInfo, separator);
            ((TextBlock)descriptions[1]).Text = DescriptionBuilder.BuildPoolDescription(typeData, LocalResx.String_PoolItem, separator);
            ((TextBlock)descriptions[2]).Text = DescriptionBuilder.BuildConditionDescription(conditionData, LocalResx.String_CalculationAction, separator);
        }
    }
}
