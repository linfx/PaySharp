﻿using PayFx.Http;

namespace PayFx.Wechatpay.Response
{
    public class CloseResponse : BaseResponse
    {
        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
