using src.Exceptions;
using src.Models;

namespace src.Validators.Response
{
    public class ResponseValidator : IResponseValidator
    {
        public void ValidateResponse<T>(ResponseModel<T> response)
        {
            if (response is null)
                throw new DomainValidationException("Response object cannot be null.");

            if (response.Status && response.Data == null)
                throw new DomainValidationException("Successful responses must contain data.");

            if (!response.Status && string.IsNullOrWhiteSpace(response.Message))
                throw new DomainValidationException("Error responses must contain a message.");

            if (response.Message.Length > 300)
                throw new DomainValidationException("Message must be at most 300 characters long.");
        }
    }
}
