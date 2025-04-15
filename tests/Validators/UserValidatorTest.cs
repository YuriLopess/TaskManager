using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });

        }

        [Fact]
        public void ValidatorUsername_WhenContainsSpecialCharacter_ThrowsException()
        {
            var user = new UserDTO("J@nh Doe", "jonhdoe@gmail.com");

            Assert.Throws<DomainValidationException>(() => {
                _provider.validatorUsername(user.Username);
            });

        }

        [Fact]
        public void ValidatorUsername_WhenNameIsTooShort_ThrowsException()

        {
            var user = new UserDTO("Doe", "jonhdoe@gmail.com");

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });
        }

        [Fact]
        public void ValidatorUsername_WhenNameIsTooLong_ThrowsException()
        {
            var longName = new string('A', 51);

            var user = new UserDTO(longName, "jonhdoe@gmail.com");

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });
        }

        [Fact]
        public void ValidatorUsername_WhenIsWhiteSpace_ThrowsException()
        {
            var user = new UserDTO("", "jonhdoe@gmail.com");

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });
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
            var longEmail = new string('A', 321);
            var user = new UserDTO("Jonh Doe", longEmail);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorEmail(user.Email);
            });
        }

        [Fact]
        public void ValidatorEmail_WhenEmailIsInvalidFormat_ThrowsException()
        {
            var user = new UserDTO("Jonh Doe", "jonhdoe.com");

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorEmail(user.Email);
            });
        }

        [Fact]
        public void ValidatorEmail_EmptyEmail_ThrowsException()
        {
            var user = new UserDTO("Jonh Doe", null);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.validatorEmail(user.Email);
            });
        }
    }
}
