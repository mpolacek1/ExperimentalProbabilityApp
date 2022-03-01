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
            return ((ComboBox)Children[1]).SelectedIndex + 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == -1)
            {
                this.ChangeVisibilityOfChild(0, Visibility.Visible);
            }
            else
            {
                this.ChangeVisibilityOfChild(0, Visibility.Collapsed);
            }

            Application.Current.UpdateDescription();
        }
    }
}
