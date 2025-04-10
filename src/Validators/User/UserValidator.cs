using System.Text.RegularExpressions;
using System.Xml.Linq;
using src.Exceptions;

namespace src.Validators.User
{
    public class UserValidator : IUserValidator
    {
        public void validatorUsername(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 8 || name.Length > 50)
            {
                throw new UserValidationException("Name must be between 8 and 50 characters long and cannot be empty.");
            }

            if (!Regex.IsMatch(name, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$"))
            {
                throw new UserValidationException("Name can only contain letters and spaces.");
            }
        }

        public void validatorEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new UserValidationException("Invalid email format.");
            }

            if (email.Length > 320)
            {
                throw new UserValidationException("Email must not exceed 320 characters.");
            }
        }
    }
}
