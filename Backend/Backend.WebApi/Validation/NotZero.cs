using System.ComponentModel.DataAnnotations;

namespace Backend.WebApi.Validation;

internal sealed class NotZero : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        if (!int.TryParse(value.ToString(), out var intValue)) return false;

        return intValue != 0;
    }
    
    public override string FormatErrorMessage(string name)
    {
        return $"{name} must be not zero.";
    }
}