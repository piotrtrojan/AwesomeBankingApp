namespace AwesomeBankingApp.Authorization.Interfaces
{
    public interface IUserService
    {
        bool IsValidUser(string username, string password);
    }
}
