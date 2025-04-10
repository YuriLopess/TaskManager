using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using src.Exceptions;
using src.Models;
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
        public void ValidateName_EmptyName_ThrowsException()
        {

            var user = new UserModel(null, "jonhdoe@gmail.com");

            Assert.Throws<UserValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });

        }

        [Fact]
        public void ValidateName_WhenContainsSpecialCharacter_ThrowsException()
        {
            var user = new UserModel("J@nh Doe", "jonhdoe@gmail.com");

            Assert.Throws<UserValidationException>(() => {
                _provider.validatorUsername(user.Username);
            });

        }

        [Fact]
        public void ValidateName_WhenNameIsTooShort_ThrowsException()

        {
            var user = new UserModel("Doe", "jonhdoe@gmail.com");

            Assert.Throws<UserValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });
        }

        [Fact]
        public void ValidateName_WhenNameIsTooLong_ThrowsException()
        {
            var longName = new string('A', 51);

            var user = new UserModel(longName, "jonhdoe@gmail.com");

            Assert.Throws<UserValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });
        }

        [Fact]
        public void ValidateName_WhenIsWhiteSpace_ThrowsException()
        {
            var user = new UserModel("", "jonhdoe@gmail.com");

            Assert.Throws<UserValidationException>(() =>
            {
                _provider.validatorUsername(user.Username);
            });
        }

        [Fact]
        public void ValidateName_WithAccentedLetters_DoesNotThrowException()
        {
            var user = new UserModel("Jonh Doe", "jonhdoe@gmail.com");

            var exception = Record.Exception(() => _provider.validatorUsername(user.Username));

            Assert.Null(exception);
        }
    }
}
