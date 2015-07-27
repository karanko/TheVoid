using System;
using System.ServiceModel;

namespace WCFTest
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetString();
    }
}