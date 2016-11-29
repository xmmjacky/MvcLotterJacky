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
    public class AwardsUserListData
    {
        /// <summary>
        /// 添加中奖纪录
        /// </summary>
        /// <param name="objEntity"></param>
        /// <returns></returns>
        public int InsertAwardsUserList(AwardsUserListEntity objEntity)
        {
            string sql = @"insert into AwardsUserList (UserNo,UserName,Department,Awards,AwardsGoods) values (
            @UserNo,@UserName,@Department,@Awards,@AwardsGoods
            )";
            try
            {
                var paras = new SQLiteParameter[]
           {

                              new SQLiteParameter() { ParameterName = "@UserNo", DbType = DbType.String, Value = objEntity.UserNo },
                              new SQLiteParameter() { ParameterName = "@UserName", DbType = DbType.String, Value = objEntity.UserName },
                              new SQLiteParameter() { ParameterName = "@Department", DbType = DbType.String, Value = objEntity.Department },
                              new SQLiteParameter() { ParameterName = "@Awards", DbType = DbType.String, Value =objEntity.Awards },
                              new SQLiteParameter() { ParameterName = "@AwardsGoods", DbType = DbType.String, Value =objEntity.AwardsGoods },
           };
                var data = SQLiteHelper.ExecuteNonQuery(sql, paras);
                return data;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="objEntity"></param>
        /// <returns></returns>
        public List<AwardsUserListEntity> GetAwardsUserPageList(AwardsUserListEntity objEntity)
        {
            var wheresql = " where 1=1";
            if (!string.IsNullOrEmpty(objEntity.Awards))
            {
                wheresql += @" And Awards=@Awards";
            }

            var paras = new SQLiteParameter[]
           {

                    new SQLiteParameter() { ParameterName = "@Awards", DbType = DbType.String, Value =objEntity.Awards }
           };
            var strsql = @"select* from (select(select count(1) from AwardsUserList a";
            strsql += wheresql;
            strsql += @") As Total,a.* from AwardsUserList a";
            strsql += wheresql;
            strsql += @") as A order by ID desc";
            strsql = string.Format(strsql + " limit {0} offset {0}*{1}", objEntity.PageSize, objEntity.PageIndex - 1);
            //var strsql = string.Format("select * from Users order by ID limit {0} offset {0}*{1}", objUser.PageSize, objUser.PageIndex - 1);
            using (IDataReader dReader = SQLiteHelper.ExecuteReader(strsql, paras))
            {
                List<AwardsUserListEntity> userlist = GlobalFunction.GetEntityList<AwardsUserListEntity>(dReader);

                return userlist;
            }
        }
    }
}
