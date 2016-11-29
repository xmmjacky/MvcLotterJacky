using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLotterModel.ParView;

namespace MvcLotterModel
{
    public class AwardsListEntity : PageBase
    {
        public Int64 ID { get; set; }

        public string Awards { get; set; }

        public Int64 AwardsNum { get; set; }
        //已使用
        public Int64 UsedNum { get; set; }
        public string AwardsGoods { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
