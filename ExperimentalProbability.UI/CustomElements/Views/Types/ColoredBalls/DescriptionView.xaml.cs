using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ExperimentalProbability.Contracts.Utilities;
using ExperimentalProbability.UI.CustomElements.Panels.ColoredBalls;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Interfaces;
using ExperimentalProbability.UI.Models;
using ExperimentalProbability.UI.Utilities;
using LocalResx = ExperimentalProbability.Contracts.Properties.ColoredBallsResources;

namespace ExperimentalProbability.UI.CustomElements.Views.Types.ColoredBalls
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
            ((TextBlock)descriptions[1]).Text = BuildPoolDescription(typeData, separator);
            ((TextBlock)descriptions[2]).Text = DescriptionBuilder.BuildConditionDescription(conditionData, LocalResx.String_CalculationAction, separator);

            VisualizePool((Panel)((Panel)((Border)descriptions[3]).Child).Children[1]);
        }

        private string BuildPoolDescription(DescriptionData data, char separator)
        {
            var builder = TextBuilder.InitializeStringBuilder(DescriptionBuilder.BuildPoolDescription(data, LocalResx.String_PoolItem, separator), separator);

            if (data.Items != null)
            {
                for (int i = 0; i < data.Items.Count; i++)
                {
                    builder.Append(data.Items[i]["count"]);
                    builder.Append(separator);

                    if (data.Items[i]["count"] == NumberTranslater.NumberToWord[1])
                    {
                        builder.Append(LocalResx.String_BeforeColorNameSingular);
                    }
                    else
                    {
                        builder.Append(LocalResx.String_BeforeColorNamePlural);
                    }

                    builder.Append(separator);
                    builder.Append(data.Items[i]["name"]);
                    builder.Append(TextBuilder.CorrectEndOfItemDesc(i, data.Items.Count, separator));
                }
            }
            else
            {
                builder.Append(TextBuilder.GetNotAvailable());
            }

            return builder.ToString();
        }

        private void VisualizePool(Panel panel)
        {
            var typeSettings = (TypeSettingsView)Application.Current.GetCurrentSettings();

            if (typeSettings.Panel_ColorSelection.Children.Count == typeSettings.NumberOfColors.GetValue())
            {
                panel.Children.Clear();

                var colorsAndCounts = ((TypeSettingsView)Application.Current.GetCurrentSettings()).GetColorsAndCounts();

                for (int i = 0; i < colorsAndCounts.Count; i++)
                {
                    var color = (Color?)colorsAndCounts[i]["color"];
                    var count = (int)colorsAndCounts[i]["count"];

                    if (color.HasValue
                        && count > 0)
                    {
                        panel.Children.Add(new PoolVisualizationPanel(count.ToString(), color.Value));
                    }
                }
            }
        }
    }
}
