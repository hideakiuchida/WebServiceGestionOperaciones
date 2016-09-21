using System.ComponentModel.Composition;
using Bonus.BusinessServices.Interfaces;
using Bonus.BusinessServices.Providers;
using UnityResolver;

namespace Bonus.BusinessServices.DependecyResolver
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            //Basic Authentication Services
            registerComponent.RegisterType<IUsuarioServices, UsuarioServices>();
            registerComponent.RegisterType<ITokenServices, TokenServices>();
            //General Services
            registerComponent.RegisterType<IFotoServices, FotoServices>();
            registerComponent.RegisterType<IInspeccionServices, InspeccionServices>();
            registerComponent.RegisterType<IOrdenServices, OrdenServices>();
        }
    }
}
