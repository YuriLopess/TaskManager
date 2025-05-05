using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Dto;
using src.Models;
using src.Services.Task;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet("GetTask/{idTask}")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> GetTask(Guid idTask)
        {
            var task = await _service.GetTask(idTask);
            return Ok(task);  
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> DeleteTask(Guid idTask)
        {
            var user = await _service.DeleteTask(idTask);
            return Ok(user);
        }

        [HttpPost("PostTask")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> PostTask([FromBody] TaskDTO taskDto)
        {
            var user = await _service.PostTask(taskDto);
            return Ok(user);
        }

        [HttpPut("PutTask")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> PutTask([FromBody] TaskDTO taskDto)
        { 
            var user = await _service.PutTask(taskDto);
            return Ok(user);   
        }
    }
}
