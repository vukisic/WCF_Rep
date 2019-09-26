namespace Server_App.Access
{
    public interface IAppRepository
    {
        bool Deposite(string username, double amount);

        bool Withdraw(string username, double amount);

        double State(string username);
    }
}