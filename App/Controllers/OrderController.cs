using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class OrderController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetOrder(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            int result = 0;
            try
            {
                result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByCall(id, req, FunctionNames.GetOrder);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, true));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage CompleteOrder(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            int result = 0;
            try
            {
                result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByCall(id, req, FunctionNames.CompleteOrder);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, true));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
