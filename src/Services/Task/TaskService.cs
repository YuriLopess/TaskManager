using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Dto;
using src.Models;

namespace src.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<ResponseModel<List<TaskModel>>> DeleteTask(Guid id)
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>(); 

            try
            {
                var task = _context.Tasks.FirstOrDefault(taskId => taskId.Id == id);

                if (task == null)
                {
                    response.Message = "No records found";
                    return response;
                }

                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();

                response.Data = await _context.Tasks.ToListAsync();
                response.Message = "Record deleted successfully";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<List<TaskModel>>> GetTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<TaskModel>>> PostTask(TaskDTO task)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<TaskModel>>> PutTask(TaskDTO task)
        {
            throw new NotImplementedException();
        }
    }
}
