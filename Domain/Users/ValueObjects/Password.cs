using Domain.Abstractions;
using Domain.Users.Exceptions;

namespace Domain.Users.ValueObjects;

public class Password : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    private Password()
    {
    }

    public Password(string value)
    {
        IsNullOrEmptyValidation(value);
        Value = value;
    }

    public string Value { get; set; }

    private void IsNullOrEmptyValidation(string value)
    {
        if (string.IsNullOrEmpty(value)) throw new EmptyOrNullPasswordException();
    }

    private void LengthValidation(string value)
    {
        if (value.Length < 5 || value.Length > 150) throw new PasswordLengthException();
    }
}