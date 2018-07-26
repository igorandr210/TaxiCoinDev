using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class DepositController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DepositPattern req)
        {
            var result = TokenFunctionsResults<UInt64, DepositPattern>.InvokeByTransaction(req, FunctionNames.Deposit,Value:req.Value,Gas:req.Gas);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}
