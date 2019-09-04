using Plusoft.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookManager.DAL
{
    public class BorrowInfoDal
    {
        string selectSql = @"select * from BorrowInfo";
        //插入新数据
        public string Inert(Hashtable entity, IDbTransaction trans = null)
        {
            string bookname = (string)entity["bookname"];
            string sql = "insert into BorrowInfo(bookname,useguid,borrowperson,handler,borrowcause,borrowdate,returndate,remark)" +
                "values(@bookname,@useguid,@borrowperson,@handler,@borrowcause,@borrowdate,@returndate,@remark)";
            DapperHelper.Execute(sql, entity, trans);
            return bookname;
        }
        //更新操作
        public bool Update(Hashtable entity, IDbTransaction trans = null)
        {
            //先获取数据库旧对象，然后更新
            string id = Convert.ToString(entity["bookname"]);
            Hashtable old = GetEntity(id);
            if (old == null) return false;
            //将新的数据拷贝到旧对象上
            foreach (DictionaryEntry de in entity)
            {
                old[de.Key] = de.Value;
            }
            entity = old;
            string sql = @"update BorrowInfo set bookname=@bookname,useguid=@useguid,borrowperson=@borrowperson,
            handler=@handler,borrowcause=@borrowcause,borrowdate=@borrowdate,returndate=@returndate,remark=@remark";
            int result = DapperHelper.Execute(sql, entity, trans);
            return result > 0;
        }
        //删除操作
        public bool Delete(string bookname, IDbTransaction trans = null)
        {
            string sql = @"delete from BookInfo where bookname=@bookname";
            int result = DapperHelper.Execute(sql, new { bookname = bookname }, trans);
            return result > 0;
        }
        //根据id获取数据库实体对象
        public Hashtable GetEntity(string bookname)
        {
            string sql = selectSql + "wehere bookname=@bookname";
            return DapperHelper.QuerySingle(sql, new { bookname = bookname });
        }
        //获取数据库图书借阅信息列表
        public ArrayList GetList()
        {
            string sql = selectSql;
            return DapperHelper.Query(sql);
        }
        //根据key查询
        public ArrayList Search(String key, int pageIndex, int pageSize, String sortField, String sortOrder)
        {
            ArrayList sortFirlds = new ArrayList();
            if (String.IsNullOrEmpty(sortField) == false)
            {
                Hashtable p = new Hashtable();
                p["field"] = sortField;
                p["dir"] = sortOrder;
                sortFirlds.Add(p);
            }
            return Search(key, pageIndex, pageSize, sortFirlds);
        }

        public ArrayList Search(string key, int pageIndex, int pageSize, ArrayList sortFirlds)
        {
            if (key == null) key = "";
            string sql = selectSql + "\nwhere bookname like '%" + key + "%'";
            return DapperHelper.QueryPage(sql, null, pageIndex, pageSize);
        }
        //获取总共多少条数据
        public virtual int GetCount()
        {
            string sql = @"select count(*) from BorrowInfo";

            return DapperHelper.ExecuteScalar<int>(sql);
        }

    }
}