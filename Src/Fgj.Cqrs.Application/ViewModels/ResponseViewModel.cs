namespace Fgj.Cqrs.Application.ViewModels
{
    public class ResponseViewModel
    {
        public bool Success { get; private set; }

        public object Object { get; private set; }

        public ResponseViewModel(bool success, object obj)
        {
            Success = success;
            Object = obj;
        }
    }
}
