using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class PaymentController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetById(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            Crypto.DecryptTwoStringsAndGetContractFunctions(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase, out ContractFunctions contractFunctions);
            var res = contractFunctions.DeserializePaymentById(senderAddress, password, id).Result;
            return Request.CreateResponse<Payment>(System.Net.HttpStatusCode.OK,res,new HttpConfiguration());
        }
        [HttpPost]
        public HttpResponseMessage Create(UInt64 id, [FromBody] CreatePaymentPattern req)
        {
            var result = TokenFunctionsResults<int, CreatePaymentPattern>.InvokeByTransaction(req, FunctionNames.CreatePayment,new object[] { id, req.Value});

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}
