using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
