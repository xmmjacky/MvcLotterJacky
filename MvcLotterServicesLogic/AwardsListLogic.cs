using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLotterDal;
using MvcLotterModel;

namespace MvcLotterServicesLogic
{
    public class AwardsListLogic
    {
        private readonly AwardsListData _awardsListData = new AwardsListData();

        public int InsertAwards(AwardsListEntity objEntity)
        {
            var data = _awardsListData.InsertAwards(objEntity);
            return data;
        }

        public AwardsListEntity GetAwardsListByAwards(string awards)
        {
            var data = _awardsListData.GetAwardsListByAwards(awards);
            return data;
        }

        public List<AwardsListEntity> GetAwardsListpageList(AwardsListEntity objEntity)
        {
            var data = _awardsListData.GetAwardsListpageList(objEntity);
            return data;
        }


        public int DelAwardsList(long id)
        {
            var data = _awardsListData.DelAwardsList(id);
            return data;
        }

        public int UpdateAwards(string awards)
        {
            var data = _awardsListData.UpdateAwards(awards);
            return data;
        }
    }
}
