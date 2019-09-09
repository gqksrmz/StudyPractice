using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TableInfo
    {
        private string _tableNo;
        private int _holdNum;
        private int _isUse;
        private string _notes;
        public TableInfo()
        {

        }
        public TableInfo(string tableNo,int holdNum,int isUse,string notes)
        {
            this._tableNo = tableNo;
            this._holdNum = holdNum;
            this._isUse = isUse;
            this._notes = notes;
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

        public int HoldNum
        {
            get
            {
                return _holdNum;
            }

            set
            {
                _holdNum = value;
            }
        }

        public int IsUse
        {
            get
            {
                return _isUse;
            }

            set
            {
                _isUse = value;
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
