using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLotterModel;

namespace MvcLotterDal
{
    public class AwardsListData
    {
        public int InsertAwards(AwardsListEntity objEntity)
        {
            var sql =
                @"insert into AwardsList(Awards,AwardsNum,UsedNum,AwardsGoods,CreateTime) values(@Awards,@AwardsNum,@UsedNum,@AwardsGoods,@CreateTime)";
            try
            {
                var paras = new SQLiteParameter[]
           {

                    new SQLiteParameter() { ParameterName = "@Awards", DbType = DbType.String, Value =objEntity.Awards },
                              new SQLiteParameter() { ParameterName = "@AwardsNum", DbType = DbType.Int64, Value = objEntity.AwardsNum },
                              new SQLiteParameter() { ParameterName = "@UsedNum", DbType = DbType.Int64, Value = objEntity.UsedNum },
                              new SQLiteParameter() { ParameterName = "@AwardsGoods", DbType = DbType.String, Value = objEntity.AwardsGoods },
                              new SQLiteParameter() { ParameterName = "@CreateTime", DbType = DbType.DateTime, Value = DateTime.Now },
           };
                var data = SQLiteHelper.ExecuteNonQuery(sql, paras);
                return data;
            }
            catch (Exception)
            {

                return -1;
            }
        }
        /// <summary>
        /// 根据奖品等级获取该奖品设置信息
        /// </summary>
        /// <param name="awards"></param>
        /// <returns></returns>
        public AwardsListEntity GetAwardsListByAwards(string awards)
        {
            var sql = @"select* from AwardsList where awards=@awards";
            var paras = new SQLiteParameter[]
          {
                              new SQLiteParameter() { ParameterName = "@awards", DbType = DbType.String, Value = awards },
          };
            using (IDataReader dReader = SQLiteHelper.ExecuteReader(sql, paras))
            {
                List<AwardsListEntity> awardslist = GlobalFunction.GetEntityList<AwardsListEntity>(dReader);

                return awardslist != null ? awardslist[0] : null;
            }
        }
        /// <summary>
        /// 获取奖品设置等级分页列表
        /// </summary>
        /// <param name="objEntity"></param>
        /// <returns></returns>
        public List<AwardsListEntity> GetAwardsListpageList(AwardsListEntity objEntity)
        {
            var wheresql = " where 1=1";
            if (!string.IsNullOrEmpty(objEntity.Awards))
            {
                wheresql += @" And Awards=@Awards";
            }
            if (!string.IsNullOrEmpty(objEntity.AwardsGoods))
            {
                wheresql += @" And AwardsGoods=@AwardsGoods";
            }

            var paras = new SQLiteParameter[]
           {

                    new SQLiteParameter() { ParameterName = "@Awards", DbType = DbType.String, Value =objEntity.Awards },
                              new SQLiteParameter() { ParameterName = "@AwardsGoods", DbType = DbType.String, Value = objEntity.AwardsGoods },
                             
           };
            var strsql = @"select* from (select(select count(1) from AwardsList a";
            strsql += wheresql;
            strsql += @") As Total,a.* from AwardsList a";
            strsql += wheresql;
            strsql += @") as A order by ID desc";
            strsql = string.Format(strsql + " limit {0} offset {0}*{1}", objEntity.PageSize, objEntity.PageIndex - 1);
            using (IDataReader dReader = SQLiteHelper.ExecuteReader(strsql, paras))
            {
                List<AwardsListEntity> userlist = GlobalFunction.GetEntityList<AwardsListEntity>(dReader);

                return userlist;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelAwardsList(long id)
        {
            var strsql = @"Delete from AwardsList where ID=@ID";
            try
            {
                var paras = new SQLiteParameter[]
           {

                    new SQLiteParameter() { ParameterName = "@ID", DbType = DbType.Int64, Value =id },
           };
                var data = SQLiteHelper.ExecuteNonQuery(strsql, paras);
                return data;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }
        /// <summary>
        /// 更新奖品数量
        /// </summary>
        /// <param name="awards"></param>
        /// <returns></returns>
        public int UpdateAwards(string awards)
        {
            var strsql = @"update AwardsList set UsedNum=UsedNum-1 where Awards=@Awards";
            try
            {
                var paras = new SQLiteParameter[]
           {

                    new SQLiteParameter() { ParameterName = "@Awards", DbType = DbType.String, Value =awards }
           };
                var data = SQLiteHelper.ExecuteNonQuery(strsql, paras);
                return data;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }
    }
}
