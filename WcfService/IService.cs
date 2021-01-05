using System;
using System.ServiceModel;

namespace WcfService
{

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetStatus();

        [OperationContract]
        bool Query(Guid id, string cityName);
    }
}

