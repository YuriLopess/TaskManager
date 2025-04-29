using src.Dto;
using src.Models;

namespace src.Services.Task
{
    public interface ITaskService
    {
        Task<ResponseModel<List<TaskModel>>> DeleteTask (Guid id);
        Task<ResponseModel<List<TaskModel>>> PostTask(TaskDTO task);
        Task<ResponseModel<TaskModel>> PutTask(TaskDTO task);
        Task<ResponseModel<TaskModel>> GetTask(Guid id);
    }
}
