using src.Dto;
using src.Models;

namespace src.Services.User
{
    public interface IUserService
    {
        Task<ResponseModel<List<UserModel>>> PostUser(UserDTO user);
        Task<ResponseModel<List<UserModel>>> DeleteUser(Guid id);
        Task<ResponseModel<UserModel>> PutUser(UserDTO user);

        Task<ResponseModel<UserModel>> GetUser(Guid id);

    }
}
