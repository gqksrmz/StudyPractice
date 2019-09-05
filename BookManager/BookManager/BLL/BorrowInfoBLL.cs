using BookManager.DAL;
using Model;
using Plusoft.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookManager.BLL
{
    public class BorrowInfoBLL
    {
        BorrowInfoDal borrowInfoDal = new  BorrowInfoDal();
        //增
        public string Insert(Hashtable entity)
        {
            return borrowInfoDal.Inert(entity);
        }
        //改
        public bool Update(Hashtable entity)
        {
            return borrowInfoDal.Update(entity);
        }
        //删除
        public bool Delete(string id)
        {
            return borrowInfoDal.Delete(id);
        }
        //根据id获取单个实体
        public Hashtable GetEntity(string id)
        {
            Hashtable hs= borrowInfoDal.GetEntity(id);
            return hs;
        }
        //获取列表
        public ArrayList GetList()
        {
            ArrayList arrayList = borrowInfoDal.GetList();
            return arrayList;
        }
        public ArrayList SearchBorrowInfo(String key, int pageIndex, int pageSize, ArrayList sortFields = null)
        {
            return borrowInfoDal.Search(key, pageIndex, pageSize, sortFields);
        }
        public ArrayList SearchBorrowInfo(String key, int pageIndex, int pageSize, String sortField, String sortOrder)
        {
            return borrowInfoDal.Search(key, pageIndex, pageSize, sortField, sortOrder);
        }
        //查询图书结果
        public Hashtable SearchBorrowInfoResult(String key, int pageIndex, int pageSize, ArrayList sortFields)
        {
            ArrayList data = SearchBorrowInfo(key, pageIndex, pageSize, sortFields);
            int total = SearchBookTotal();
            Hashtable result = new Hashtable();
            result["data"] = data;
            result["total"] = total;
            return result;
        }
        public Hashtable SearchBookResult(String key, int pageIndex, int pageSize, String sortField, String sortOrder)
        {
            ArrayList data = SearchBorrowInfo(key, pageIndex, pageSize, sortField, sortOrder);
            int total = SearchBookTotal();
            Hashtable result = new Hashtable();
            result["data"] = data;
            result["total"] = total;
            return result;
        }
        //总共多少图书
        public int SearchBookTotal()
        {
            return borrowInfoDal.GetCount();
        }

        public bool SaveBook(ArrayList data)
        {
            using (var conn = DapperHelper.GetConnection())
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        Hashtable o = (Hashtable)data[i];
                        String bookname = o["bookname"] != null ? o["bookname"].ToString() : "";
                        //根据记录状态，进行不同的增加，删除，修改操作
                        String state = o["_state"] != null ? o["_state"].ToString() : "";
                        //新增id为空或者_state为added
                        if (state == "added" || bookname == "")
                        {
                            borrowInfoDal.Inert(o, trans);
                        }
                        //删除_state为removed或deleted
                        else if (state == "removed" || state == "deleted")
                        {
                            borrowInfoDal.Delete(bookname, trans);
                        }
                        //更新_state为空或modified
                        else if (state == "modified" || state == "")
                        {
                            borrowInfoDal.Update(o, trans);
                        }
                    }
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    return false;
                }
                return true;
            }
        }
    }
}