﻿using System.ComponentModel.DataAnnotations;

namespace PayFx.Unionpay.Domain
{
    public class ScanPayModel : BasePayModel
    {
        public ScanPayModel()
        {
            TxnType = "01";
            TxnSubType = "07";
            BizType = "000000";
        }

        /// <summary>
        /// 终端信息
        /// </summary>
        [StringLength(300, ErrorMessage = "终端信息最大长度为300位")]
        public string TermInfo { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string TermId { get; set; }
    }
}
