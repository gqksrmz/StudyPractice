using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReserveInfoBLL
    {
        ReserveInfoDal reserveInfoDal = new ReserveInfoDal();
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="entity">要插入的数据数据对象</param>
        /// <returns></returns>
        public bool Insert(ReserveInfo entity)
        {
            return reserveInfoDal.Insert(entity);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">要更新的数据对象</param>
        /// <returns></returns>
        public bool Update(ReserveInfo entity)
        {
            return reserveInfoDal.Update(entity);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableNo">要删除的对象的编号</param>
        /// <returns></returns>
        public bool Delete(string reserveNo)
        {
            return reserveInfoDal.Delete(reserveNo);
        }
        /// <summary>
        /// 根据tableNo获取单个实体对象
        /// </summary>
        /// <param name="tableNo"></param>
        /// <returns></returns>
        public ReserveInfo GetEntity(string reserveNo)
        {
            return reserveInfoDal.GetEntity(reserveNo);
        }
        /// <summary>
        /// 分页获取餐桌信息列表
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页几条数据</param>
        /// <returns></returns>
        public List<ReserveInfo> GetList(int pageIndex, int pageSize)
        {
            return reserveInfoDal.GetReserveList(pageIndex, pageSize);
        }
        /// <summary>
        /// 获取餐桌信息表总共多少条数据
        /// </summary>
        /// <returns></returns>
        public int GetTableCount()
        {
            return reserveInfoDal.GetReserveCount();
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        public bool SaveReserveInfo(Object obj, string status)
        {
            ReserveInfo reserveInfo = (ReserveInfo)obj;
            try
            {
                if (status == "added")
                {
                    reserveInfoDal.Insert(reserveInfo);
                }
                else if (status == "edit")
                {
                    reserveInfoDal.Update(reserveInfo);
                }
                else
                {
                    reserveInfoDal.Delete(reserveInfo.ReserveNo);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 根据人数查询没有使用的桌子编号
        /// </summary>
        /// <param name="peopleNum">人数</param>
        /// <returns></returns>
        public List<string> SearchTable(string peopleNum)
        {
            return reserveInfoDal.SearchTable(peopleNum);
        }
    }
}
