using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
