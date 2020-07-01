﻿using PayFx.Wechatpay.Domain;
using PayFx.Wechatpay.Response;

namespace PayFx.Wechatpay.Request
{
    public class RefundRequest : BaseRequest<RefundModel, RefundResponse>
    {
        public RefundRequest()
        {
            RequestUri = "/secapi/pay/refund";
            IsUseCert = true;
        }
    }
}
