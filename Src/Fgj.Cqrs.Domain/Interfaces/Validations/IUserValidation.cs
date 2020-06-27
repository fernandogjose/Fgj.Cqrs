using System;

namespace Fgj.Cqrs.Domain.Interfaces.Validations
{
    public interface IUserValidation
    {
        Tuple<bool, string> IsDuplicateName(string guid, string name);
    }
}
