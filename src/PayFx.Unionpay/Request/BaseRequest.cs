﻿using System;
using PayFx.Http;

namespace PayFx.Unionpay.Request
{
    public class BaseRequest<TModel, TResponse> : Request<TModel, TResponse> where TResponse : IResponse
    {
        public BaseRequest()
            : base(StringComparer.Ordinal) { }

        public override void AddGatewayData(TModel model)
        {
            base.AddGatewayData(model);
            GatewayData.Add(model, StringCase.Camel);
        }

        internal virtual void Execute(Merchant merchant) { }
    }
}
