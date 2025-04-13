using src.Models;

namespace src.Validators.Response
{
    public interface IResponseValidator 
    {
        void ValidateResponse<T>(ResponseModel<T> response);
    }
}
