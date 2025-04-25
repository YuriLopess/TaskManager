using System;
using Xunit;
using src.Exceptions;
using src.Models;
using src.Validators.Response;

namespace tests.Validators
{
    public class ResponseValidatorTest
    {
        private readonly IResponseValidator _validator;

        public ResponseValidatorTest()
        {
            _validator = new ResponseValidator();
        }

        [Fact]
        public void ValidateResponse_WhenResponseIsNull_ThrowsException()
        {
            ResponseModel<string> response = null;

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _validator.ValidateResponse(response);
            });

            Assert.Equal("Response object cannot be null.", ex.Message);
        }

        [Fact]
        public void ValidateResponse_WhenStatusTrueAndDataIsNull_ThrowsException()
        {
            var response = new ResponseModel<string>
            {
                Data = null,
                Message = "Success",
                Status = true
            };

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _validator.ValidateResponse(response);
            });

            Assert.Equal("Successful responses must contain data.", ex.Message);
        }

        [Fact]
        public void ValidateResponse_WhenStatusFalseAndMessageIsEmpty_ThrowsException()
        {
            var response = new ResponseModel<string>
            {
                Data = null,
                Message = "",
                Status = false
            };

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _validator.ValidateResponse(response);
            });

            Assert.Equal("Error responses must contain a message.", ex.Message);
        }

        [Fact]
        public void ValidateResponse_WhenMessageIsTooLong_ThrowsException()
        {
            var longMessage = new string('A', 301);

            var response = new ResponseModel<string>
            {
                Data = "Some data",
                Message = longMessage,
                Status = true
            };

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _validator.ValidateResponse(response);
            });

            Assert.Equal("Message must be at most 300 characters long.", ex.Message);
        }


        [Fact]
        public void ValidateResponse_WhenMessageIsExactly300Characters_DoesNotThrowException()
        {
            var message = new string('A', 300);
            var response = new ResponseModel<string>
            {
                Data = "Valid data",
                Message = message,
                Status = true
            };

            var exception = Record.Exception(() =>
            {
                _validator.ValidateResponse(response);
            });

            Assert.Null(exception);
        }

        [Fact]
        public void ValidateResponse_WhenStatusFalseAndMessageIsValid_DoesNotThrowException()
        {
            var response = new ResponseModel<string>
            {
                Data = null,
                Message = "An error occurred.",
                Status = false
            };

            var exception = Record.Exception(() =>
            {
                _validator.ValidateResponse(response);
            });

            Assert.Null(exception);
        }

        [Fact]
        public void ValidateResponse_WhenStatusTrueAndDataIsPresent_DoesNotThrowException()
        {
            var response = new ResponseModel<string>
            {
                Data = "This is valid data",
                Message = "Success",
                Status = true
            };

            var exception = Record.Exception(() =>
            {
                _validator.ValidateResponse(response);
            });

            Assert.Null(exception);
        }
    }
}
