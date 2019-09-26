using System.ServiceModel;

namespace Common.Contracts
{
    [ServiceContract]
    public interface IUserAccountContract
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        bool Deposite(string token, double amount);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        bool Withdraw(string token, double amount);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        double State(string token);
    }
}