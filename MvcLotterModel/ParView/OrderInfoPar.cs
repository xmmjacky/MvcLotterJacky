using System;

namespace MvcLotterModel.ParView
{
    public class OrderInfoPar : PageBase
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public System.String OrderNo { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public System.Int32? CityID { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public string CityIDList { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public System.String CustomerPhone { get; set; }
       
        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime? CreateTimeEnd { get; set; }
        public DateTime? CreateTimeStart { get; set; }
        /// <summary>
        /// 预约日期
        /// </summary>
        public DateTime? BookStartTime { get; set; }
        public DateTime? BookEndTime { get; set; }
        /// <summary>
        /// 教练工号
        /// </summary>
        public System.String CoachNo { get; set; }
        /// <summary>
        /// 教练手机号
        /// </summary>
        public System.String CoachPhone { get; set; }
       
        /// <summary>
        /// 订单状态
        /// </summary>
        public System.Int32? OrderStatus { get; set; }
        /// <summary>
        /// 下单渠道
        /// </summary>
        public string InfoSource { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public Int32? OrderType { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public Int32? PayStatus { get; set; }
        /// <summary>
        /// 订单商品类型
        /// </summary>
        public Int32? ProductType { get; set; }
        /// <summary>
        /// 支付方类型
        /// </summary>
        
        public Int32? PayPeopleType { get; set; }
        /// <summary>
        /// 套餐编号
        /// </summary>
        public System.String CourseNo { get; set; }
    }
}
