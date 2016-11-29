using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLotterDal;
using MvcLotterModel;

namespace MvcLotterServicesLogic
{
   public class AwardsUserListLogic
    {
       private readonly  AwardsUserListData _awardsUserListData=new AwardsUserListData();
       
       /// <summary>
       /// 新增中奖纪录
       /// </summary>
       /// <param name="objEntity"></param>
       /// <returns></returns>
       public int InsertAwardsUserList(AwardsUserListEntity objEntity)
       {
           var data = _awardsUserListData.InsertAwardsUserList(objEntity);
           return data;
       }
       /// <summary>
       /// 中奖人员列表
       /// </summary>
       /// <param name="objEntity"></param>
       /// <returns></returns>
       public List<AwardsUserListEntity> GetAwardsUserPageList(AwardsUserListEntity objEntity)
       {
           var data = _awardsUserListData.GetAwardsUserPageList(objEntity);
           return data;
       }
    }
}
