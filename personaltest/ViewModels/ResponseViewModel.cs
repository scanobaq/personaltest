namespace personaltest.ViewModels
{
    public class ResponseViewModel<T> where T : class
    {
        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        public T? Result { get; set; }

        public int Id { get; set; }

    }
}