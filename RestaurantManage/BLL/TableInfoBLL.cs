using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TableInfoBLL
    {
        TableInfoDal tableInfoDal = new TableInfoDal();
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="entity">要插入的数据数据对象</param>
        /// <returns></returns>
        public bool Insert(TableInfo entity)
        {
            return tableInfoDal.Insert(entity);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">要更新的数据对象</param>
        /// <returns></returns>
        public bool Update(TableInfo entity)
        {
            return tableInfoDal.Update(entity);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableNo">要删除的对象的编号</param>
        /// <returns></returns>
        public bool Delete(string tableNo)
        {
            return tableInfoDal.Delete(tableNo);
        }
        /// <summary>
        /// 根据tableNo获取单个实体对象
        /// </summary>
        /// <param name="tableNo"></param>
        /// <returns></returns>
        public TableInfo GetEntity(string tableNo)
        {
            return tableInfoDal.GetEntity(tableNo);
        }
        /// <summary>
        /// 分页获取餐桌信息列表
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页几条数据</param>
        /// <returns></returns>
        public List<TableInfo> GetList(int pageIndex,int pageSize)
        {
            return tableInfoDal.GetTableList(pageIndex, pageSize);
        }
        /// <summary>
        /// 获取餐桌信息表总共多少条数据
        /// </summary>
        /// <returns></returns>
        public int GetTableCount()
        {
            return tableInfoDal.GetTableCount();
        }
        public bool SaveTableInfo(Object obj,string status)
        {
            TableInfo tableInfo = (TableInfo)obj;
            try
            {
                if (status == "added")
                {
                    tableInfoDal.Insert(tableInfo);
                }
                else if (status == "edit")
                {
                    tableInfoDal.Update(tableInfo);
                }
                else
                {
                    tableInfoDal.Delete(tableInfo.TableNo);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 查询所有餐桌 获取里面的编号信息
        /// </summary>
        /// <returns></returns>
        public List<TableInfo> GetAllTableNo()
        {
            return tableInfoDal.GetAllTableNo();
        }
        /// <summary>
        /// 查询所有的餐桌编号
        /// </summary>
        /// <returns></returns>
        public List<string> SearchAllTableNo()
        {
            return tableInfoDal.SearchAllTableNo();
        }

    }
}
