﻿using PayFx.Http;

namespace PayFx.Wechatpay.Response
{
    public class CancelResponse : BaseResponse
    {
        /// <summary>
        /// 是否重调
        /// </summary>
        public string Recall { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
