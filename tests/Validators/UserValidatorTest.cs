using System;
using src.Dto;
using src.Exceptions;
using src.Validators.User;

namespace tests.Validators
{
    public class UserValidatorTest
    {
        private readonly IUserValidator _provider;

        public UserValidatorTest()
        {
            _provider = new UserValidator();
        }

        [Fact]
        public void ValidatorUsername_EmptyName_ThrowsException()
        {
            var user = new UserDTO(null, "jonhdoe@gmail.com");

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });

            Assert.Equal("Name must be between 8 and 50 characters long and cannot be empty.", ex.Message);
        }

        [Fact]
        public void ValidatorUsername_WhenContainsSpecialCharacter_ThrowsException()
        {
            var user = new UserDTO("J@nh Doe", "jonhdoe@gmail.com");

            var ex = Assert.Throws<DomainValidationException>(() => {
                _provider.validatorUsername(user.Username);
            });

            Assert.Equal("Name can only contain letters and spaces.", ex.Message);
        }

        [Fact]
        public void ValidatorUsername_WhenNameIsTooShort_ThrowsException()
        {
            var user = new UserDTO("Doe", "jonhdoe@gmail.com");

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });

            Assert.Equal("Name must be between 8 and 50 characters long and cannot be empty.", ex.Message);
        }

        [Fact]
        public void ValidatorUsername_WhenNameIsTooLong_ThrowsException()
        {
            var longName = new string('A', 51);
            var user = new UserDTO(longName, "jonhdoe@gmail.com");

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });

            Assert.Equal("Name must be between 8 and 50 characters long and cannot be empty.", ex.Message);
        }

        [Fact]
        public void ValidatorUsarname_WhenNameExactly50Characters_DoesNotThrowException()
        {
            var longName = new string('A', 50);
            var user = new UserDTO(longName, "jonhdoe@gmail.com");

            var exception = Record.Exception(() =>
            {
                _provider.validatorUsername(user.Username);
            });

            Assert.Null(exception);
        }

        [Fact]
        public void ValidatorUsername_WhenIsWhiteSpace_ThrowsException()
        {
            var user = new UserDTO("", "jonhdoe@gmail.com");

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });

            Assert.Equal("Name must be between 8 and 50 characters long and cannot be empty.", ex.Message);
        }

        [Fact]
        public void ValidatorUsername_WithAccentedLetters_DoesNotThrowException()
        {
            var user = new UserDTO("Jonh Doe", "jonhdoe@gmail.com");

            var exception = Record.Exception(() => _provider.validatorUsername(user.Username));

            Assert.Null(exception);
        }

        [Fact]
        public void ValidatorEmail_WhenEmailIsTooLong_ThrowsException()
        {
            var localPart = new string('A', 321);
            var domain = "@email.com";
            var longEmail = localPart + domain;

            var user = new UserDTO("Jonh Doe", longEmail);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorEmail(user.Email);
            });

            Assert.Equal("Email must not exceed 320 characters.", ex.Message);
        }

        [Fact]
        public void ValidatorEmail_WhenEmailIsInvalidFormat_ThrowsException()
        {
            var user = new UserDTO("Jonh Doe", "jonhdoe.com");

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorEmail(user.Email);
            });

            Assert.Equal("Invalid email format.", ex.Message);
        }

        [Fact]
        public void ValidatorEmail_EmptyEmail_ThrowsException()
        {
            var user = new UserDTO("Jonh Doe", null);

            Assert.Throws<ArgumentNullException>(() =>
            {
                _provider.validatorEmail(user.Email);
            });
        }

        [Fact]
        public void ValidatorEmail_WhenEmailExactly320Characters_DoesNotThrowException()
        {
            var localPart = new string('a', 310);
            var email = localPart + "@gmail.com";

            var user = new UserDTO("Jonh Doe", email);

            var exception = Record.Exception(() =>
            {
                _provider.validatorEmail(user.Email);
            });

            Assert.Null(exception);
        }
    }
}
