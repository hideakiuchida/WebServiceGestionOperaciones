﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Bonus.BusinessServices.Interfaces;

namespace Bonus.WebApi.ActionFilters
{
    public static class StaticFirma
    {
        public static string FirmaParameter { get; set; }
        public static string Firma2Parameter { get; set; }
    }

    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = "Token";
        private const string Firma = "Firma";
        private const string Firma2 = "Firma2";

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //  Get API key provider
            var provider = filterContext.ControllerContext.Configuration
                .DependencyResolver.GetService(typeof(ITokenServices)) as ITokenServices;

            if (filterContext.Request.Headers.Contains(Firma))
            {
                StaticFirma.FirmaParameter = filterContext.Request.Headers.GetValues(Firma).First();
            }
            if (filterContext.Request.Headers.Contains(Firma2))
            {
                StaticFirma.Firma2Parameter = filterContext.Request.Headers.GetValues(Firma2).First();
            }

            if (filterContext.Request.Headers.Contains(Token))
            {
                var tokenValue = filterContext.Request.Headers.GetValues(Token).First();

                // Validate Token
                if (provider != null && !provider.ValidateToken(tokenValue))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                    filterContext.Response = responseMessage;
                }
            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(filterContext);

        }
    }
}