using Domain.Utilities.Framework.Specification.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities.Framework.Events
{
    public class ValidateEventArgs<TEntity> : EventArgs
    {
        public SpecValidator<TEntity> Validator { get; set; }

    }
}
