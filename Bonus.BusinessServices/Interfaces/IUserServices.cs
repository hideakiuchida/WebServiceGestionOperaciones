
using Bonus.BusinessEntities.DTO;

namespace Bonus.BusinessServices.Interfaces
{
    public interface IUserServices
    {
        UsuarioEntity Authenticate(string userName, string password);
    }
}

