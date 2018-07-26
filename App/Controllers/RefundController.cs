using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class RefundController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Create(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            int result;
            try
            {
                result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByCall(id, req, FunctionNames.Refund);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, true));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage Approve(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            int result;
            try
            {
                result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByCall(id, req, FunctionNames.ApproveRefund);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, true));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
