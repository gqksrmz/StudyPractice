using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReserveInfo
    {
        private string _reserveNo;
        private string _tableNo;
        private int _peopleNum;
        private DateTime _startTime;
        private DateTime _endTime;
        private int _reserveStatus;
        private string _notes;

        public ReserveInfo()
        {

        }
        public ReserveInfo(string reserveNo,string tableNo,int peopleNum,DateTime startTime,DateTime endTime,int reserveStatus,string notes)
        {
            this._reserveNo = reserveNo;
            this._tableNo = tableNo;
            this._peopleNum = peopleNum;
            this._startTime = startTime;
            this._endTime = endTime;
            this._reserveStatus = reserveStatus;
            this._notes = notes;
        }
        public string ReserveNo
        {
            get
            {
                return _reserveNo;
            }

            set
            {
                _reserveNo = value;
            }
        }

        public string TableNo
        {
            get
            {
                return _tableNo;
            }

            set
            {
                _tableNo = value;
            }
        }

        public int PeopleNum
        {
            get
            {
                return _peopleNum;
            }

            set
            {
                _peopleNum = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }

            set
            {
                _startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }

            set
            {
                _endTime = value;
            }
        }

        public int ReserveStatus
        {
            get
            {
                return _reserveStatus;
            }

            set
            {
                _reserveStatus = value;
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }

            set
            {
                _notes = value;
            }
        }
    }
}
