namespace Fgj.Cqrs.Application.Share.ViewModels
{
    public class ResponseViewModel
    {
        public bool Success { get; }

        public object Object { get; }

        public ResponseViewModel(bool success, object obj)
        {
            Success = success;
            Object = obj;
        }
    }
}
