using System;

namespace Fgj.Cqrs.Domain.Interfaces.Validations
{
    public interface IUserValidation
    {
        Tuple<bool, string> IsDuplicateName(int id, string name);
    }
}
