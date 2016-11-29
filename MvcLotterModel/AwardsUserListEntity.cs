using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLotterModel.ParView;

namespace MvcLotterModel
{
    public class AwardsUserListEntity : PageBase
    {
        public Int64 ID { get; set; }

        public string UserNo { get; set; }

        public string UserName { get; set; }

        public string Department { get; set; }

        public string Awards { get; set; }

        public string AwardsGoods { get; set; }
    }
}
