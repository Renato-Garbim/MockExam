using FluentValidation.Results;
using System.Net;
using System.Runtime.Serialization;

namespace HeroMicroservice.Utility.Models.APIMiddleware
{
    [Serializable]
    public class UsersValidationException : Exception, ISerializable
    {

        public List<ValidationFailure> ValidationFailures { get; init; } = new();
        public string? TypeName { get; init; }
        public HttpStatusCode StatusCode { get; init; }

        public UsersValidationException(List<ValidationFailure> validationFailures, string? typeName = null,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string message = "Validation Failure.")
            : base(message)
        {
            ValidationFailures = validationFailures;
            TypeName = typeName;
            StatusCode = statusCode;
        }

        public UsersValidationException(List<ValidationFailure> validationFailures, Exception inner,
            string? typeName = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string message = "Validation Failure.")
            : base(message, inner)
        {
            ValidationFailures = validationFailures;
            TypeName = typeName;
            StatusCode = statusCode;
        }

        protected UsersValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        public override void GetObjectData(SerializationInfo info,
            StreamingContext context)
        {
            base.GetObjectData(info, context);
        }


    }
}
