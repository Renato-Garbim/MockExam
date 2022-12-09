using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities.CrossCutting.Interface
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
