using FluentValidation.Results;


namespace Domain.Utilities.Framework.Delegates
{
    public delegate ValidationResult CanBeChangedAtDataBase<in TEntity>(TEntity data) where TEntity : class;
}
