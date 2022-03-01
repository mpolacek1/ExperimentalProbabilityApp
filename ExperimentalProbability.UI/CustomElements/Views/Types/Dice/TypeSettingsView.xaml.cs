using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.Contracts.Properties;
using ExperimentalProbability.Contracts.Utilities;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Interfaces;
using ExperimentalProbability.UI.Models;
using LocalResx = ExperimentalProbability.Contracts.Properties.DiceResources;

namespace ExperimentalProbability.UI.CustomElements.Views.Types.Dice
{
    public partial class TypeSettingsView : UserControl, ITypeSettings
    {
        public TypeSettingsView()
        {
            InitializeComponent();
        }

        public Dictionary<string, int> DiceTypes { get; } = new Dictionary<string, int>(6)
        {
            { LocalResx.String_DiceType_Tetrahedron, 4 },
            { LocalResx.String_DiceType_Cube, 6 },
            { LocalResx.String_DiceType_Octahedron, 8 },
            { LocalResx.String_DiceType_PentagonalTrapezohedron, 10 },
            { LocalResx.String_DiceType_Dodecahedron, 12 },
            { LocalResx.String_DiceType_Icosahedron, 20 },
        };

        public DescriptionData GetDescriptionData()
        {
            var count = GetSidesCount();

            return new DescriptionData(GetFinalDescCount(count));
        }

        public int GetSidesCount()
        {
            return DiceSelection.SelectedIndex == -1 ? 0 : DiceTypes[DiceSelection.SelectedItem.ToString()];
        }

        public BasicData GetCalculationData()
        {
            return new BasicData(GetSidesCount(), null);
        }

        private string GetFinalDescCount(int count, char separator = ' ')
        {
            if (count == 0)
            {
                return GeneralResources.String_NotAvailable;
            }

            var builder = new StringBuilder();

            if (CultureInfo.CurrentUICulture.Equals(new CultureInfo("en-US")))
            {
                builder.Append(count == 8 ? GeneralResources.String_IndefiniteMember_An : GeneralResources.String_IndefiniteMember_A);
                builder.Append(separator);
            }

            builder.Append(NumberTranslater.NumberToWord[count]);

            return builder.ToString();
        }

        private void DiceSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.UpdateSelectableData();
            Application.Current.UpdateDescription();
        }
    }
}
