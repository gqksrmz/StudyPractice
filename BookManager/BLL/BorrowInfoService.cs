using Common;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BLL
{
    public class BorrowInfoService : BorrowInfoDal
    {
        public bool AddNewBorrow(BorrowInfo borrowInfo)
        {
            string sql = "insert into BorrowInfo values(@bookname,@useguid,@borrowperson,@handler,@borrowcause,@borrowdate,@returndate,@remark)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@bookname",borrowInfo.BookName),
                new SqlParameter("@useguid",borrowInfo.UseGuid),
                new SqlParameter("@borrowperson",borrowInfo.BorrowPerson),
                new SqlParameter("@handler",borrowInfo.Handler),
                new SqlParameter("@borrowcause",borrowInfo.BorrowCause),
                new SqlParameter("@borrowdate",borrowInfo.BorrowDate),
                new SqlParameter("@returndate",borrowInfo.ReturnTime),
                new SqlParameter("@remark",borrowInfo.Remark)
            };
            int r = SqlHelper.ExecuteNonQuery(sql,CommandType.Text,pms);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DelBorrow(string bookName)
        {
            string sql = "delete from BorrowInfo where bookname=@bookname";
            SqlParameter pms = new SqlParameter("@bookname", bookName);
            int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text,pms);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<BorrowInfo> SearchAllBorrowInfo()
        {
            List<BorrowInfo> borrowList = new List<BorrowInfo>();
            string sql = "select * from BorrowInfo ";
            SqlDataReader sqlDataReader = SqlHelper.ExecuteReader(sql, CommandType.Text);
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    BorrowInfo borrowInfo = new BorrowInfo();
                    borrowInfo.BookName =(string)sqlDataReader.GetValue(0);
                    borrowInfo.UseGuid =(string)sqlDataReader.GetValue(1);
                    borrowInfo.BorrowPerson =(string)sqlDataReader.GetValue(2);
                    borrowInfo.Handler =(string)sqlDataReader.GetValue(3);
                    borrowInfo.BorrowCause =(string)sqlDataReader.GetValue(4);
                    borrowInfo.BorrowDate =(DateTime)sqlDataReader.GetValue(5);
                    borrowInfo.ReturnTime =(DateTime)sqlDataReader.GetValue(6);
                    borrowInfo.Remark =(string)sqlDataReader.GetValue(7);
                    borrowList.Add(borrowInfo);
                }
            }
            return borrowList;
        }

        public BorrowInfo SearchOneBorrow(string bookName)
        {
            string sql = "select * from BorrowInfo where bookname=@bookname";
            SqlParameter pms = new SqlParameter("@bookname", bookname);
            BorrowInfo borrowInfo = (BorrowInfo)SqlHelper.ExecuteScalar(sql, CommandType.Text,pms);
            return borrowInfo;
        }
    }
}
