using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityServer.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFUserManagementService" in both code and config file together.
    [ServiceContract]
    public interface IWCFUserManagementService
    {
        [OperationContract]
        Task Register(string userName, string password);
    }
}
