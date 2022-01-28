using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.CustomUIElements
{
    public class ItemSelectionPanel : DockPanel
    {
        public ItemSelectionPanel(string text, string[] itemsSource)
        {
            DefaultElementSettings();
            Children.Add(GetItemSelector(text, itemsSource));
        }

        public ItemSelectionPanel(MainWindow window)
        {
            DefaultElementSettings();
            Children.Add(GetColorSelector(window));
            Children.Add(GetColorNumberText());
            Children.Add(GetColorNumberOf());
        }

        private static ComboBox GetItemSelector(string text, string[] itemsSource)
        {
            var selector = new ComboBox()
            {
                Style = (Style)Application.Current.Resources["ComboBoxItemSelector"],
                Text = text,
                ItemsSource = itemsSource,
            };

            return selector;
        }

        private static ComboBox GetColorSelector(MainWindow window)
        {
            var selector = new ComboBox()
            {
                Style = (Style)Application.Current.Resources["ComboBoxColorSelector"],
                ItemsSource = window.Colors,
            };

            selector.SelectionChanged += new SelectionChangedEventHandler(window.Selection_ColoredBalls_Color_SelectionChanged);
            SetDock(selector, Dock.Top);

            return selector;
        }

        private static TextBlock GetColorNumberText()
        {
            return new TextBlock()
            {
                Margin = new Thickness(0, 0, 5, 0),
                Text = Properties.Resources.Text_ColoredBalls_ColorNumber,
            };
        }

        private static IntegerUpDown GetColorNumberOf()
        {
            var colorNumber = new IntegerUpDown()
            {
                Style = (Style)Application.Current.Resources["IntegerUpDownDefault"],
                Minimum = 1,
                Text = Properties.Resources.Default_ColoredBalls_ColorNumber,
            };

            SetDock(colorNumber, Dock.Right);

            return colorNumber;
        }

        private void DefaultElementSettings()
        {
            LastChildFill = false;
            Margin = new Thickness(0, 0, 5, 0);
        }
    }
}
