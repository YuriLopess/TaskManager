using src.Dto;
using src.Models;

namespace src.Services.User
{
    public interface IUserService
    {
        Task<ResponseModel<List<UserModel>>> PostUser(UserDTO model);
        Task<ResponseModel<List<UserModel>>> DeleteUser(Guid id);
        Task<ResponseModel<List<UserModel>>> PutUser(UserDTO model);

        Task<ResponseModel<List<UserModel>>> GetUser(Guid id);

    }
}
