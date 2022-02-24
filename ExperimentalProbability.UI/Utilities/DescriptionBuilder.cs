using ExperimentalProbability.UI.Models;
using ExperimentalProbability.UI.Properties.LocalizableResources;
using System.Text;

namespace ExperimentalProbability.UI.Utilities
{
    public static class DescriptionBuilder
    {
        public static string BuildTypeDescription(string typeInfo, char separator)
        {
            var builder = InitializeStringBuilder(GeneralResources.String_TypeInfo, separator);
            builder.Append(typeInfo);

            return builder.ToString();
        }

        public static string BuildPoolDescription(DescriptionData data, string poolItem, char separator)
        {
            var builder = InitializeStringBuilder(GeneralResources.String_PoolInfo, separator);
            builder.Append(data.ItemCount);
            builder.Append(separator);
            builder.Append(poolItem);

            return builder.ToString();
        }

        public static string BuildConditionDescription(DescriptionData data, string calcAction, char separator)
        {
            var builder = InitializeStringBuilder(GeneralResources.String_ConditionInfo, separator);
            builder.Append(BuildItemsDescription(data, separator, calcAction));

            return builder.ToString();
        }

        public static string BuildItemsDescription(DescriptionData data, char separator, string betweenItemInfo)
        {
            var builder = new StringBuilder();

            if (data.Items != null)
            {
                for (int i = 0; i < data.Items.Count; i++)
                {
                    builder.Append(data.Items[i]["count"]);
                    builder.Append(separator);
                    builder.Append(betweenItemInfo);
                    builder.Append(separator);
                    builder.Append(data.Items[i]["name"]);
                    builder.Append(CorrectEndOfItemDesc(i, data.Items.Count, separator));
                }
            }
            else
            {
                builder.Append(GetNotAvailable());
            }

            return builder.ToString();
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

        public static string GetNotAvailable()
        {
            return InitializeStringBuilder(GeneralResources.String_NotAvailable, '.').ToString();
        }

        public static StringBuilder InitializeStringBuilder(string initialText, char separator)
        {
            return new StringBuilder(initialText).Append(separator);
        }
    }
}
