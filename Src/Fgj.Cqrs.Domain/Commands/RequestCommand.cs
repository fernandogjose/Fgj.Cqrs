using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public abstract class RequestCommand
    {
        public List<string> Errors { get; protected set; }

        public abstract void Validate();

        public bool IsValid()
        {
            return Errors == null || Errors.Count == 0;
        }

        public void AddError(string error)
        {
            if (Errors == null) Errors = new List<string>(0);
            Errors.Add(error);
        }
    }
}
