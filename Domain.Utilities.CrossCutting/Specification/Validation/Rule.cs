using Domain.Utilities.Framework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities.Framework.Specification.Validation
{
    public class Rule<T>
    {
        private readonly ISpecification<T> _specificationSpec;

        public Rule(ISpecification<T> spec, string errorMessage)
        {
            _specificationSpec = spec;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public bool Validate(T obj)
        {
            return _specificationSpec.IsSatisfiedBy(obj);
        }

    }
}
