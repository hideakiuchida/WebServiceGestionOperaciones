﻿using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using AttributeRouting.Web.Http;
using Bonus.BusinessServices.Interfaces;
using Bonus.WebApi.Filters;

namespace Bonus.WebApiServices.Controllers
{
    [ApiAuthenticationFilter]
    public class AuthenticateController : ApiController
    {
        #region Private variable.

        private readonly ITokenServices _tokenServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AuthenticateController(ITokenServices tokenServices)
        {
            _tokenServices = tokenServices;
        }

        #endregion

        /// <summary>
        /// Authenticates user and returns token with expiry.
        /// </summary>
        /// <returns></returns>
        /*[POST("login")]
        [POST("authenticate")]
        [POST("get/token")]*/
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Authenticate()
        {
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var userId = basicAuthenticationIdentity.UserId;
                    var codPro = basicAuthenticationIdentity.CodPro;
                    var usuNom = basicAuthenticationIdentity.UsuNom;
                    var resultCode = basicAuthenticationIdentity.ResultCode;
                    return GetAuthToken(userId, codPro, usuNom, resultCode);
                }
            }
            return null;
        }

        /// <summary>
        /// Returns auth token for the validated user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private HttpResponseMessage GetAuthToken(int userId, long? codPro, string usuNom, int resultCode)
        {
            var token = _tokenServices.GenerateToken(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("CodPro", codPro.ToString());
            response.Headers.Add("UsuNom", usuNom.ToString());
            response.Headers.Add("ResultCode", resultCode.ToString());
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry,CodPro,UsuNom,ResultCode");
            return response;
        }
    }
}

