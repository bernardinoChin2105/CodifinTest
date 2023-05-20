namespace Domain
{
    public interface IJWTAuthenticationService
    {
        public JWTTokenDTO RefreshToken(string ExpiredToken);
        public JWTTokenDTO GetToken(string UserName);
        public string GetIdentity(string ExpiredToken);
    }
}
