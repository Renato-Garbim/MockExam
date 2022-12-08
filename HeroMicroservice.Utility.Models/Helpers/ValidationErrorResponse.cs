using FluentValidation.Results;
using System.Collections.Generic;

namespace HeroMicroservice.Utility.Models.Helpers
{
    public class ValidationErrorResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string TypeName { get; set; }
        public List<ValidationFailure> ValidationFailures { get; set; }
    }
}