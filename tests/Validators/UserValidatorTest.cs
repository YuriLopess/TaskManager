using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using src.Models;
using src.Validators.User;

namespace tests.Validators
{
    public class UserValidatorTest
    {

        [Fact]
        public void ValidateName_EmptyName_ThrowsException()
        {
            var user = new UserModel(null, "jonhdoe@gmail.com");

            Assert.Throws<Exception>(() =>
            {
                UserValidator.validatorUsername(user.Username);
            });

        }

        [Fact]
        public void ValidateName_WhenContainsSpecialCharacter_ThrowsException()
        {
            var user = new UserModel("J@nh Doe", "jonhdoe@gmail.com");

            Assert.Throws<Exception>(() => {
                UserValidator.validatorUsername(user.Username);
            });

        }

        [Fact]
        public void ValidateName_WhenNameIsTooShort_ThrowsException()

        {
            var user = new UserModel("Doe", "jonhdoe@gmail.com");

            Assert.Throws<Exception>(() =>
            {
                UserValidator.validatorUsername(user.Username);
            });
        }

        [Fact]
        public void ValidateName_WhenIsWhiteSpace_ThrowsException()
        {
            var user = new UserModel("", "jonhdoe@gmail.com");

            Assert.Throws<Exception>(() =>
            {
                UserValidator.validatorUsername(user.Username);
            });
        }
    }
}
