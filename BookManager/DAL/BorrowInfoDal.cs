using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface BorrowInfoDal
    {
        //查询所有借阅信息
         List<BorrowInfo> SearchAllBorrowInfo();
        //新增借阅信息
        bool AddNewBorrow(BorrowInfo borrowInfo);
        //删除借阅信息
        bool DelBorrow(string bookName);
        //根据书名查询借阅信息
        BorrowInfo SearchOneBorrow(string bookName);
    }
}
