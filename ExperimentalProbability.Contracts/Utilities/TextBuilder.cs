using ExperimentalProbability.Contracts.Properties;
using System.Text;

namespace ExperimentalProbability.Contracts.Utilities
{
    public static class TextBuilder
    {
        public static string GetNotAvailable()
        {
            return InitializeStringBuilder(GeneralResources.String_NotAvailable, '.').ToString();
        }

        public static StringBuilder InitializeStringBuilder(string initialText, char separator)
        {
            return new StringBuilder(initialText).Append(separator);
        }

        public static string CorrectEndOfItemDesc(int index, int count, char separator)
        {
            var builder = new StringBuilder();

            if (index == count - 1)
            {
                builder.Append('.');
            }
            else
            {
                builder.Append(',');
                builder.Append(separator);
            }

            return builder.ToString();
        }
    }
}
