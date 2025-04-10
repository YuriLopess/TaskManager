namespace src.Models
{
    public class ResponseModel<T>
    {
        public T Data { get; set; } = default!;
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

    }
}
