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
    public class BookInfoService : BookInfoDal
    {
        //添加图书
        public bool AddBook(BookInfo bookInfo)
        {
            string sql = "insert into BookInfo values(@bookguid,@bookname,@booktype,@suitable,@buydate,@count,@remark)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@bookguid",bookInfo.BookGuid),
                new SqlParameter("@bookname", bookInfo.BookName),
                new SqlParameter("@booktype",bookInfo.BookType),
                new SqlParameter("@suitable", bookInfo.SuitAble),
                new SqlParameter("@buydate",bookInfo.BuyDate),
                new SqlParameter("@count", bookInfo.Count),
                new SqlParameter("@remark",bookInfo.Remark)
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
        //删除图书
        public bool DelBook(string bookGuid)
        {
            string sql = "delete from BookInfo where bookguid=@bookguid";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@bookguid",bookGuid),

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
        //修改图书
        public bool ModifyBookInfo(BookInfo bookInfo)
        {
            string sql = "update BookInfo set bookguid=@bookguid,bookname=@bookname,booktype=@booktype,suitable=@suitable,buydate=@buydate," +
                "count=@count,remark=@remark where bookguid=@bookguid";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@bookguid",bookInfo.BookGuid),
                new SqlParameter("@bookname", bookInfo.BookName),
                new SqlParameter("@booktype",bookInfo.BookType),
                new SqlParameter("@suitable", bookInfo.SuitAble),
                new SqlParameter("@buydate",bookInfo.BuyDate),
                new SqlParameter("@count", bookInfo.Count),
                new SqlParameter("@remark",bookInfo.Remark)
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

        public List<BookInfo> SelectAllBook()
        {
            List<BookInfo> bookList = new List<BookInfo>();
            string sql = "select * from BookInfo";
            SqlDataReader sqlDataReader = SqlHelper.ExecuteReader(sql, CommandType.Text);
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    BookInfo bookInfo = new BookInfo();
                    bookInfo.BookGuid = (string)sqlDataReader.GetValue(0);
                    bookInfo.BookName = (string)sqlDataReader.GetValue(1);
                    bookInfo.BookType = (int)sqlDataReader.GetValue(2);
                    bookInfo.SuitAble = (int)sqlDataReader.GetValue(3);
                    bookInfo.BuyDate = (DateTime)sqlDataReader.GetValue(4);
                    bookInfo.Count = (int)sqlDataReader.GetValue(5);
                    bookInfo.Remark = (string)sqlDataReader.GetValue(6);
                    bookList.Add(bookInfo);
                }

            }
            return bookList;
        }

        //根据图书名查询图书
        public BookInfo SelectOneBook(string bookName)
        {
            string sql = "select * from BookInfo where bookname=@bookname";
            SqlParameter pms = new SqlParameter("@bookname", bookName);
            BookInfo r = (BookInfo)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms);
            if (r != null)
            {
                return r;
            }
            else
            {
                return null;
            }
        }


    }
}



