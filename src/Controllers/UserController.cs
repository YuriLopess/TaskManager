using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Dto;
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
            var user = await _service.GetUser(idUser);
            return Ok(user);  
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<ResponseModel<UserModel>>> DeleteUser(Guid id)
        {
            var user = await _service.DeleteUser(id);
            return Ok(user);
        }

        [HttpPost("PostUser")]
        public async Task<ActionResult<ResponseModel<UserModel>>> PostUser([FromBody] UserDTO userDto)
        {
            var user = await _service.PostUser(userDto);
            return Ok(user);
        }

        [HttpPut("PutUser")]
        public async Task<ActionResult<ResponseModel<UserModel>>> PutUser([FromBody] UserDTO userDto)
        {
            var user = await _service.PutUser(userDto);
            return Ok(user);
        }
    }
}
