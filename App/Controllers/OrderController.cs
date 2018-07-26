﻿using App.RequestObjectPatterns;
using App.Utils;
using System;
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
            var result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByCall(id, req, FunctionNames.GetOrder);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage CompleteOrder(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            var result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByCall(id, req, FunctionNames.CompleteOrder);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}
