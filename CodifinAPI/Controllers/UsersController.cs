using CodifinAPI.Models;
using DataLayer;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodifinAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUsersService _UserService;
        IJWTAuthenticationService _AuthenticationService;

        public UsersController(IUsersService UserService, IJWTAuthenticationService AuthenticationService)
        {
            _UserService = UserService;
            _AuthenticationService = AuthenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public ActionResult Authenticate([FromBody] AuthenticationRequest Request)
        {
            try
            {
                var User = _UserService.VerifyUser(Request.UserName, Request.Password);
                if (User == null)
                    return Unauthorized();

                var GeneratedToken = _AuthenticationService.GetToken(User.UserName);
                User.Token = GeneratedToken.Token;
                User.RefreshToken = GeneratedToken.RefreshToken;
                _UserService.UpdateUser(User);

                return Ok(new TokenResponse
                {
                    Token = GeneratedToken.Token,
                    RefreshToken = GeneratedToken.RefreshToken
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public ActionResult RefreshToken([FromBody] TokenRefreshRequest Request)
        {
            try
            {
                var UserName = _AuthenticationService.GetIdentity(Request.Token);
                if (string.IsNullOrWhiteSpace(UserName))
                    return Unauthorized();

                var ExistingUser = _UserService.GetUserByUserNameAndRefreshToken(UserName, Request.RefreshToken);
                if (ExistingUser == null || ExistingUser.RefreshToken != Request.RefreshToken)
                    return Unauthorized();

                var GeneratedToken = _AuthenticationService.RefreshToken(Request.Token);
                if (GeneratedToken == null)
                    return Unauthorized();

                ExistingUser.Token = GeneratedToken.Token;
                ExistingUser.RefreshToken = GeneratedToken.RefreshToken;
                _UserService.UpdateUser(ExistingUser);

                return Ok(new TokenResponse
                {
                    Token = GeneratedToken.Token,
                    RefreshToken = GeneratedToken.RefreshToken
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Post([FromBody] UserRequest User)
        {
            try
            {
                //Password should be encrypted.
                var Result = _UserService.CreateUser(new UserDTO()
                {
                    Name = User.Name,
                    UserName = User.UserName,
                    Password = User.Password
                });

                return Ok(new UserResponse
                {
                    Id = Result.Id,
                    Name = Result.Name,
                    UserName = Result.UserName
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
