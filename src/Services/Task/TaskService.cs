using src.Dto;
using src.Models;

namespace src.Services.Task
{
    public class TaskService : ITaskService
    {
        public Task<ResponseModel<List<TaskModel>>> DeleteTask(Guid id)
        {
            throw new NotImplementedException();
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
