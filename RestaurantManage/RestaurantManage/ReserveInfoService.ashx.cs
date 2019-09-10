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
    /// ReserveInfoService 的摘要说明
    /// </summary>
    public class ReserveInfoService : IHttpHandler
    {
        ReserveInfoBLL reserveInfoBLL = new ReserveInfoBLL();
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
        /// 查询所有预约信息
        /// </summary>
        /// <param name="context"></param>
        public void SearchAllReserve(HttpContext context)
        {
            int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            List<ReserveInfo> tableInfoList = reserveInfoBLL.GetList(pageIndex, pageSize);
            Hashtable result = new Hashtable
            {
                ["data"] = tableInfoList,
                ["total"] = reserveInfoBLL.GetTableCount()
            };
            String json = JSON.Encode(result);
            context.Response.Write(json);
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="context"></param>
        public void SaveReserveInfo(HttpContext context)
        {
            ArrayList arrayList = (ArrayList)JSON.Decode(context.Request["data"]);
            ReserveInfo reserveInfo = new ReserveInfo();
            string status = null;
            foreach (var item in arrayList)
            {
                Hashtable i = (Hashtable)item;
                reserveInfo.ReserveNo = (string)i["ReserveNo"];
                reserveInfo.TableNo = (string)i["TableNo"];
                reserveInfo.PeopleNum = Convert.ToInt32(i["PeopleNum"]);
                reserveInfo.StartTime = Convert.ToDateTime(i["StartTime"]);
                reserveInfo.EndTime = Convert.ToDateTime(i["EndTime"]);
                reserveInfo.ReserveStatus = Convert.ToInt32(i["ReserveStatus"]);
                reserveInfo.Notes = (string)i["Notes"];
                status = (string)i["Status"];
            }
            bool r = reserveInfoBLL.SaveReserveInfo(reserveInfo, status);
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
        /// 根据ReserveNo获取单个预约信息
        /// </summary>
        /// <param name="context"></param>
        public void GetReserveInfo(HttpContext context)
        {
            string reserveNo = context.Request["ReserveNo"];
            ReserveInfo reserveInfo = reserveInfoBLL.GetEntity(reserveNo);
            Hashtable hs = new Hashtable();
            hs["ReserveNo"] = reserveInfo.ReserveNo;
            hs["TableNo"]=reserveInfo.TableNo;
            hs["PeopleNum"]=reserveInfo.PeopleNum ;
            hs["StartTime"]=reserveInfo.StartTime;
            hs["EndTime"]=reserveInfo.EndTime;
            hs["ReserveStatus"]=reserveInfo.ReserveStatus;
            hs["Notes"]=reserveInfo.Notes;
            String json = JSON.Encode(hs);
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