using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCar.Orders.ParView
{
    public class DSOrderPayStatusPar
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public int? PayStatus { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int? PayType { get; set; }
        /// <summary>
        /// 支付方类型
        /// </summary>
        public int? PayPeopleType { get; set; }
    }
}
