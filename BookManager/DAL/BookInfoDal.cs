using Plusoft.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookInfoDal
    {
        string selectSql = @"select * from BookInfo";
        //插入新数据
        public string Inert(Hashtable entity, IDbTransaction trans = null)
        {
            string bookguid = Guid.NewGuid().ToString();
            entity["bookguid"] = bookguid;
            string sql = "insert into BookInfo(bookguid,bookname,booktype,suitable,buydate,count,remark)" +
                "values(@bookguid,@bookname,@booktype,@suitable,@buydate,@count,@remark)";
            DapperHelper.Execute(sql, entity, trans);
            return bookguid;
        }
        //更新操作
        public bool Update(Hashtable entity, IDbTransaction trans = null)
        {
            //先获取数据库旧对象，然后更新
            string id = Convert.ToString(entity["id"]);
            Hashtable old = GetEntity(id);
            if (old == null) return false;
            //将新的数据拷贝到旧对象上
            foreach (DictionaryEntry de in entity)
            {
                old[de.Key] = de.Value;
            }
            entity = old;
            string sql = @"update BookInfo set bookguid=@bookguid,bookname=@bookname,booktype=@booktype,suitable=@suitable,buydate=@buydate,count=@count,remark=@remark";
            int result = DapperHelper.Execute(sql, entity, trans);
            return result > 0;
        }
        //删除操作
        public bool Delete(string id,IDbTransaction trans = null)
        {
            string sql = @"delete from BookInfo where bookguid=@bookguid";
            int result = DapperHelper.Execute(sql, new { bookguid = id }, trans);
            return result > 0;
        }
        //根据id获取数据库实体对象
        public Hashtable GetEntity(string id)
        {
            string sql = selectSql + "wehere bookguid=@bookguid";
            return DapperHelper.QuerySingle(sql, new { bookguid = id });
        }
        //获取数据库图书列表
        public ArrayList GetList()
        {
            string sql = selectSql;
            return DapperHelper.Query(sql);
        }
        //根据key查询
        public ArrayList Search(String key,int pageIndex,int pageSize, String sortField,String sortOrder)
        {
            ArrayList sortFirlds = new ArrayList();
            if (String.IsNullOrEmpty(sortField) == false)
            {
                Hashtable p = new Hashtable();
                p["field"] = sortField;
                p["dir"] = sortOrder;
                sortFirlds.Add(p);
            }
            return ;
        }

        public ArrayList Search(string key,int pageIndex,int pageSize,ArrayList sortFirlds)
        {
            if (key == null) key = "";
            string sql = selectSql + "\nwhere bookname like '%" + key + "%'";
            return DapperHelper.QueryPage(sql, null, pageIndex, pageSize);
        }
        //获取总共多少条数据
        public virtual int GetCount()
        {
            string sql = @"select count(*) from BookInfo";
            
            return DapperHelper.ExecuteScalar<int>(sql);
        }
        
    }
}
