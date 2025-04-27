using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Dto;
using src.Models;
using src.Validators.User;

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
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

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

        public async Task<ResponseModel<UserModel>> GetUser(Guid id)
        {
            ResponseModel<UserModel> response = new ResponseModel<UserModel>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userDb => userDb.Id == id);

                if (user == null)
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

        public async Task<ResponseModel<List<UserModel>>> PostUser(UserDTO userDto)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
            var validator = new UserValidator();

            try
            {
                validator.validatorEmail(userDto.Email);
                validator.validatorUsername(userDto.Username);

                var user = new UserModel(userDto.Username, userDto.Email);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                response.Data= await _context.Users.ToListAsync();
                response.Message = "User successfully registered!";
                return response;

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UserModel>> PutUser(UserDTO userDto)
        {
            ResponseModel<UserModel> response = new ResponseModel<UserModel>();
            var validator = new UserValidator();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userDb => userDb.Id == userDto.Id);

                if (user == null)
                {
                    response.Message = "No records found";
                    return response;
                }

                validator.validatorUsername(user.Username);
                validator.validatorEmail(userDto.Email);

                user.Email = userDto.Email;
                user.Username = userDto.Username;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                response.Data = user;
                response.Message = "Record edited successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
