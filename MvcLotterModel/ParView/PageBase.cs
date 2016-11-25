using System.Web;
namespace CNCar.Orders.ParView
{
    public class PageBase
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        public int PageSize { get; set; }

        //跳过序列中指定数量的元素
        public int Skip { get { return (PageIndex - 1)*PageSize; }}


        /// <summary>
        /// 构造函数给当前页和页数初始化
        /// </summary>
        public PageBase()
        {
            if (PageIndex == 0) PageIndex = 1;
            if (PageSize == 0) PageSize = 10;
        }


    
    }
}
