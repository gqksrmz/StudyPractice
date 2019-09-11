using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReserveInfoDal
    {
        string selectSql = "select * from ReserveInfo";
        /// <summary>
        /// 插入新数据
        /// </summary>
        /// <param name="entity">要插入的数据对象</param>
        /// <returns></returns>
        public bool Insert(ReserveInfo entity)
        {
            string sql = "insert into ReserveInfo(reserveno,tableno,peoplenum,starttime,endtime,reservestatus,notes) " +
                "values(@reserveno,@tableno,@peoplenum,@starttime,@endtime,@reservestatus,@notes)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@reserveno",entity.ReserveNo),
                new SqlParameter("@tableno",entity.TableNo),
                new SqlParameter("@peoplenum",entity.PeopleNum),
                new SqlParameter("@starttime",entity.StartTime),
                new SqlParameter("@endtime",entity.EndTime),
                new SqlParameter("@reservestatus",entity.ReserveStatus),
                new SqlParameter("@notes",entity.Notes),
            };
            int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">要更新的数据对象</param>
        /// <returns></returns>
        public bool Update(ReserveInfo entity)
        {
            string sql = @"update ReserveInfo set reserveno=@reserveno,tableno=@tableno,peoplenum=@peoplenum,starttime=@starttime,endtime=@endtime,reservestatus=@reservestatus,notes=@notes where reserveno=@reserveno";
            SqlParameter[] pms = new SqlParameter[]
             {
                new SqlParameter("@reserveno",entity.ReserveNo),
                new SqlParameter("@tableno",entity.TableNo),
                new SqlParameter("@peoplenum",entity.PeopleNum),
                new SqlParameter("@starttime",entity.StartTime),
                new SqlParameter("@endtime",entity.EndTime),
                new SqlParameter("@reservestatus",entity.ReserveStatus),
                new SqlParameter("@notes",entity.Notes),
             };
            if (entity.ReserveStatus == 1)
            {
                string sql2 = @"update TableInfo set isuse=1 where  tableno=@tableno";
                SqlParameter pms2 = new SqlParameter("@tableno", entity.TableNo);
                int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
                int r2 = SqlHelper.ExecuteNonQuery(sql2, CommandType.Text, pms2);
                if (r > 0 && r2 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(entity.ReserveStatus == 0)
            {
                string sql2 = @"update TableInfo set isuse=0 where  tableno=@tableno";
                SqlParameter pms2 = new SqlParameter("@tableno", entity.TableNo);
                int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
                int r2 = SqlHelper.ExecuteNonQuery(sql2, CommandType.Text, pms2);
                if (r > 0 && r2 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (entity.ReserveStatus == 2)
            {
                string sql2 = @"update TableInfo set isuse=0 where  tableno=@tableno";
                SqlParameter pms2 = new SqlParameter("@tableno", entity.TableNo);
                int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
                int r2 = SqlHelper.ExecuteNonQuery(sql2, CommandType.Text, pms2);
                if (r > 0 && r2 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="reserveNo">要删除的对象的编号</param>
        /// <returns></returns>
        public bool Delete(string reserveNo)
        {
            string sql = "delete from ReserveInfo" +
                " where reserveno = @reserveno";
            SqlParameter pms1 = new SqlParameter("@reserveno", reserveNo);
            string sql2 = @"update TableInfo set isuse=0 where tableno=(select tableno from ReserveInfo where reserveno = @reserveno)";
            SqlParameter pms2 = new SqlParameter("@reserveno", reserveNo);

            int r2 = SqlHelper.ExecuteNonQuery(sql2, CommandType.Text, pms2);
            int r1= SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms1);
            if (r1 > 0&&r2>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ReserveInfo GetEntityByReserveNo(string reserveNo)
        {
            string sql = selectSql + " where reserveno=@reserveno";
            SqlParameter pms = new SqlParameter("@reserveno", reserveNo);
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms);
            ReserveInfo reserveInfo = new ReserveInfo();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reserveInfo.ReserveNo = reader.GetString(0);
                    reserveInfo.TableNo = reader.GetString(1);
                    reserveInfo.PeopleNum = reader.GetInt32(2);
                    reserveInfo.StartTime = reader.GetDateTime(3);
                    reserveInfo.EndTime = reader.GetDateTime(4);
                    reserveInfo.ReserveStatus = reader.GetInt32(5);
                    reserveInfo.Notes = reader.GetString(6);
                }
            }
            reader.Close();
            return reserveInfo;
        }
        /// <summary>
        /// 查询单个实体对象
        /// </summary>
        /// <param name="reserveNo">要查询的对象的编号</param>
        /// <returns></returns>
        public ReserveInfo GetEntityByTableNo(string tableNo)
        {
            string sql = selectSql + " where tableno=@tableno";
            SqlParameter pms = new SqlParameter("@tableno", tableNo);
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms);
            ReserveInfo reserveInfo = new ReserveInfo();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reserveInfo.ReserveNo = reader.GetString(0);
                    reserveInfo.TableNo = reader.GetString(1);
                    reserveInfo.PeopleNum = reader.GetInt32(2);
                    reserveInfo.StartTime = reader.GetDateTime(3);
                    reserveInfo.EndTime = reader.GetDateTime(4);
                    reserveInfo.ReserveStatus = reader.GetInt32(5);
                    reserveInfo.Notes = reader.GetString(6);
                }
            }
            reader.Close();
            return reserveInfo;
        }
        /// <summary>
        /// 查询分页的餐桌信息列表
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页多少条</param>
        /// <returns></returns>
        public List<ReserveInfo> GetReserveList(int pageIndex, int pageSize)
        {
            string sql = selectSql + " order by starttime desc offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
            List<ReserveInfo> reserveList = new List<ReserveInfo>();
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@pageSize", pageSize)
            };
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ReserveInfo reserveInfo = new ReserveInfo();
                    reserveInfo.ReserveNo = reader.GetString(0);
                    reserveInfo.TableNo = reader.GetString(1);
                    reserveInfo.PeopleNum = reader.GetInt32(2);
                    reserveInfo.StartTime = reader.GetDateTime(3);
                    reserveInfo.EndTime = reader.GetDateTime(4);
                    reserveInfo.ReserveStatus = reader.GetInt32(5);
                    reserveInfo.Notes = reader.GetString(6);
                    reserveList.Add(reserveInfo);
                }
            }
            reader.Close();
            return reserveList;
        }
        /// <summary>
        /// 查询餐桌信息表一共多少条数据
        /// </summary>
        /// <returns></returns>
        public int GetReserveCount()
        {
            string sql = @"select count(*) from ReserveInfo";
            int r = (int)SqlHelper.ExecuteScalar(sql, CommandType.Text);
            return r;
        }
        /// <summary>
        /// 根据人数查询没有使用的桌子编号
        /// </summary>
        /// <param name="peopleNum"></param>
        /// <returns></returns>
        public List<string> SearchTable(string peopleNum)
        {
            string sql = @"select tableno from TableInfo where tableno like '" + peopleNum + "%' and isuse=0";
            List<string> tableNoList = new List<string>();
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableNoList.Add(reader.GetString(0));
                }
            }
            reader.Close();
            return tableNoList;
        }
    }
}
