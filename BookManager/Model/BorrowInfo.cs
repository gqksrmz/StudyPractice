using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BorrowInfo
    {
        private string _bookName;
        private string _useGuid;
        private string _borrowPerson;
        private string _handler;
        private string _borrowCause;
        private DateTime _borrowDate;
        private DateTime _returnTime;
        private string _remark;

        public BorrowInfo()
        {

        }
        public BorrowInfo(string bookName,string userGuid,string borrowPerson,string handler,string borrowCause,DateTime borrowDate,DateTime returnTime,string remark)
        {
            this._bookName = bookName;
            this._useGuid = userGuid;
            this._borrowPerson = borrowPerson;
            this._handler = handler;
            this._borrowCause = borrowCause;
            this._borrowDate = borrowDate;
            this._returnTime = returnTime;
            this._remark = remark;

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

        public string UseGuid
        {
            get
            {
                return _useGuid;
            }

            set
            {
                _useGuid = value;
            }
        }

        public string BorrowPerson
        {
            get
            {
                return _borrowPerson;
            }

            set
            {
                _borrowPerson = value;
            }
        }

        public string Handler
        {
            get
            {
                return _handler;
            }

            set
            {
                _handler = value;
            }
        }

        public string BorrowCause
        {
            get
            {
                return _borrowCause;
            }

            set
            {
                _borrowCause = value;
            }
        }

        public DateTime BorrowDate
        {
            get
            {
                return _borrowDate;
            }

            set
            {
                _borrowDate = value;
            }
        }

        public DateTime ReturnTime
        {
            get
            {
                return _returnTime;
            }

            set
            {
                _returnTime = value;
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
