using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCar.Orders.ParView
{
    public class CreateCoursePar
    {
        /// <summary>
        /// 原价
        /// </summary>
        public Int32 OldPrice { get; set; }   
        public string OldPriceStr { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        public Int32 RealPrice { get; set; }
        public string RealPriceStr { get; set; }
        /// <summary>
        /// 套餐购入来源
        /// </summary>
        public Int32 CourserSource { get; set; }
        /// <summary>
        /// 套餐编号
        /// </summary>
        public string CourseNo { get; set; }
        /// <summary>
        /// 客户手机号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 第三方券码或者订单号
        /// </summary>
        public string PartnerNoOrCode { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int? CityID { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
    }
}
