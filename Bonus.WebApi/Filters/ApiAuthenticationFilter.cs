using System.Threading;
using System.Web.Http.Controllers;
using Bonus.BusinessServices.Interfaces;
using Bonus.DataModel;

namespace Bonus.WebApi.Filters
{
    /// <summary>
    /// Custom Authentication Filter Extending basic Authentication
    /// </summary>
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        /// <summary>
        /// Default Authentication Constructor
        /// </summary>
        public ApiAuthenticationFilter()
        {
        }

        /// <summary>
        /// AuthenticationFilter constructor with isActive parameter
        /// </summary>
        /// <param name="isActive"></param>
        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }

        /// <summary>
        /// Protected overriden method for authorizing user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var provider = actionContext.ControllerContext.Configuration
                               .DependencyResolver.GetService(typeof(IUserServices)) as IUserServices;
            if (provider != null)
            {
                UsuarioEntity usuario = provider.Authenticate(username, password);
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity == null)
                    throw new System.ArgumentException("Thread.CurrentPrincipal.Identity", "Thread.CurrentPrincipal.Identity Exception");

                if (usuario !=null)
                {
                    basicAuthenticationIdentity.UserId = usuario.id;
                    return true;
                }
            }
            return false;
        }
    }
}