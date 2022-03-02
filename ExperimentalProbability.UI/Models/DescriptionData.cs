using System.Collections.Generic;

namespace ExperimentalProbability.UI.Models
{
    public class DescriptionData
    {
        public DescriptionData(string count, List<Dictionary<string, string>> items = null)
        {
            ItemCount = count;
            Items = items;
        }

        public string ItemCount { get; private set; }

        public List<Dictionary<string, string>> Items { get; private set; }
    }
}
