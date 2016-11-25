using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCar.Orders.ParView
{
    public class OrderPaySuccessPar
    {
        public string OrderNo { get; set; }
        public int? PayStatus { get; set; }
        public int? PayType { get; set; }
        public int? PayPeopleType { get; set; }
        public string MyCourseNo { get; set; }
        /// <summary>
        /// 优惠券编号
        /// </summary>
        public string CouponNo { get; set; }
        /// <summary>
        /// 优惠券编号
        /// </summary>
        public int? CouponAmount { get; set; }
        /// <summary>
        /// 订单实付金额
        /// </summary>
        public int? OrderRealAmount { get; set; }

    }
}
