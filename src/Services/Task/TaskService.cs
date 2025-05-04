using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Dto;
using src.Models;
using src.Validators.Task;

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

        public async Task<ResponseModel<TaskModel>> GetTask(Guid id)
        {
            ResponseModel<TaskModel> response = new ResponseModel<TaskModel>();

            try
            {
                var user = await _context.Tasks.FirstOrDefaultAsync(taskDb => taskDb.Id == id);

                if(user == null)
                {
                    response.Message = "No records found";
                    return response;
                }

                response.Data = user;
                response.Message = "Record found!"; 
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> PostTask(TaskDTO taskDto)
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>();
            var validators = new TaskValidator();

            try
            {
                validators.ValidatorTitle(taskDto.Title);
                validators.ValidatorDescription(taskDto.Description);
               

                var task = new TaskModel(taskDto.Title, taskDto.Description, taskDto.Tag, taskDto.IdUser);

                _context.Tasks.Add(task); 
                await _context.SaveChangesAsync();

                response.Data = await _context.Tasks.ToListAsync();
                response.Message = "Task successfully registered!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> PutTask(TaskDTO taskDto)
        {
            ResponseModel<TaskModel> response = new ResponseModel<TaskModel>();

            var validators = new TaskValidator();

            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(TaskDb => TaskDb.Id == taskDto.Id);

                if (task == null)
                {
                    response.Message = "No records found";
                    return response;
                }

                validators.ValidatorTitle(taskDto.Title);
                validators.ValidatorDescription(taskDto.Title);

                task.Title = taskDto.Title;
                task.Description = taskDto.Description;

                _context.Tasks.Update(task);
                await _context.SaveChangesAsync();

                response.Data = task;
                response.Message = "Record edited successfully";

                return response;


            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
                
          
        }
    }
}
