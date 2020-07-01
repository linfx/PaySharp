﻿using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayFx.Http;
using PayFx.Unionpay;
using PayFx.Unionpay.Domain;
using PayFx.Unionpay.Request;

namespace PayFx.Demo.Controllers
{
    public class UnionpayController : Controller
    {
        private readonly IGateway _gateway;

        public UnionpayController(IGateways gateways)
        {
            _gateway = gateways.Get<UnionpayGateway>();
        }

        [HttpPost]
        public async Task<ActionResult> WebPayAsync(string order_id, int total_amount)
        {
            var request = new WebPayRequest();
            request.AddGatewayData(new WebPayModel
            {
                TotalAmount = total_amount,
                OrderId = order_id
            });
            var response = await _gateway.ExecuteAsync(request);
            return Content(response.Html, "text/html", Encoding.UTF8);
        }

        [HttpPost]
        public async Task<ActionResult> WapPayAsync(string order_id, int total_amount)
        {
            var request = new WapPayRequest();
            request.AddGatewayData(new WapPayModel()
            {
                TotalAmount = total_amount,
                OrderId = order_id
            });

            var response = await _gateway.ExecuteAsync(request);
            return Content(response.Html, "text/html", Encoding.UTF8);
        }

        [HttpPost]
        public async Task<ActionResult> AppPayAsync(string order_id, int total_amount, string body)
        {
            var request = new AppPayRequest();
            request.AddGatewayData(new AppPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OrderId = order_id
            });
            var response = await _gateway.ExecuteAsync(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> ScanPayAsync(string order_id, int total_amount)
        {
            var request = new ScanPayRequest();
            request.AddGatewayData(new ScanPayModel()
            {
                TotalAmount = total_amount,
                OrderId = order_id
            });
            var response = await _gateway.ExecuteAsync(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> BarcodePayAsync(string order_id, string qr_no, int total_amount)
        {
            var request = new BarcodePayRequest();
            request.AddGatewayData(new BarcodePayModel()
            {
                TotalAmount = total_amount,
                OrderId = order_id,
                QrNo = qr_no
            });
            request.PaySucceed += BarcodePay_PaySucceed;
            request.PayFailed += BarcodePay_PayFaild;
            var response = await _gateway.ExecuteAsync(request);
            return Json(response);
        }

        /// <summary>
        /// 支付成功事件
        /// </summary>
        /// <param name="response">返回结果</param>
        /// <param name="message">提示信息</param>
        private void BarcodePay_PaySucceed(IResponse response, string message)
        {
        }

        /// <summary>
        /// 支付失败事件
        /// </summary>
        /// <param name="response">返回结果,可能是BarcodePayResponse/QueryResponse</param>
        /// <param name="message">提示信息</param>
        private void BarcodePay_PayFaild(IResponse response, string message)
        {
        }

        [HttpPost]
        public async Task<ActionResult> QueryAsync(string order_id, string query_id)
        {
            var request = new QueryRequest();
            request.AddGatewayData(new QueryModel()
            {
                OrderId = order_id,
                QueryId = query_id
            });
            var response = await _gateway.ExecuteAsync(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> RefundAsync(string order_id, int refund_amount, string orig_qry_id, string orig_order_id)
        {
            var request = new RefundRequest();
            request.AddGatewayData(new RefundModel()
            {
                OrderId = order_id,
                RefundAmount = refund_amount,
                OrigOrderId = orig_order_id,
                OrigQryId = orig_qry_id
            });
            var response = await _gateway.ExecuteAsync(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> CancelAsync(string order_id, int cancel_amount, string orig_qry_id, string orig_order_id)
        {
            var request = new CancelRequest();
            request.AddGatewayData(new CancelModel()
            {
                OrderId = order_id,
                CancelAmount = cancel_amount,
                OrigOrderId = orig_order_id,
                OrigQryId = orig_qry_id
            });
            var response = await _gateway.ExecuteAsync(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> BillDownloadAsync(string bill_date)
        {
            var request = new BillDownloadRequest();
            request.AddGatewayData(new BillDownloadModel()
            {
                BillDate = bill_date
            });
            var response = await _gateway.ExecuteAsync(request);
            return File(response.GetBillFile(), "application/zip");
        }
    }
}
