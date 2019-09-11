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
            ArrayList arrayList = new ArrayList(10);
            for (int i = 0; i < tableInfoList.Count; i++)
            {
                Hashtable hs = new Hashtable();
                hs["ReserveNo"] = tableInfoList[i].ReserveNo;
                hs["TableNo"] = tableInfoList[i].TableNo;
                hs["PeopleNum"] = tableInfoList[i].PeopleNum;
                hs["StartTime"] = tableInfoList[i].StartTime;
                hs["EndTime"] = tableInfoList[i].EndTime;
                hs["ReserveStatus"] = tableInfoList[i].ReserveStatus;
                hs["Notes"] = tableInfoList[i].Notes;
                DateTime startTime = tableInfoList[i].StartTime;
                DateTime endTime = tableInfoList[i].EndTime;
                int minutes = (60 - Convert.ToInt32(startTime.Minute.ToString())) + Convert.ToInt32(endTime.Minute.ToString());
                if (minutes > 15 && tableInfoList[i].ReserveStatus == 0)
                {
                    hs["Hide"] = true;
                }
                else
                {
                    hs["Hide"] = false;
                }
                arrayList.Add(hs);
            }
            Hashtable result = new Hashtable
            {
                ["data"] = arrayList,
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
            ReserveInfo r1 = new ReserveInfo();
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
                r1 = reserveInfoBLL.GetEntityByTableNo((string)i["TableNo"]);
            }
            if (status == "edit")
            {
                bool r = reserveInfoBLL.SaveReserveInfo(reserveInfo, status);
                if (r)
                {
                    context.Response.Write("成功！");
                }
                else
                {
                    context.Response.Write("失败！");
                }
            }
            else
            {
                if (reserveInfo.StartTime >= r1.StartTime && reserveInfo.EndTime <= r1.EndTime ||
                reserveInfo.EndTime <= r1.EndTime && reserveInfo.EndTime >= r1.StartTime)
                {
                    context.Response.Write("失败！");
                }
                else
                {
                    bool r = reserveInfoBLL.SaveReserveInfo(reserveInfo, status);
                    if (r)
                    {
                        context.Response.Write("成功！");
                    }
                    else
                    {
                        context.Response.Write("失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 根据ReserveNo获取单个预约信息
        /// </summary>
        /// <param name="context"></param>
        public void GetEntityByReserveNo(HttpContext context)
        {
            string reserveNo = context.Request["ReserveNo"];
            ReserveInfo reserveInfo = reserveInfoBLL.GetEntityByReserveNo(reserveNo);
            Hashtable hs = new Hashtable();
            hs["ReserveNo"] = reserveInfo.ReserveNo;
            hs["TableNo"] = reserveInfo.TableNo;
            hs["PeopleNum"] = reserveInfo.PeopleNum;
            hs["StartTime"] = reserveInfo.StartTime;
            hs["EndTime"] = reserveInfo.EndTime;
            hs["ReserveStatus"] = reserveInfo.ReserveStatus;
            hs["Notes"] = reserveInfo.Notes;
            String json = JSON.Encode(hs);
            context.Response.Write(json);
        }
        /// <summary>
        /// 根据ReserveNo删除预约信息
        /// </summary>
        /// <param name="context"></param>
        public void RemoveReserveInfo(HttpContext context)
        {
            string reserveNo = context.Request["ReserveNo"];
            string[] reserveNoList = reserveNo.Split(',');
            for (int i = 0; i < reserveNoList.Length; i++)
            {
                bool r = reserveInfoBLL.Delete(reserveNoList[i]);
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
        /// 自动生成用餐编号
        /// </summary>
        /// <returns></returns>
        public string GenernateNo()
        {
            string number = Guid.NewGuid().ToString();
            return number;
        }
        /// <summary>
        /// 显示自动生成的编号
        /// </summary>
        /// <param name="context"></param>
        public void ShowNo(HttpContext context)
        {

            string s = GenernateNo();
            String json = JSON.Encode(s);
            context.Response.Write(json);
        }
        /// <summary>
        /// 根据人数查询没有使用的桌子列表
        /// </summary>
        /// <param name="context"></param>
        public void ShowTable(HttpContext context)
        {
            string peopleNum = context.Request["data"];
            List<string> tableNoList = reserveInfoBLL.SearchTable(peopleNum);

            String json = JSON.Encode(tableNoList[0]);
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