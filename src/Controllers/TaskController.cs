using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ResponseModel<TaskModel>>> DeleteTask()
        {

        }

        [HttpPost("PostTask")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> PostTask()
        { 
        }

        [HttpPut("PutTask")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> PutTask()
        { 
        }
    }
}
