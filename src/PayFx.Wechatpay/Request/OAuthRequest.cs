﻿using PayFx.Wechatpay.Domain;
using PayFx.Wechatpay.Response;

namespace PayFx.Wechatpay.Request
{
    public class OAuthRequest : BaseRequest<OAuthModel, OAuthResponse>
    {
        public OAuthRequest()
        {
            RequestUri = "https://api.weixin.qq.com/sns/oauth2/access_token";
        }

        internal override void Execute(Merchant merchant)
        {
            if (string.IsNullOrEmpty(merchant.AppSecret))
            {
                throw new PayFxException("请设置AppSecret");
            }

            GatewayData.Add("secret", merchant.AppSecret);
            GatewayData.Remove("notify_url");
            GatewayData.Remove("sign_type");
            GatewayData.Remove("mch_id");
        }
    }
}
