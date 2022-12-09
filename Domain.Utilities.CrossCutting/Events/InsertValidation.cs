using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities.CrossCutting.Events
{
    public class InsertValidation
    {
        public event EventHandler<EventArgs> Validation;

        public void OnInsertNewRecor()
        {
            Validation?.Invoke(this, new EventArgs());
        }
    }
}
