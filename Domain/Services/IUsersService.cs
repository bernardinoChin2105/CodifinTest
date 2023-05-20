namespace Domain
{
    public interface IUsersService
    {
        public UserDTO CreateUser(UserDTO User);
        public UserDTO VerifyUser(string UserName, string Password);
        public UserDTO UpdateUser(UserDTO User);
        public UserDTO GetUserByUserNameAndRefreshToken(string UserName, string Token);
    }
}
