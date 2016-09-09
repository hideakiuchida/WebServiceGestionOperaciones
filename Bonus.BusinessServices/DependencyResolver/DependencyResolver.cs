﻿using System.ComponentModel.Composition;
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
            registerComponent.RegisterType<IUserServices, UserServices>();
            registerComponent.RegisterType<ITokenServices, TokenServices>();
            //General Services
        }
    }
}
