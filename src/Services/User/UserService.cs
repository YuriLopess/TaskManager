using System.Net;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Dto;
using src.Models;

namespace src.Services.User
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context) {
            _context = context;
        }

        public async Task<ResponseModel<List<UserModel>>> DeleteUser(Guid id)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>();

            try 
            {
                var user = _context.Users.FirstOrDefault(userDb => userDb.Id == id);

                if (user == null)
                {
                    response.Message = "No records found";
                    return response;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
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

        public Task<ResponseModel<List<UserModel>>> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> PostUser(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> PutUser(UserDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
