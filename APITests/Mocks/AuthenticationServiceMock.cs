using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace APITests.Mocks
{
    class AuthenticationServiceMock : IJWTAuthenticationService
    {    
        public string GetIdentity(string ExpiredToken)
        {
            return "bernardino.chin@gmail.com";
        }

        public JWTTokenDTO GetToken(string UserName)
        {
            return new JWTTokenDTO
            {
                Token = "FixedToken",
                RefreshToken = "FixedRefreshToken"
            };
        }

        public JWTTokenDTO RefreshToken(string ExpiredToken)
        {
            return new JWTTokenDTO
            {
                Token = "FixedNewToken",
                RefreshToken = "FixedNewRefreshToken"
            };
        }
    }
}
