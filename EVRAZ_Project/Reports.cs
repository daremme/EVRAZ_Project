using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRAZ_Project
{
    class Reports
    {
        private string _Name, _Date, _Time;

        private int _Position, _Type;

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        public string Date
        {
            set { _Date = value; }
            get { return _Date; }
        }
        public string Time
        {
            set { _Time = value; }
            get { return _Time; }
        }
        public int Position
        {
            set { _Position = value; }
            get { return _Position; }
        }
        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }

    }
}
