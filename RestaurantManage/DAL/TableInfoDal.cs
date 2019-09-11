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
    public class TableInfoDal
    {
        string selectSql = "select * from TableInfo";
        /// <summary>
        /// 插入新数据
        /// </summary>
        /// <param name="entity">要插入的数据对象</param>
        /// <returns></returns>
        public bool Insert(TableInfo entity)
        {
            string sql = "insert into TableInfo(tableno,holdnum,isuse,notes) " +
                "values(@tableno,@holdnum,@isuse,@notes)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@tableno",entity.TableNo),
                new SqlParameter("@holdnum",entity.HoldNum),
                new SqlParameter("@isuse",entity.IsUse),
                new SqlParameter("@notes",entity.Notes)
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
        public bool Update(TableInfo entity)
        {
            string sql = @"update TableInfo set tableno=@tableno,holdnum=@holdnum,isuse=@isuse,notes=@notes where tableno=@tableno";
            SqlParameter[] pms = new SqlParameter[]
           {
                new SqlParameter("@tableno",entity.TableNo),
                new SqlParameter("@holdnum",entity.HoldNum),
                new SqlParameter("@isuse",entity.IsUse),
                new SqlParameter("@notes",entity.Notes)
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
        /// 删除数据
        /// </summary>
        /// <param name="tableNo">要删除的对象的编号</param>
        /// <returns></returns>
        public bool Delete(string tableNo)
        {
            string sql1 = "delete from TableInfo" +
                " where tableno = @tableno";
            SqlParameter pms1 = new SqlParameter("@tableno", tableNo);
            string sql2 = @"select count(*) from ReserveInfo where tableno = @tableno";
            SqlParameter pms2 = new SqlParameter("@tableno", tableNo);

            int r2 =(int) SqlHelper.ExecuteScalar(sql2, CommandType.Text,pms2);
            if (r2 > 0)
            {
                string sql3 = "delete from ReserveInfo where tableno = @tableno";
                SqlParameter pms3 = new SqlParameter("@tableno", tableNo);
                int r3 = SqlHelper.ExecuteNonQuery(sql3, CommandType.Text, pms3);
                int r1 = SqlHelper.ExecuteNonQuery(sql1, CommandType.Text, pms1);
                if (r1 > 0&&r3>0)
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
                int r1 = SqlHelper.ExecuteNonQuery(sql1, CommandType.Text, pms1);
                if (r1 > 0)
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
        /// 查询单个实体对象
        /// </summary>
        /// <param name="tableNo">要查询的对象的编号</param>
        /// <returns></returns>
        public TableInfo GetEntity(string tableNo)
        {
            string sql = selectSql + " where tableno=@tableno";
            SqlParameter pms = new SqlParameter("@tableno", tableNo);
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms);
            TableInfo tableInfo = new TableInfo();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableInfo.TableNo = reader.GetString(0);
                    tableInfo.HoldNum = reader.GetInt32(1);
                    tableInfo.IsUse = reader.GetInt32(2);
                    tableInfo.Notes = reader.GetString(3);
                }
            }
            reader.Close();
            return tableInfo;
        }
        /// <summary>
        /// 查询分页的餐桌信息列表
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页多少条</param>
        /// <returns></returns>
        public List<TableInfo> GetTableList(int pageIndex, int pageSize, string searchHoldNum, string searchIsUse)
        {
            string sql = null;
            if (string.IsNullOrEmpty(searchHoldNum) && string.IsNullOrEmpty(searchIsUse))
            {
                sql = selectSql + " order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";

            }
            else if (!string.IsNullOrEmpty(searchHoldNum) && string.IsNullOrEmpty(searchIsUse))
            {
                if (searchHoldNum == "1")
                {
                    sql = selectSql + " where holdnum=2 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                }
                else if (searchHoldNum == "2")
                {
                    sql = selectSql + " where holdnum=4 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                }
                else if (searchHoldNum == "3")
                {
                    sql = selectSql + " where holdnum=6 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                }
            }
            else if (!string.IsNullOrEmpty(searchHoldNum) && !string.IsNullOrEmpty(searchIsUse))
            {
                if (searchHoldNum == "1")
                {
                    if (searchIsUse == "1")
                    {
                        sql = selectSql + " where holdnum=2 and isuse=1 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                    }
                    else
                    {
                        sql = selectSql + " where holdnum=2 and isuse=0 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                    }
                }
                else if (searchHoldNum == "2")
                {

                    if (searchIsUse == "1")
                    {
                        sql = selectSql + " where holdnum=4 and isuse=1 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                    }
                    else
                    {
                        sql = selectSql + " where holdnum=4 and isuse=0 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                    }
                }
                else if (searchHoldNum == "3")
                {

                    if (searchIsUse == "1")
                    {
                        sql = selectSql + " where holdnum=6 and isuse=1 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                    }
                    else
                    {
                        sql = selectSql + " where holdnum=6 and isuse=0 order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
                    }
                }
            }
            List<TableInfo> tableList = new List<TableInfo>();
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
                    TableInfo tableInfo = new TableInfo();
                    tableInfo.TableNo = reader.GetString(0);
                    tableInfo.HoldNum = reader.GetInt32(1);
                    tableInfo.IsUse = reader.GetInt32(2);
                    tableInfo.Notes = reader.GetString(3);
                    tableList.Add(tableInfo);
                }
            }
            reader.Close();
            return tableList;
        }
        /// <summary>
        /// 查询餐桌信息表一共多少条数据
        /// </summary>
        /// <returns></returns>
        public int GetTableCount()
        {
            string sql = @"select count(*) from TableInfo";
            int r = (int)SqlHelper.ExecuteScalar(sql, CommandType.Text);
            return r;
        }
        /// <summary>
        /// 查询所有餐桌 获取里面的编号信息
        /// </summary>
        /// <returns></returns>
        public List<TableInfo> GetAllTableNo()
        {
            string sql = selectSql;
            List<TableInfo> tableList = new List<TableInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableInfo tableInfo = new TableInfo();
                    tableInfo.TableNo = reader.GetString(0);
                    tableInfo.HoldNum = reader.GetInt32(1);
                    tableInfo.IsUse = reader.GetInt32(2);
                    tableInfo.Notes = reader.GetString(3);
                    tableList.Add(tableInfo);
                }
            }
            reader.Close();
            return tableList;
        }
        /// <summary>
        /// 查询所有的餐桌编号
        /// </summary>
        /// <returns></returns>
        public List<string> SearchAllTableNo()
        {
            string sql = @"select tableno from TableInfo";
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
