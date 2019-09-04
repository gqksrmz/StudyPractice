using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BookInfo
    {
        private string _bookGuid;
        private string _bookName;
        private string _bookType;
        private string _suitAble;
        private DateTime _buyDate;
        private int _count;
        private string _remark;

        public BookInfo()
        {

        }
        public BookInfo(string bookGuid, string bookName, string bookType, string suitAble, DateTime buyDate, int count, string remark)
        {
            this.BookGuid = bookGuid;
            this.BookName = bookName;
            this.BookType = bookType;
            this.SuitAble = suitAble;
            this.BuyDate = buyDate;
            this.Count = count;
            this.Remark = remark;
        }

        public string BookGuid
        {
            get
            {
                return _bookGuid;
            }

            set
            {
                _bookGuid = value;
            }
        }

        public string BookName
        {
            get
            {
                return _bookName;
            }

            set
            {
                _bookName = value;
            }
        }

        public string BookType
        {
            get
            {
                return _bookType;
            }

            set
            {
                _bookType = value;
            }
        }

        public string SuitAble
        {
            get
            {
                return _suitAble;
            }

            set
            {
                _suitAble = value;
            }
        }

        public DateTime BuyDate
        {
            get
            {
                return _buyDate;
            }

            set
            {
                _buyDate = value;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }

            set
            {
                _count = value;
            }
        }

        public string Remark
        {
            get
            {
                return _remark;
            }

            set
            {
                _remark = value;
            }
        }
    }
}
