using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace APITests.Mocks
{
    class UserServiceMock : IUsersService
    {
        public UserDTO CreateUser(UserDTO User)
        {
            return new UserDTO()
            {
                Id = 1,
                UserName = "bernardino.chin@gmail.com",
                Name = "Bernardino Chin Chan",
                Password = "FixedPassword"
            };
        }

        public UserDTO GetUserByUserNameAndRefreshToken(string UserName, string Token)
        {
            return new UserDTO()
            {                
                Id = 1,
                UserName = "bernardino.chin@gmail.com",
                Name = "Bernardino Chin Chan",
                Password = "FixedPassword",
                Token="FixedToken",
                RefreshToken = "FixedRefreshToken"
            };
        }

        public UserDTO UpdateUser(UserDTO User)
        {
            return new UserDTO()
            {
                Id = 1,
                UserName = "bernardino.chin@gmail.com",
                Name = "Bernardino Chin Chan",
                Password = "FixedPassword",
                Token = "FixedToken",
                RefreshToken = "FixedRefreshToken"
            };
        }

        public UserDTO VerifyUser(string UserName, string Password)
        {
            return new UserDTO()
            {
                Id = 1,
                UserName = "bernardino.chin@gmail.com",
                Name = "Bernardino Chin Chan",
                Password = "FixedPassword",
                Token = "FixedToken",
                RefreshToken = "FixedRefreshToken"
            };
        }
    }
}
