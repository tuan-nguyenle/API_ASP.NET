namespace ASP.Net.Services
{
    public class ServiceResults<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        //public List<string> ValidationErrors { get; set; } = [];
        public static ServiceResults<T> Success(T data) => new() { IsSuccess = true, Data = data };
        public static ServiceResults<T> Failure(string error) => new() { IsSuccess = false, ErrorMessage = error };
        //public static ServiceResults<T> ValidationFailure(List<string> errors) => new() { IsSuccess = false, ValidationErrors = errors };
    }
}
