using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public abstract class RequestCommand
    {
        public List<string> Erros { get; protected set; }

        public abstract void Validar();

        public bool TemErro()
        {
            return Erros?.Count > 0;
        }
    }
}
