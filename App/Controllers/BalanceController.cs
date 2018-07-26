using App.RequestObjectPatterns;
using App.Utils;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class BalanceController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DefaultControllerPattern req)
        {
            Crypto.DecryptTwoStringsAndGetContractFunctions(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase, out ContractFunctions contractFunctions);
            var res = contractFunctions.CallFunctionByName<System.UInt64>(senderAddress, password, FunctionNames.Balance, senderAddress).Result;
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, res.ToString());
        }
    }
}
