﻿using BLL;
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
            List<BookInfo> bookInfoList = bookInfoBLL.GetList();
            RenderJson(bookInfoList);
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
                bookInfo.BookName = (string)i["BookName"];
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
            string bookGuid = GetString("bookGuid");
            BookInfo book = bookInfoBLL.GetEntity(bookGuid);
            RenderJson(book);
        }
        //查询所有图书借阅信息
        public void SearchAllBorrowInfo()
        {
            List<BorrowInfo> borrowInfoList = borrowInfoBLL.GetList();
            RenderJson(borrowInfoList);
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
                borrowInfo.BorrowDate =(DateTime) i["BorrowDate"];
                borrowInfo.ReturnDate = (DateTime)i["ReturnDate"];
                borrowInfo.Remark =(string)i["Remark"];
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
    }
}
