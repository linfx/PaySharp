﻿namespace PayFx
{
    /// <summary>
    /// 未知网关事件数据
    /// </summary>
    public class UnknownGatewayEventArgs : NotifyEventArgs
    {
        /// <summary>
        /// 初始化未知网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public UnknownGatewayEventArgs(Gateway gateway)
            : base(gateway) { }
    }
}
