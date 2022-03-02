using ExperimentalProbability.Contracts.Utilities;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExperimentalProbability.UI.CustomElements.Panels.ColoredBalls
{
    public partial class PoolVisualizationPanel : WrapPanel
    {
        public PoolVisualizationPanel(string ballCount, Color ballColor)
        {
            InitializeComponent();

            ((Label)Children[0]).Content = BuildBallCountContent(ballCount);
            Ball.Fill = new SolidColorBrush(ballColor);
        }

        private string BuildBallCountContent(string ballCount, char separator = ' ')
        {
            var multiplyOperator = '*';

            return TextBuilder.InitializeStringBuilder(ballCount, separator).Append(multiplyOperator).ToString();
        }
    }
}
