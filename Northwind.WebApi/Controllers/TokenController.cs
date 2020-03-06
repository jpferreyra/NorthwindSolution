using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;
using Northwind.WebApi.Authentication;
using System;

namespace Northwind.WebApi.Controllers
{
    [Route("api/token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;

        private IUnitOfWork _unitOfWork;

        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public JSonWebToken Post([FromBody]User UserLogin)
        {
            var user = _unitOfWork.User.ValidateUser(UserLogin.Email, UserLogin.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var token = new JSonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddMinutes(30)),
                Expires_in = 30
            };
            return token;
        }
    }
}