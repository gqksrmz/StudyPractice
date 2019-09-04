using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class BookInfoDal
    {
        string selectSql = @"select * from BookInfo";
        //插入新数据
        public bool Inert(BookInfo entity)
        {
            string bookguid = Guid.NewGuid().ToString();
            entity.BookGuid = bookguid;
            string sql = "insert into BookInfo(bookguid,bookname,booktype,suitable,buydate,count,remark)" +
                "values(@bookguid,@bookname,@booktype,@suitable,@buydate,@count,@remark)";
            SqlParameter[] pms = new SqlParameter[]
            {
              new SqlParameter("@bookguid",entity.BookGuid),
              new SqlParameter("@bookname", entity.BookName),
              new SqlParameter("@booktype", entity.BookType),
              new SqlParameter("@suitable", entity.SuitAble),
              new SqlParameter("@buydate", entity.BuyDate),
              new SqlParameter("@count", entity.Count),
              new SqlParameter("@remark", entity.Remark),
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
        public bool Update(BookInfo entity)
        {
            string sql = @"update BookInfo set bookguid=@bookguid,bookname=@bookname,booktype=@booktype,suitable=@suitable,buydate=@buydate,count=@count,remark=@remark where bookguid=@bookguid";
            SqlParameter[] pms = new SqlParameter[]
           {
              new SqlParameter("@bookguid",entity.BookGuid),
              new SqlParameter("@bookname", entity.BookName),
              new SqlParameter("@booktype", entity.BookType),
              new SqlParameter("@suitable", entity.SuitAble),
              new SqlParameter("@buydate", entity.BuyDate),
              new SqlParameter("@count", entity.Count),
              new SqlParameter("@remark", entity.Remark),
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
        //删除数据
        public bool Delete(string bookGuid)
        {
            string sql = @"delete from BookInfo where bookguid=@bookguid";
            SqlParameter pms = new SqlParameter("@bookguid", bookGuid);
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
        //查询单个实体对象
        public BookInfo GetEntity(string bookGuid)
        {
            string sql = selectSql + " where bookguid=@bookguid";
            SqlParameter pms = new SqlParameter("@bookguid", bookGuid);
            BookInfo bookInfo = (BookInfo)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms);
            return bookInfo;
        }
        //获取图书列表
        public List<BookInfo> GetBookList()
        {
            string sql = selectSql;
            List<BookInfo> bookList = new List<BookInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    BookInfo bookInfo = new BookInfo();
                    bookInfo.BookGuid = reader.GetString(0);
                    bookInfo.BookName = reader.GetString(1);
                    bookInfo.BookType = reader.GetString(2);
                    bookInfo.SuitAble = reader.GetString(3);
                    bookInfo.BuyDate = reader.GetDateTime(4);
                    bookInfo.Count = reader.GetInt32(5);
                    bookInfo.Remark = reader.GetString(6);
                    bookList.Add(bookInfo);
                }
            }
            return bookList;

        }
        //获取总共多少条数据
        public int GetBookCount()
        {
            string sql = @"select count(*) from BookInfo";
            int r = (int)SqlHelper.ExecuteScalar(sql, CommandType.Text);
            return r;

        }
    }
}
