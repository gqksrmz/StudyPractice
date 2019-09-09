using BLL;
using Common;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RestaurantManage
{
    /// <summary>
    /// TableInfoService 的摘要说明
    /// </summary>
    public class TableInfoService : IHttpHandler
    {
        TableInfoBLL tableInfoBLL = new TableInfoBLL(); 
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String fn = context.Request["action"];
            MethodInfo method = this.GetType().GetMethod(fn);
            if (method != null)
            {
                method.Invoke(this, new object[] { context });
            }
        }
        public void SearchAllTable(HttpContext context)
        {
            int pageIndex = Convert.ToInt32 (context.Request["pageIndex"]);
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            List<TableInfo> tableInfoList = tableInfoBLL.GetList(pageIndex, pageSize);
            Hashtable result = new Hashtable
            {
                ["data"] = tableInfoList,
                ["total"] = tableInfoBLL.GetTableCount()
            };
            String json = JSON.Encode(result);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}