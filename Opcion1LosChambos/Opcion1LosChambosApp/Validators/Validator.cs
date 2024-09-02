using LosChambos.ErrorHandling.Exceptions;

namespace LosChambos.Validators;

public abstract class Validator<T>
{
    protected Dictionary<string, Func<T, bool>> Validations { get; }

    protected Validator()
    {
        Validations = new Dictionary<string, Func<T, bool>>();
        InitializeValidations();
    }

    protected abstract void InitializeValidations();

    public bool Validate(T item)
    {
        bool isValid = true;

        foreach (var validation in Validations)
        {
            if (!validation.Value(item))
            {
                isValid = false;
            }
        }

        return isValid;
    }
}
