using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using Common;
namespace DAL
{
    public class BorrowInfoDal
    {
        string selectSql = @"select * from BorrowInfo";
        //插入新数据
        public bool Inert(BorrowInfo entity)
        {

            string sql = "insert into BorrowInfo(bookname,useguid,borrowperson,handler,borrowcause,borrowdate,returndate,remark)" +
                "values(@bookname,@useguid,@borrowperson,@handler,@borrowcause,@borrowdate,@returndate,@remark)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@bookname",entity.BookName),
                new SqlParameter("@useguid",entity.UseGuid),
                new SqlParameter("@borrowperson",entity.BorrowPerson),
                new SqlParameter("@handler",entity.Handler),
                new SqlParameter("@borrowcause",entity.BorrowCause),
                new SqlParameter("@borrowdate",entity.BorrowDate),
                new SqlParameter("@returndate",entity.ReturnDate),
                new SqlParameter("@remark",entity.Remark),
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
        //更新数据
        public bool Update(BorrowInfo entity)
        {
            string sql = @"update BorrowInfo set bookname=@bookname,useguid=@useguid,borrowperson=@borrowperson,
            handler=@handler,borrowcause=@borrowcause,borrowdate=@borrowdate,returndate=@returndate,remark=@remark where useguid=@useguid";
            SqlParameter[] pms = new SqlParameter[]
           {
                new SqlParameter("@bookname",entity.BookName),
                new SqlParameter("@useguid",entity.UseGuid),
                new SqlParameter("@borrowperson",entity.BorrowPerson),
                new SqlParameter("@handler",entity.Handler),
                new SqlParameter("@borrowcause",entity.BorrowCause),
                new SqlParameter("@borrowdate",entity.BorrowDate),
                new SqlParameter("@returndate",entity.ReturnDate),
                new SqlParameter("@remark",entity.Remark),
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
        //删除操作
        public bool Delete(string useGuid)
        {
            string sql = @"delete from BorrowInfo where useguid=@useGuid";
            SqlParameter pms = new SqlParameter("@useguid", useGuid);
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
        //根据useguid获取实体对象
        public BorrowInfo GetBorrowInfo(string useGuid)
        {
            string sql = selectSql + " where useguid=@useguid";
            SqlParameter pms = new SqlParameter("@useguid", useGuid);
            SqlDataReader reader=SqlHelper.ExecuteReader(sql, CommandType.Text, pms);
            BorrowInfo borrowInfo = new BorrowInfo();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    borrowInfo.BookName = reader.GetString(0);
                    borrowInfo.UseGuid = reader.GetString(1);
                    borrowInfo.BorrowPerson = reader.GetString(2);
                    borrowInfo.Handler = reader.GetString(3);
                    borrowInfo.BorrowCause = reader.GetString(4);
                    borrowInfo.BorrowDate = reader.GetDateTime(5);
                    borrowInfo.ReturnDate = reader.GetDateTime(6);
                    borrowInfo.Remark = reader.GetString(7);
                }
            }
            return borrowInfo;
        }
        //获取数据库图书借阅信息列表
        public List<BorrowInfo> GetBorrowInfoList(int pageIndex, int pageSize)
        {
            string sql = selectSql+ " order by useguid offset(@pageIndex)*@pageSize rows fetch next 10 rows only";
            List<BorrowInfo> borrowInfoList = new List<BorrowInfo>();
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@pageIndex",pageIndex),
                new SqlParameter("@pageSize",pageSize)
            };
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text,pms);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    BorrowInfo borrowInfo = new BorrowInfo();
                    borrowInfo.BookName = reader.GetString(0);
                    borrowInfo.UseGuid = reader.GetString(1);
                    borrowInfo.BorrowPerson = reader.GetString(2);
                    borrowInfo.Handler = reader.GetString(3);
                    borrowInfo.BorrowCause = reader.GetString(4);
                    borrowInfo.BorrowDate = reader.GetDateTime(5);
                    borrowInfo.ReturnDate = reader.GetDateTime(6);
                    borrowInfo.Remark = reader.GetString(7);
                    borrowInfoList.Add(borrowInfo);
                }
            }
            return borrowInfoList;
        }
        //获取总共多少条数据
        public int GetCount()
        {
            string sql = @"select count(*) from BorrowInfo";
            int r = (int)SqlHelper.ExecuteScalar(sql, CommandType.Text);
            return r;
        }
        //查询借阅标识
        public List<string> GetUseGuidList()
        {
            string sql = @"select useguid from BorrowInfo";
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text);
            List<string> strList = new List<string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string str = reader.GetString(0).Substring(3);
                    strList.Add(str);
                }
            }
            return strList;
        }
    }
}
