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
            string sql = "insert into TableInfo(tableno,holdno,isuse,notes) " +
                "values(@tableno,@holdno,@isuse,@notes)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@tableno",entity.TableNo),
                new SqlParameter("@holdno",entity.HoldNum),
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
            string sql = @"update TableInfo set tableno=@tableno,holdno=@holdno,isuse=@isuse,notes=@notes where tableno=@tableno";
            SqlParameter[] pms = new SqlParameter[]
           {
                new SqlParameter("@tableno",entity.TableNo),
                new SqlParameter("@holdno",entity.HoldNum),
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
            string sql = "delete from TableInfo" +
                " where tableno = @tableno";
            SqlParameter pms1 = new SqlParameter("@tableno", tableNo);
            int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms1);
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
        public List<TableInfo> GetTableList(int pageIndex, int pageSize)
        {
            string sql = selectSql + " order by tableno offset(@pageIndex)*@pageSize rows fetch next @pageSize rows only";
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
    }
}
