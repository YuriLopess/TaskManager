using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void ValidateResponse_WhenSuccessWithoutData_ThrowsException()
        {
            var response = new ResponseModel<string>
            {
                Data = null,
                Message = "Success",
                Status = true
            };

            Assert.Throws<DomainValidationException>(() => _validator.ValidateResponse(response));
        }

        [Fact]
        public void ValidateResponse_WhenErrorWithoutMessage_ThrowsException()
        {
            var response = new ResponseModel<string>
            {
                Data = null,
                Message = "",
                Status = false
            };

            Assert.Throws<DomainValidationException>(() => _validator.ValidateResponse(response));
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

            Assert.Throws<DomainValidationException>(() => _validator.ValidateResponse(response));
        }
    }

}
