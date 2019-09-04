using DAL;
using Plusoft.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class BookInfoBLL
    {
        BookInfoDal bookInfoDal = new BookInfoDal();
        //增
        public string Insert(Hashtable entity)
        {
            return bookInfoDal.Inert(entity);
        }
        //改
        public bool Update(Hashtable entity)
        {
            return bookInfoDal.Update(entity);
        }
        //删除
        public bool Delete(string id)
        {
            return bookInfoDal.Delete(id);
        }
        //根据id获取单个实体
        public Hashtable GetEntity(string id)
        {
            return bookInfoDal.GetEntity(id);
        }
        //获取列表
        public ArrayList GetList()
        {
            return bookInfoDal.GetList();
        }
        public ArrayList SearchBook(String key,int pageIndex,int pageSize,ArrayList sortFields=null)
        {
            return bookInfoDal.Search(key, pageIndex, pageSize, sortFields);
        }
        public ArrayList SearchBook(String key, int pageIndex, int pageSize,String sortField,String sortOrder)
        {
            return bookInfoDal.Search(key, pageIndex, pageSize, sortField,sortOrder);
        }
        //查询图书结果
        public Hashtable SearchBookResult(String key,int pageIndex,int pageSize, ArrayList sortFields)
        {
            ArrayList data = SearchBook(key, pageIndex, pageSize, sortFields);
            int total = SearchBookTotal();
            Hashtable result = new Hashtable();
            result["data"] = data;
            result["total"] = total;
            return result;
        }
        public Hashtable SearchBookResult(String key, int pageIndex, int pageSize, String sortField, String sortOrder)
        {
            ArrayList data = SearchBook(key, pageIndex, pageSize, sortField,sortOrder);
            int total = SearchBookTotal();
            Hashtable result = new Hashtable();
            result["data"] = data;
            result["total"] = total;
            return result;
        }
        //总共多少图书
        public int SearchBookTotal()
        {
            return bookInfoDal.GetCount();
        }

        public bool SaveBook(ArrayList data)
        {
            using (var conn=DapperHelper.GetConnection())
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        Hashtable o = (Hashtable)data[i];
                        String bookguid = o["bookguid"] != null ? o["bookguid"].ToString() : "";
                        //根据记录状态，进行不同的增加，删除，修改操作
                        String state = o["_state"] != null ? o["_state"].ToString() : "";
                        //新增id为空或者_state为added
                        if (state=="added"|| bookguid == "")
                        {
                            bookInfoDal.Inert(o, trans);
                        }
                        //删除_state为removed或deleted
                        else if (state=="removed"||state=="deleted")
                        {
                            bookInfoDal.Delete(bookguid, trans);
                        }
                        //更新_state为空或modified
                        else if (state=="modified"||state==""){
                            bookInfoDal.Update(o, trans);
                        }
                    }
                    trans.Commit();
                }
                catch(Exception e)
                {
                    trans.Rollback();
                    return false;
                }
                return true;
            }
        }
    }
}
