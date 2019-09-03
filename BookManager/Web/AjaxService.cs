﻿using Bll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web
{
    public class AjaxService:BaseService
    {
        BookInfoBLL bookInfoBLL = new BookInfoBLL();
        public AjaxService(HttpRequest Request,HttpResponse Response) : base(Request, Response)
        {

        }
        public void SearchAllBook()
        {
            //查询条件
            string key = GetString("key");
            //分页
            int pageIndex = GetInt("pageIndex");
            int pageSize = GetInt("pageSize");
            //字段排序
            String sortField = GetString("sortFirld");
            String sortOrder = GetString("sortOrder");
            //业务层：数据库操作
            Hashtable result = bookInfoBLL.SearchBookResult(key, pageIndex, pageSize, sortField, sortOrder);
            RenderJson(result);
        }
        public void SaveBooks()
        {
            ArrayList data = GetArrayList("data");
            bookInfoBLL.SaveBook(data);
        }
        public void RemoveBook()
        {
            String id = GetString("id");
            bookInfoBLL.Delete(id);
        }
        public void GetBook()
        {
            String id = GetString("id");
            Hashtable book = bookInfoBLL.GetEntity(id);
            RenderJson(book);
        }
    }
}
