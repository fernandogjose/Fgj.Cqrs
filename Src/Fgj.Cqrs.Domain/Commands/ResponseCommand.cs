namespace Fgj.Cqrs.Domain.Commands
{
    public class ResponseCommand
    {
        public bool Sucesso { get; }

        public object Objeto { get; }

        public ResponseCommand(bool sucesso, object objeto)
        {
            Sucesso = sucesso;
            Objeto = objeto;
        }
    }
}
