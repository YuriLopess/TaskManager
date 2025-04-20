using src.Dto;
using src.Models;

namespace src.Services.User
{
    public class UserService : IUserService
    {
        public Task<ResponseModel<List<UserModel>>> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
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
