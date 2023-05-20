using Domain;
using System;
using System.Linq;

namespace ServiceLayer
{
    public class UsersService : IUsersService
    {
        private DataLayer.CodifinDBContext _Context { get; set; }
        public UsersService(DataLayer.CodifinDBContext Context)
        {
            this._Context = Context;
        }

        public UserDTO CreateUser(UserDTO User)
        {
            try
            {
                DataLayer.User DataToSend = new DataLayer.User()
                {
                    Name = User.Name,
                    UserName = User.UserName,
                    Password = User.Password
                };
                _Context.Users.Add(DataToSend);
                _Context.SaveChanges();
                User.Id = DataToSend.Id;

                return User;
            }
            catch (Exception ex)
            {
                throw new PostsException(ex.InnerException.Message);
            }
        }

        public UserDTO VerifyUser(string UserName, string Password)
        {
            try
            {
                //Password should ideally be encrypted.
                var Result = _Context.Users
                    .SingleOrDefault(
                        u => u.UserName.ToLower() == UserName.ToLower()
                        && u.Password.ToLower() == Password);

                if (Result == null)
                    return null;

                return new UserDTO
                {
                    Id = Result.Id,
                    Name = Result.Name,
                    UserName = Result.UserName,
                    Password = Result.Password,
                    Token = Result.Token,
                    RefreshToken = Result.RefreshToken
                };
            }
            catch (Exception ex)
            {
                throw new UsersException(ex.InnerException.Message);
            }
        }

        public UserDTO UpdateUser(UserDTO User)
        {
            try
            {
                var Result = _Context.Users.SingleOrDefault(u => u.Id == User.Id);
                if (Result == null)
                    return null;

                Result.Name = User.Name;
                Result.UserName = User.UserName;
                Result.Password = User.Password;
                Result.Token = User.Token;
                Result.RefreshToken = User.RefreshToken;
                _Context.SaveChanges();

                return new UserDTO
                {
                    Id = Result.Id,
                    Name = Result.Name,
                    UserName = Result.UserName,
                    Password = Result.Password,
                    Token = Result.Token,
                    RefreshToken = Result.RefreshToken
                };
            }
            catch (Exception ex)
            {
                throw new UsersException(ex.InnerException.Message);
            }
        }

        public UserDTO GetUserByUserNameAndRefreshToken(string UserName, string RefreshToken)
        {
            try
            {
                var Result = _Context.Users
                    .SingleOrDefault(u => u.UserName.ToLower() == UserName.ToLower() && u.RefreshToken == RefreshToken);

                if (Result == null)
                    return null;

                return new UserDTO
                {
                    Id = Result.Id,
                    Name = Result.Name,
                    UserName = Result.UserName,
                    Password = Result.Password,
                    Token = Result.Token,
                    RefreshToken = Result.RefreshToken
                };
            }
            catch (Exception ex)
            {

                throw new UsersException(ex.InnerException.Message);
            }
        }
    }
}
