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
        //分页获取图书列表
        public List<BookInfo> GetList(int pageIndex, int pageSize)
        {
            return bookInfoDal.GetBookList(pageIndex,pageSize);
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
            try
            {
                if (bookInfo.BookGuid == "")
                {
                    bookInfo.BookGuid = GenerateIdentification(GetBookGuidList());
                    bookInfoDal.Inert(bookInfo);
                }
                else if (state == null)
                {
                    bookInfoDal.Update(bookInfo);
                }
                else
                {
                    bookInfoDal.Delete(bookInfo.BookGuid);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        //查询图书编号
        public List<string> GetBookGuidList()
        {
            return bookInfoDal.GetBookGuidList();
        }
        //生成编号
        public string GenerateIdentification(List<string> numberList)
        {
            List<int> number = new List<int>();
            foreach (var item in numberList)
            {
                number.Add(Convert.ToInt32(item));
            }
            number.Sort(); 
            string r1 = "KC";
            string r2 = (number.Last()+1).ToString("D4");
            string result = r1 + r2;
            return result;
        }
        //不分页获取所有图书
        public List<BookInfo> GetAllBookWithoutPaging()
        {
            List<BookInfo> bookList = bookInfoDal.SearchAllBookWithoutPaging();
            return bookList;
        }


    }

}

