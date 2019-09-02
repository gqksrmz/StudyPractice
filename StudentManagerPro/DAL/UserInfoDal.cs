using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class UserInfoDal
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetList()
        {
            string sql = "select * from userinfo";
            DataTable da = SqlHelper.GetDataTable(sql, System.Data.CommandType.Text);
            List<UserInfo> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo userInfo = null;
                foreach (DataRow row in da.Rows)
                {
                    userInfo = new UserInfo();
                    LoadEntity(userInfo, row);
                    list.Add(userInfo);
                }
            }
            return list;
        }
        private void LoadEntity(UserInfo userInfo, DataRow row)
        {
            userInfo.userName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            userInfo.userPass = row["UserPass"] != DBNull.Value ? row["UserPass"].ToString() : string.Empty;
            userInfo.Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : string.Empty;
            userInfo.Id = Convert.ToInt32(row["ID"]);
            userInfo.RegTime = Convert.ToDateTime(row[]);
        }
    }
}
