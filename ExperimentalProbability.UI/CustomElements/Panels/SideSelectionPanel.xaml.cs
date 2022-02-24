using ExperimentalProbability.UI.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace ExperimentalProbability.UI.CustomElements.Panels
{
    public partial class SideSelectionPanel : WrapPanel
    {
        public SideSelectionPanel()
        {
            InitializeComponent();
        }

        public int GetSelectedSide()
        {
            return ((ComboBox)Children[0]).SelectedIndex + 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.UpdateDescription();
        }
    }
}
