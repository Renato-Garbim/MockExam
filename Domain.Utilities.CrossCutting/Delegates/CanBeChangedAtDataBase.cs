using FluentValidation.Results;


namespace Domain.Utilities.CrossCutting.Delegates
{
    public delegate ValidationResult CanBeChangedAtDataBase<in TEntity>(TEntity data) where TEntity : class;    
}
