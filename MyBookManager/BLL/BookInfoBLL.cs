using Common;
using DAL;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookInfoBLL
    {
        BookInfoDal bookInfoDal = new BookInfoDal();
        //增
        public bool Insert(BookInfo entity)
        {
            return bookInfoDal.Inert(entity);
        }
        //改
        public bool Update(BookInfo entity)
        {
            return bookInfoDal.Update(entity);
        }
        //删除
        public bool Delete(string bookGuid)
        {
            return bookInfoDal.Delete(bookGuid);
        }
        //根据bookguid获取单个实体
        public BookInfo GetEntity(string bookGuid)
        {
            return bookInfoDal.GetEntity(bookGuid);
        }
        //获取图书列表
        public List<BookInfo> GetList()
        {
            return bookInfoDal.GetBookList();
        }
        //获取总共多少图书
        public int GetBookCount()
        {
            return bookInfoDal.GetBookCount();
        }
        //事务
        public bool SaveBook(Object obj, string state)
        {
            BookInfo bookInfo = (BookInfo)obj;
            using (var conn = SqlHelper.GetSqlConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    if (bookInfo.BookGuid == "")
                    {
                        bookInfo.BookGuid= Guid.NewGuid().ToString();
                        bookInfoDal.Inert(bookInfo);
                    }
                    else if (state ==null)
                    {
                        bookInfoDal.Update(bookInfo);

                    }
                    else 
                    {
                        bookInfoDal.Delete(bookInfo.BookGuid);
                    }
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    return false;
                }
                return true;
            }

        }

    }
}
