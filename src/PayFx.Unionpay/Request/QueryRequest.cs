﻿using PayFx.Unionpay.Domain;
using PayFx.Unionpay.Response;

namespace PayFx.Unionpay.Request
{
    public class QueryRequest : BaseRequest<QueryModel, QueryResponse>
    {
        public QueryRequest()
        {
            RequestUri = "/gateway/api/queryTrans.do";
        }

        public override void AddGatewayData(QueryModel model)
        {
            if (!string.IsNullOrEmpty(model.OrderId))
            {
                model.TxnSubType = "00";
            }

            if (!string.IsNullOrEmpty(model.QueryId))
            {
                model.TxnSubType = "02";
            }

            base.AddGatewayData(model);
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("backUrl");
            GatewayData.Remove("frontUrl");
        }
    }
}
