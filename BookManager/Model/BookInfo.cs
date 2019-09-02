using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BookInfo
    {
        private string _bookGuid;
        private string _bookName;
        private int _bookType;
        private int _suitAble;
        private DateTime _buyDate;
        private int _count;
        private string _remark;

        public BookInfo()
        {

        }
        public BookInfo(string bookGuid,string bookName,int bookType,int suitAble,DateTime buyDate,int count,string remark)
        {
            this._bookGuid = bookGuid;
            this._bookName = bookName;
            this._bookType = bookType;
            this._suitAble = suitAble;
            this._buyDate = buyDate;
            this._count = count;
            this._remark = remark;
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

        public int BookType
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

        public int SuitAble
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
