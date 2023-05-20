using APITests.Mocks;
using CodifinAPI.Controllers;
using CodifinAPI.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace APITests.Units
{
    public class UsersUnitTest
    {
        UsersController _Controller;
        IUsersService _UsersService;
        IJWTAuthenticationService _AuthenticationService;

        public UsersUnitTest()
        {
            _UsersService = new UserServiceMock();
            _AuthenticationService = new AuthenticationServiceMock();
            _Controller = new UsersController(_UsersService, _AuthenticationService);
        }

        [Fact]
        public void Users_Authenticate_OkResponse()
        {
            var OkResult = _Controller.Authenticate(new AuthenticationRequest
            {
                UserName = "bernardino.chin@gmail.com",
                Password = "FixedPassword"
            });

            var CodeResult = Assert.IsType<OkObjectResult>(OkResult as OkObjectResult);
            Assert.True(CodeResult.StatusCode == StatusCodes.Status200OK);
        }

        [Fact]
        public void Users_Authenticate_OkItemType()
        {
            var OkResult = _Controller.Authenticate(new AuthenticationRequest
            {
                UserName = "bernardino.chin@gmail.com",
                Password = "FixedPassword"
            });

            Assert.IsType<TokenResponse>((OkResult as OkObjectResult).Value);
        }

        [Fact]
        public void Users_Authenticate_OkItem()
        {
            var OkResult = _Controller.Authenticate(new AuthenticationRequest
            {
                UserName = "bernardino.chin@gmail.com",
                Password = "FixedPassword"
            });

            var Result = Assert.IsType<TokenResponse>((OkResult as OkObjectResult).Value);
            Assert.True(Result.Token != string.Empty);
            Assert.True(Result.RefreshToken != string.Empty);
        }

        [Fact]
        public void Users_RefreshToken_OkResponse()
        {
            var OkResult = _Controller.RefreshToken(new TokenRefreshRequest
            {
                Token = "FixedToken",
                RefreshToken = "FixedRefreshToken"
            });

            var CodeResult = Assert.IsType<OkObjectResult>(OkResult as OkObjectResult);
            Assert.True(CodeResult.StatusCode == StatusCodes.Status200OK);
        }

        [Fact]
        public void Users_RefreshToken_OkItemType()
        {
            var OkResult = _Controller.RefreshToken(new TokenRefreshRequest
            {
                Token = "FixedToken",
                RefreshToken = "FixedRefreshToken"
            });

            Assert.IsType<TokenResponse>((OkResult as OkObjectResult).Value);
        }

        [Fact]
        public void Users_RefreshToken_OkItem()
        {
            var OkResult = _Controller.RefreshToken(new TokenRefreshRequest
            {
                Token = "FixedToken",
                RefreshToken = "FixedRefreshToken"
            });

            var Result = Assert.IsType<TokenResponse>((OkResult as OkObjectResult).Value);
            Assert.True(Result.Token != string.Empty);
            Assert.True(Result.RefreshToken != string.Empty);
        }

        [Fact]
        public void Users_Post_OkResponse()
        {
            var OkResult = _Controller.Post(new UserRequest
            {
                UserName = "bernardino.chin@gmail.com",
                Name = "Bernardino Chin Chan",
                Password = "FixedPassword"
            });

            var CodeResult = Assert.IsType<OkObjectResult>(OkResult as OkObjectResult);
            Assert.True(CodeResult.StatusCode == StatusCodes.Status200OK);
        }

        [Fact]
        public void Users_Post_OkItemType()
        {
            var OkResult = _Controller.Post(new UserRequest
            {
                UserName = "bernardino.chin@gmail.com",
                Name = "Bernardino Chin Chan",
                Password = "FixedPassword"
            });

            Assert.IsType<UserResponse>((OkResult as OkObjectResult).Value);
        }

        [Fact]
        public void Users_Post_OkItem()
        {
            var OkResult = _Controller.Post(new UserRequest
            {
                UserName = "bernardino.chin@gmail.com",
                Name = "Bernardino Chin Chan",
                Password = "FixedPassword"
            });

            var Result = Assert.IsType<UserResponse>((OkResult as OkObjectResult).Value);
            Assert.True(Result.Id == 1);
            Assert.True(Result.Name != string.Empty);
            Assert.True(Result.UserName != string.Empty);
        }
    }
}
