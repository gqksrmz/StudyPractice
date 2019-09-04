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
        private DateTime _returnDate;
        private string _remark;

        public BorrowInfo()
        {

        }
        public BorrowInfo(string bookName, string userGuid, string borrowPerson, string handler, string borrowCause, DateTime borrowDate, DateTime returnDate, string remark)
        {
            this.BookName = bookName;
            this.UseGuid = userGuid;
            this.BorrowPerson = borrowPerson;
            this.Handler = handler;
            this.BorrowCause = borrowCause;
            this.BorrowDate = borrowDate;
            this.ReturnDate = returnDate;
            this.Remark = remark;

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

        public DateTime ReturnDate
        {
            get
            {
                return _returnDate;
            }

            set
            {
                _returnDate = value;
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
