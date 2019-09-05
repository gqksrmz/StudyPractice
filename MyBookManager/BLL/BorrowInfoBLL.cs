using Common;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BorrowInfoBLL
    {
        BorrowInfoDal borrowInfoDal = new BorrowInfoDal();
        //增添
        public bool Insert(BorrowInfo entity)
        {
            return borrowInfoDal.Inert(entity);
        }
        //更改
        public bool Update(BorrowInfo entity)
        {
            return borrowInfoDal.Update(entity);
        }
        //删除
        public bool Delete(string useGuid)
        {
            return borrowInfoDal.Delete(useGuid);
        }
        //根据useGuid获取单个实体
        public BorrowInfo GetBorrowInfo(string useGuid)
        {
            return borrowInfoDal.GetBorrowInfo(useGuid);
        }
        //获取图书借阅列表
        public List<BorrowInfo> GetList()
        {
            List<BorrowInfo> borrowInfoList = borrowInfoDal.GetBorrowInfoList();
            return borrowInfoList;
        }
        //总共多少借阅信息
        public int GetBorrowInfoCount()
        {
            return borrowInfoDal.GetCount();
        }
        //事务
        public bool SaveBorrowInfo(Object obj, string state)
        {
            BorrowInfo borrowInfo = (BorrowInfo)obj;
            using (var conn = SqlHelper.GetSqlConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    if (borrowInfo.UseGuid ==null)
                    {
                        borrowInfo.UseGuid = Guid.NewGuid().ToString();
                        borrowInfoDal.Inert(borrowInfo);
                    }
                    else if (state == null)
                    {
                        borrowInfoDal.Update(borrowInfo);

                    }
                    else
                    {
                        borrowInfoDal.Delete(borrowInfo.UseGuid);
                    }
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    return false;
                }
                return true;
            }

        }
    }
}
