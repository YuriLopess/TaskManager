using System.Text.RegularExpressions;
using src.Exceptions;

namespace src.Validators.Task
{
    public class TaskValidator : ITaskValidator
    {
        public void ValidatorTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainValidationException("Title cannot be empty or whitespace.");
            }

            if (title.Length < 6 || title.Length > 50)
            {
                throw new DomainValidationException("Title must be between 6 and 50 characters long.");
            }

            if (!Regex.IsMatch(title, @"^[A-Za-zÀ-ÖØ-öø-ÿ0-9\s]+$"))
            {
                throw new DomainValidationException("Title can only contain letters, numbers and spaces.");
            }

            if (Regex.IsMatch(title, @"\s{2,}"))
            { 
                throw new DomainValidationException("Title cannot contain multiple consecutive spaces."); 
            }
        }

        public void ValidatorDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainValidationException("Description cannot be empty or whitespace.");
            }

            if (description.Length < 10 || description.Length > 250)
            {
                throw new DomainValidationException("Description must be between 10 and 250 characters long.");
            }

            if (!Regex.IsMatch(description, @"^[A-Za-zÀ-ÖØ-öø-ÿ0-9\s\.\,\!\?]+$"))
            {
                throw new DomainValidationException("Description contains invalid characters.");
            }

            if (Regex.IsMatch(description, @"(.)\1{10,}"))
            {
                throw new DomainValidationException("Description contains repetitive characters.");
            }
        }
    }
}