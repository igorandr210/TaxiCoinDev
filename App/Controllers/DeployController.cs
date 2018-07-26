using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class DeployController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DeployControllerPattern req)
        {
            Crypto.DecryptTwoStringsAndGetContractFunctions(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase, out ContractFunctions contractFunctions);
            try
            {
                contractFunctions.DeployContract(senderAddress, password, req.Gas, req.TotalSupply);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, true));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
