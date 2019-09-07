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
        public List<BorrowInfo> GetList(int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            List<BorrowInfo> borrowInfoList = borrowInfoDal.GetBorrowInfoList(pageIndex, pageSize,sortField,sortOrder);
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
            try
            {

                if (borrowInfo.UseGuid == null)
                {

                    List<string> strList = GetUseGuidList();
                    if (strList.Count <= 0)
                    {
                        borrowInfo.UseGuid = "JY0001";
                    }
                    else
                    {
                        borrowInfo.UseGuid = GenerateIdentification(GetUseGuidList());
                    }

                    bool r = borrowInfoDal.Inert(borrowInfo);
                    if (r)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (state == null)
                {
                    bool r = borrowInfoDal.Update(borrowInfo);
                    if (r)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    bool r = borrowInfoDal.Delete(borrowInfo.UseGuid);
                    if (r)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //查询借阅标识
        public List<string> GetUseGuidList()
        {
            return borrowInfoDal.GetUseGuidList();
        }
        //生成自动增长的标识
        public string GenerateIdentification(List<string> numberList)
        {
            List<int> number = new List<int>();
            foreach (var item in numberList)
            {
                number.Add(Convert.ToInt32(item));
            }
            number.Sort();
            string r1 = "JY";
            string r2 = (number.Last() + 1).ToString("D4");
            string result = r1 + r2;
            return result;
        }
        //根据key查询图书借阅信息
        public List<BorrowInfo> GetBorrowInfoByKey(string key, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            List<BorrowInfo> borrowInfoList = borrowInfoDal.GetBorrowInfoByKey(key, pageIndex, pageSize,sortField,sortOrder);
            return borrowInfoList;
        }

    }
}

