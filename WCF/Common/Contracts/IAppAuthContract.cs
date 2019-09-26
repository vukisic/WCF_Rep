using System.ServiceModel;

namespace Common.Contracts
{
    [ServiceContract]
    public interface IAppAuthContract
    {
        [OperationContract]
        bool IsAuthenticate(string username);
    }
}