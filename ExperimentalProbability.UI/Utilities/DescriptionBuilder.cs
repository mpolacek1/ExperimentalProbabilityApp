using System.Text;
using ExperimentalProbability.Contracts.Properties;
using ExperimentalProbability.Contracts.Utilities;
using ExperimentalProbability.UI.Models;

namespace ExperimentalProbability.UI.Utilities
{
    public static class DescriptionBuilder
    {
        public static string BuildTypeDescription(string typeInfo, char separator)
        {
            var builder = TextBuilder.InitializeStringBuilder(GeneralResources.String_TypeInfo, separator);
            builder.Append(typeInfo);

            return builder.ToString();
        }

        public static string BuildPoolDescription(DescriptionData data, string poolItem, char separator)
        {
            var builder = TextBuilder.InitializeStringBuilder(GeneralResources.String_PoolInfo, separator);
            builder.Append(data.ItemCount);
            builder.Append(separator);
            builder.Append(poolItem);

            return builder.ToString();
        }

        public static string BuildConditionDescription(DescriptionData data, string calcAction, char separator)
        {
            var builder = TextBuilder.InitializeStringBuilder(GeneralResources.String_ConditionInfo, separator);
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
                    builder.Append(TextBuilder.CorrectEndOfItemDesc(i, data.Items.Count, separator));
                }
            }
            else
            {
                builder.Append(TextBuilder.GetNotAvailable());
            }

            return builder.ToString();
        }
    }
}
