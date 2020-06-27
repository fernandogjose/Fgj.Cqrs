namespace Fgj.Cqrs.Application.ViewModels
{
    public class ResponseViewModel
    {
        public bool Sucesso { get; private set; }

        public object Objeto { get; private set; }

        public ResponseViewModel(bool sucesso, object objeto)
        {
            Sucesso = sucesso;
            Objeto = objeto;
        }
    }
}
