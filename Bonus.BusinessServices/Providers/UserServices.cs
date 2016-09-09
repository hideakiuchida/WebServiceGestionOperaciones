using Bonus.BusinessServices.Interfaces;
using Bonus.DataModel;
using Bonus.DataModel.UnitOfWork;

namespace Bonus.BusinessServices.Providers
{
    /// <summary>
    /// Offers services for user specific operations
    /// </summary>
    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Public method to authenticate user by user name and password.
        ///
        ///    0: Éxito
        ///    1: Usuario en blanco
        ///    2: Clave en blanco
        ///    3: Usuario no existe
        ///    4: Usuario no pertenece al grupo autorizado
        ///    5: Clave incorrecta
        ///    6: Usuario no tiene código de promotor
        ///  
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UsuarioEntity Authenticate(string userName, string password)
        {
            usuario _usuario = _unitOfWork.UserRepository.GetSingle(u => u.correo == userName && u.password == password);

            UsuarioEntity usuario = new UsuarioEntity();
            usuario.id = _usuario.id;
            usuario.nombre = _usuario.nombre;
            usuario.password = _usuario.password;
            return usuario;
        }
    }
}

