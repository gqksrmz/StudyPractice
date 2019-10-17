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
            Hashtable[] hs = new Hashtable[tableInfoList.Count];
            for (int i = 0; i < tableInfoList.Count; i++)
            {
                Hashtable temp = new Hashtable();
                temp["ReserveNo"] = tableInfoList[i].ReserveNo;
                temp["TableNo"] = tableInfoList[i].TableNo;
                temp["PeopleNum"] = tableInfoList[i].PeopleNum;
                temp["StartTime"] = tableInfoList[i].StartTime;
                temp["EndTime"] = tableInfoList[i].EndTime;
                temp["ReserveStatus"] = tableInfoList[i].ReserveStatus;
                temp["Notes"] = tableInfoList[i].Notes;
                hs[i] = temp;
            }
            Hashtable result = new Hashtable
            {
                ["data"] = hs,
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
            var data = JSON.Decode(context.Request["data"]);
            if (data is Hashtable)
            {
                Hashtable hs = (Hashtable)JSON.Decode(context.Request["data"]);
                ReserveInfo reserveInfo = new ReserveInfo();
                string status = null;
                reserveInfo.ReserveNo = (string)hs["ReserveNo"];
                reserveInfo.TableNo = (string)hs["TableNo"];
                reserveInfo.PeopleNum = Convert.ToInt32(hs["PeopleNum"]);
                reserveInfo.StartTime = Convert.ToDateTime(hs["StartTime"]);
                reserveInfo.EndTime = Convert.ToDateTime(hs["EndTime"]);
                reserveInfo.ReserveStatus = Convert.ToInt32(hs["ReserveStatus"]);
                reserveInfo.Notes = (string)hs["Notes"];
                status = (string)hs["Status"];
                bool r = reserveInfoBLL.SaveReserveInfo(reserveInfo, status);
                if (r)
                {
                    String json = JSON.Encode("成功！");
                    context.Response.Write(json);
                }
                else
                {
                    String json = JSON.Encode("失败！");
                    context.Response.Write(json);
                }
            }
            else if (data is ArrayList)
            {
                ArrayList i = (ArrayList)JSON.Decode(context.Request["data"]);
                ReserveInfo reserveInfo = new ReserveInfo();
                string status = null;
                foreach (var item in i)
                {
                    Hashtable hs = (Hashtable)item;
                    reserveInfo.ReserveNo = (string)hs["ReserveNo"];
                    reserveInfo.TableNo = (string)hs["TableNo"];
                    reserveInfo.PeopleNum = Convert.ToInt32(hs["PeopleNum"]);
                    reserveInfo.StartTime = Convert.ToDateTime(hs["StartTime"]);
                    reserveInfo.EndTime = Convert.ToDateTime(hs["EndTime"]);
                    reserveInfo.ReserveStatus = Convert.ToInt32(hs["ReserveStatus"]);
                    reserveInfo.Notes = (string)hs["Notes"];
                    status = (string)hs["Status"];
                }
                bool r = reserveInfoBLL.SaveReserveInfo(reserveInfo, status);
                if (r)
                {
                    String json = JSON.Encode("成功！");
                    context.Response.Write(json);
                }
                else
                {
                    String json = JSON.Encode("失败！");
                    context.Response.Write(json);
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