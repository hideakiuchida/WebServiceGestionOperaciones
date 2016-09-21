﻿using System.Security.Principal;

namespace Bonus.WebApi.Filters
{
    /// <summary>
    /// Basic Authentication identity
    /// </summary>
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        /// <summary>
        /// Get/Set for password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Get/Set for UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Get/Set for UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// ■ ■ ■ ■ ■ Get/Set for ResultCode for Bonus ■ ■ ■ ■ ■
        /// </summary>
        public int ResultCode { get; set; }
        /// <summary>
        /// ■ ■ ■ ■ ■ Get/Set for CodPro for Bonus ■ ■ ■ ■ ■
        /// </summary>
        public long? CodPro { get; set; }
        /// <summary>
        /// ■ ■ ■ ■ ■ Get/Set for Tipo for Bonus ■ ■ ■ ■ ■
        /// </summary>
        public int Tipo { get; set; }
        /// <summary>
        /// Basic Authentication Identity Constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public BasicAuthenticationIdentity(string userName, string password)
            : base(userName, "Basic")
        {
            Password = password;
            UserName = userName;
        }
    }
}