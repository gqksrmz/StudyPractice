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
        /// <summary>
        /// 反射
        /// </summary>
        /// <param name="context"></param>
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
        /// <summary>
        /// 查询所有餐桌
        /// </summary>
        /// <param name="context"></param>
        public void SearchAllTable(HttpContext context)
        {
            string searchHoldNum= context.Request["SearchHoldNum"];
            string searchIsUse= context.Request["SearchIsUse"];
            int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);//string searchHoldNum,string searchIsUse
            List<TableInfo> tableInfoList = tableInfoBLL.GetList(pageIndex, pageSize,searchHoldNum,searchIsUse);
            Hashtable result = new Hashtable
            {
                ["data"] = tableInfoList,
                ["total"] = tableInfoBLL.GetTableCount()
            };
            String json = JSON.Encode(result);
            context.Response.Write(json);
        }
        /// <summary>
        /// 保存餐桌信息
        /// </summary>
        /// <param name="context"></param>
        public void SaveTableInfo(HttpContext context)
        {
            ArrayList arrayList = (ArrayList)JSON.Decode(context.Request["data"]);
            TableInfo tableInfo = new TableInfo();
            string status = null;
            foreach (var item in arrayList)
            {
                Hashtable i = (Hashtable)item;
                tableInfo.TableNo = (string)i["TableNo"];
                if (Convert.ToInt32(i["HoldNum"]) == 1)
                {
                    tableInfo.HoldNum = 2;
                }else if(Convert.ToInt32(i["HoldNum"]) == 2)
                {
                    tableInfo.HoldNum = 4;
                }
                else if (Convert.ToInt32(i["HoldNum"]) == 3)
                {
                    tableInfo.HoldNum = 6;
                }
                tableInfo.IsUse = Convert.ToInt32(i["IsUse"]);
                tableInfo.Notes = (string)i["Notes"];
                status = (string)i["Status"];
            }
            bool r = tableInfoBLL.SaveTableInfo(tableInfo, status);
            if (r)
            {
                context.Response.Write("成功!");
            }
            else
            {
                context.Response.Write("失败！");
            }
        }
        /// <summary>
        /// 根据TableNo删除餐桌信息
        /// </summary>
        /// <param name="context"></param>
        public void RemoveTableInfo(HttpContext context)
        {
            string tableNo = context.Request["TableNo"];
            string[] tableNoList = tableNo.Split(',');
            for (int i = 0; i < tableNoList.Length; i++)
            {
                bool r = tableInfoBLL.Delete(tableNoList[i]);
                if (r)
                {
                    context.Response.Write("成功!");
                }
                else
                {
                    context.Response.Write("失败！");
                }
            }
           
        }
        /// <summary>
        /// 根据TableNo获取单个餐桌信息
        /// </summary>
        /// <param name="context"></param>
        public void GetTableInfo(HttpContext context)
        {
            string tableNo = context.Request["TableNo"];
            TableInfo tableInfo = new TableInfo();
            Hashtable hs = new Hashtable();
            hs["TableNo"] = tableInfo.TableNo;
            hs["HoldNum"] = tableInfo.HoldNum;
            hs["IsUse"] = tableInfo.IsUse;
            hs["Notes"] = tableInfo.Notes;
            String json = JSON.Encode(hs);
            context.Response.Write(json);
        }
        /// <summary>
        /// 获取所有餐桌编号
        /// </summary>
        /// <param name="context"></param>
        public void GetAllTableNo(HttpContext context)
        {
            List<TableInfo> tableNoList = tableInfoBLL.GetAllTableNo();
            Hashtable result = new Hashtable
            {
                ["data"] = tableNoList
            };
            String json = JSON.Encode(result);
            context.Response.Write(json);
        }
        /// <summary>
        /// 生成序号
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public string GenernateNo(int no)
        {
            List<string> tableNoList = tableInfoBLL.SearchAllTableNo();
            List<int> tableNo = new List<int>();
            foreach (var item in tableNoList)
            {
                tableNo.Add(Convert.ToInt32(item.Substring(1, 2)));
            }
            tableNo.Sort();
            int s = tableNo.Last() + 1;
            string r1 = s.ToString("D2");
            string r2 = null;
            if (no == 1)
            {
                r2 = "2";
            }
            else if (no == 2)
            {
                r2 = "4";
            }
            else if (no == 3)
            {
                r2 = "6";
            }
            string result = r2 + r1;
            return result;
        }
        public void ShowNo(HttpContext context)
        {
            int i = Convert.ToInt32(context.Request["data"]);
            string s = GenernateNo(i);
            String json = JSON.Encode(s);
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