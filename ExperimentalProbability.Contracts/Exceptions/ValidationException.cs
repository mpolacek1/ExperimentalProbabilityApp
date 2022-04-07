using System;
using ExperimentalProbability.Contracts.Properties.Resources.Validation;

namespace ExperimentalProbability.Contracts.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string elementName, string messBetween = null, object value = null)
            : base(GenerateMessage(elementName, messBetween, value))
        {
        }

        private static string GenerateMessage(string elementName, string messBetween, object value)
        {
            var message = string.Concat(Resources.Error_Beginning, ' ', elementName, ' ', messBetween ?? Resources.Error_CannotBeEmpty);

            if (value != null)
            {
                message = string.Concat(message, ' ', value);
            }

            return string.Concat(message, '.');
        }
    }
}
