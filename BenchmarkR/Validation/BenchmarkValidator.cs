using BenchmarkR.Model;
using FluentValidation;

namespace BenchmarkR.Validation
{
    internal class BenchmarkValidator : AbstractValidator<IBenchmark>
    {
        internal BenchmarkValidator()
        {
            RuleFor(b => b.BatchSize)
                .GreaterThan(0)
                .LessThanOrEqualTo(64)
                .WithMessage(b => $"Batch size {b.BatchSize} is invalid");

            RuleFor(b => b.TotalCount)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Total Count must be greater or equal to 1");
        }
    }
}