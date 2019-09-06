using BLL;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web
{
    public class AjaxService : BaseService
    {
        BookInfoBLL bookInfoBLL = new BookInfoBLL();
        BorrowInfoBLL borrowInfoBLL = new BorrowInfoBLL();
        public AjaxService(HttpRequest Request, HttpResponse Response)
            : base(Request, Response)
        {

        }
        //查询所有图书
        public void SearchAllBook()
        {
            //string key,string beginDate,string endDate
            string strKey = GetString("SelectBookType");
            string begin = GetString("BeginDate");
            string end = GetString("EndDate");
            DateTime? beginDate = null;
            DateTime? endDate = null;
            if (!string.IsNullOrEmpty(begin) && !string.IsNullOrEmpty(end))
            {
                beginDate = Convert.ToDateTime(begin);
                endDate = Convert.ToDateTime(end);
            }
            else if (string.IsNullOrEmpty(begin) && !string.IsNullOrEmpty(end))
            {
                endDate = Convert.ToDateTime(end);
            }
            else if (!string.IsNullOrEmpty(begin) && string.IsNullOrEmpty(end))
            {
                beginDate = Convert.ToDateTime(begin);
            }
            string key = null;
            if (strKey == "电子科技")
            {
                key = "1";
            }
            else if (strKey == "人文生活")
            {
                key = "2";
            }
            else if (strKey == "时尚周刊")
            {
                key = "3";
            }
            else if (strKey == "艺术鉴赏")
            {
                key = "4";
            }
            //分页
            int pageIndex = GetInt("pageIndex");
            int pageSize = GetInt("pageSize");
            List<BookInfo> bookInfo = bookInfoBLL.GetList(pageIndex, pageSize, key, beginDate, endDate);
            List<BookInfo> bookInfoList = new List<BookInfo>();
            foreach (var item in bookInfo)
            {
                BookInfo book = new BookInfo();
                book = item;
                book.BookName = book.BookName.Substring(book.BookName.LastIndexOf('-') + 1);
                bookInfoList.Add(book);
            }
            int total = bookInfoBLL.GetBookCount();
            Hashtable result = new Hashtable();
            result["data"] = bookInfoList;
            result["total"] = total;
            RenderJson(result);
        }
        //保存图书
        public void SaveBooks()
        {
            ArrayList arrayList = (ArrayList)GetObject("data");
            BookInfo bookInfo = new BookInfo();
            foreach (var item in arrayList)
            {
                Hashtable i = (Hashtable)item;
                bookInfo.BookGuid = (string)i["BookGuid"];
                bookInfo.BookName = (string)i["BookNameList"] + "-" + (string)i["BookName"];
                bookInfo.BookType = (string)i["BookType"];
                bookInfo.SuitAble = (string)i["SuitAble"];
                bookInfo.BuyDate = (DateTime)i["BuyDate"];
                bookInfo.Count = Convert.ToInt32(i["Count"]);
                bookInfo.Remark = (string)i["Remark"];
            }
            string status = GetString("status");
            bool r = bookInfoBLL.SaveBook(bookInfo, status);
            if (r)
            {
                Response.Write("成功!");
            }
            else
            {
                Response.Write("失败！");
            }
        }
        //根据useGuid删除图书
        public void RemoveBook()
        {
            string bookGuid = GetString("bookGuid");
            bool r = bookInfoBLL.Delete(bookGuid);
            if (r)
            {
                Response.Write("成功!");
            }
            else
            {
                Response.Write("失败！");
            }
        }
        //根据useGuid获取单个图书
        public void GetBook()
        {
            string bookNameList = null;
            string bookGuid = GetString("bookGuid");
            BookInfo book = bookInfoBLL.GetEntity(bookGuid);
            string name = book.BookName;
            book.BookName = book.BookName.Substring(book.BookName.LastIndexOf("-") + 1);
            bookNameList = name.Substring(0, name.Length - book.BookName.Length - 1);
            Hashtable hs = new Hashtable();
            hs["BookNameList"] = bookNameList;
            hs["BookName"] = book.BookName;
            hs["BookGuid"] = book.BookGuid;
            hs["BookType"] = book.BookType;
            hs["BuyDate"] = book.BuyDate;
            hs["Count"] = book.Count;
            hs["Remark"] = book.Remark;
            hs["SuitAble"] = book.SuitAble;
            RenderJson(hs);
        }
        //查询所有图书借阅信息
        public void SearchAllBorrowInfo()
        {
            string key = GetString("key");
            if (!string.IsNullOrEmpty(key))
            {
                int pageIndex = GetInt("pageIndex");
                int pageSize = GetInt("pageSize");
                List<BorrowInfo> borrowInfoList = borrowInfoBLL.GetBorrowInfoByKey(key, pageIndex, pageSize);
                RenderJson(borrowInfoList);
            }
            else
            {
                //分页
                int pageIndex = GetInt("pageIndex");
                int pageSize = GetInt("pageSize");
                List<BorrowInfo> borrowList = borrowInfoBLL.GetList(pageIndex, pageSize);
                List<BorrowInfo> borroInfoList = new List<BorrowInfo>();
                foreach (var item in borrowList)
                {
                    BorrowInfo borrow = new BorrowInfo();
                    borrow = item;
                    borrow.BookName = borrow.BookName.Substring(borrow.BookName.LastIndexOf('-') + 1);
                    borroInfoList.Add(borrow);
                }
                int total = borrowInfoBLL.GetBorrowInfoCount();
                Hashtable result = new Hashtable();
                result["data"] = borroInfoList;
                result["total"] = total;
                RenderJson(result);
            }
        }
        //保存所有借阅信息
        public void SaveBorrowInfo()
        {
            ArrayList arrayList = (ArrayList)GetObject("data");
            BorrowInfo borrowInfo = new BorrowInfo();
            string status = GetString("status");
            foreach (var item in arrayList)
            {
                Hashtable i = (Hashtable)item;
                borrowInfo.BookName = (string)i["BookName"];
                borrowInfo.UseGuid = (string)i["UseGuid"];
                borrowInfo.BorrowPerson = (string)i["BorrowPerson"];
                borrowInfo.Handler = (string)i["Handler"];
                borrowInfo.BorrowCause = (string)i["BorrowCause"];
                borrowInfo.BorrowDate = (DateTime)i["BorrowDate"];
                borrowInfo.ReturnDate = (DateTime)i["ReturnDate"];
                borrowInfo.Remark = (string)i["Remark"];
            }
            bool r = borrowInfoBLL.SaveBorrowInfo(borrowInfo, status);
            if (r)
            {
                Response.Write("成功!");
            }
            else
            {
                Response.Write("失败！");
            }
        }
        //查询单个图书借阅信息
        public void GetBorrowInfo()
        {
            string useGuid = GetString("useGuid");
            BorrowInfo borrowInfo = borrowInfoBLL.GetBorrowInfo(useGuid);
            RenderJson(borrowInfo);
        }
        //根据useGuid删除图书借阅信息
        public void RemoveBorrowInfo()
        {
            string useGuid = GetString("useGuid");
            bool r = borrowInfoBLL.Delete(useGuid);
            if (r)
            {
                Response.Write("成功!");
            }
            else
            {
                Response.Write("失败！");
            }
        }
        //查询所有图书姓名
        public void SearchAllBookName()
        {
            string key = GetString("SelectBookType");
            DateTime beginDate = GetDateTime("BeginDate");
            DateTime endDate = GetDateTime("EndDate");
            //分页
            int pageIndex = GetInt("pageIndex");
            int pageSize = GetInt("pageSize");
            List<BookInfo> bookList = bookInfoBLL.GetList(pageIndex, pageSize, key, beginDate, endDate);
            RenderJson(bookList);
        }
        //不分页获取所有图书
        public void GetAllBookWithoutPaging()
        {
            List<BookInfo> bookList = bookInfoBLL.GetAllBookWithoutPaging();
            RenderJson(bookList);
        }

    }
}
