using System;
using System.Text;
using FluentValidation.Results;

namespace BenchmarkR.Exceptions
{
    [Serializable]
    public class BenchmarkConfigurationException : Exception
    {
        private BenchmarkConfigurationException(string msg) : base(msg) { }
        
        public static BenchmarkConfigurationException FromValidationResult(ValidationResult validationResult)
        {
            var errorMessage = ParseValidationResults(validationResult);
            return new BenchmarkConfigurationException(errorMessage);
        }

        private static string ParseValidationResults(ValidationResult validationResult)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.Append("Invalid benchmark configuration. ");

            foreach (var error in validationResult.Errors)
            {
                messageBuilder.AppendFormat("{0} ", error.ErrorMessage);
            }

            return messageBuilder.ToString();
        }
    }
}