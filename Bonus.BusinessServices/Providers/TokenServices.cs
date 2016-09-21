using Bonus.BusinessEntities;
using Bonus.BusinessServices.Interfaces;
using Bonus.DataModel;
using Bonus.DataModel.UnitOfWork;
using System;
using System.Configuration;
using System.Globalization;

namespace Bonus.BusinessServices.Providers
{
    public class TokenServices : ITokenServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public TokenServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Public member methods.

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenEntity GenerateToken(int userId)
        {
            string _token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            usuario _usuario = _unitOfWork.UserRepository.GetByID(userId);
            var tokenModel = new token()
            {
                userId = userId,
                issuedOn = issuedOn,
                expiresOn = expiredOn,
                authToken = _token,
                usuario = _usuario
            };

            _unitOfWork.TokenRepository.Insert(tokenModel);
            _unitOfWork.Save();

                    var tokenModel2 = new TokenEntity()
                    {
                        userId = userId,
                        issuedOn = issuedOn,
                        expiresOn = expiredOn,
                        authToken = _token
                    };

                    return tokenModel2;
        }

        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            token _token = _unitOfWork.TokenRepository.GetSingle(t => t.authToken == tokenId);
                var formats = new[] {
                  "yyyy.MM.dd HH:mm:ss",
                  "yyyy-MM-dd HH:mm:ss",
                  "yyyy/MM/dd HH:mm:ss",
                  "yyyy.MM.dd hh:mm:ss",
                  "yyyy-MM-dd hh:mm:ss",
                  "yyyy/MM/dd hh:mm:ss",
                  "dd.MM.yyyy HH:mm:ss",
                  "dd-MM-yyyy HH:mm:ss",
                  "dd/MM/yyyy HH:mm:ss",
                  "dd.MM.yyyy hh:mm:ss",
                  "dd-MM-yyyy hh:mm:ss",
                  "dd/MM/yyyy hh:mm:ss"
                };

                if (_token != null && !(DateTime.Now > _token.expiresOn))
                {
                    DateTime expiresOn = (DateTime) _token.expiresOn;
                    _token.expiresOn = expiresOn.AddSeconds(
                                                  Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));

                    _unitOfWork.TokenRepository.Update(_token);
                    _unitOfWork.Save();
                    return true;
                }

                return false;
        }

     
        #endregion
    }
}
