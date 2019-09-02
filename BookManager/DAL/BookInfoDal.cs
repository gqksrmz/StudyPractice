using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public interface BookInfoDal
    {
        //添加图书
        bool AddBook(BookInfo bookInfo);

        //删除图书
        bool DelBook(string bookGuid);

        //修改图书信息 
        bool ModifyBookInfo(BookInfo bookInfo);

        //根据姓名查询图书
        BookInfo SelectOneBook(string bookName);
        //查询所有图书
        List<BookInfo> SelectAllBook();

    }
}
