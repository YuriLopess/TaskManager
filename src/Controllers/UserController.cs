using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Services.User;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetUser/{idUser}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> GetUser(Guid idUser)
        {
            var user = _service.GetUser(idUser);
            return Ok(user);  
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<ResponseModel<UserModel>>> DeleteUser()
        {

        }

        [HttpPost("PostUser")]
        public async Task<ActionResult<ResponseModel<UserModel>>> PostUser()
        {

        }

        [HttpPut("PutUser")]
        public async Task<ActionResult<ResponseModel<UserModel>>> PutUser()
        {

        }
    }
}
