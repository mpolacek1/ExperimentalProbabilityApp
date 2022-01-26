using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProbability.Calculations.Models
{
    public class ColoredBall
    {
        public ColoredBall(string color, int index)
        {
            Color = color;
            Index = index;
        }

        public string Color { get; set; }

        public int Index { get; set; }
    }
}
