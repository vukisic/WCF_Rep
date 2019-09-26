using Common.Models;
using System.ServiceModel;

namespace Common.Contracts
{
    [ServiceContract]
    public interface IUserAuthContract
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        string LogIn(LogInCredentials credentials);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        string Register(RegisterCredentials credentials);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        bool LogOut(string username);
    }
}