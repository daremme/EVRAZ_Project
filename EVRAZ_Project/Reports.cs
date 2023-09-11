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
        private Rails _Rails;

        // Поработать с массивом дефектов, создать свойство
        private Defect[] _Defects;

        public override string ToString()
        {
            return "Создайте ведомость о поставке: '" + Rail.ToString() + "'";
        }

        public Reports() { }

        public Reports(string name, string data, string time, Rails rails)
        {
            _Name = name;
            _Date = data;
            _Time = time;
            _Rails = rails;
        }

        public Reports(string name, string data, string time, Rails rails, Defect[] defect)
        {
            _Name = name;
            _Date = data;
            _Time = time;
            _Rails = rails;
            _Defects = defect;
        }

        public Defect[] defect
        {
            get { return _Defects; }
        }

        public Rails Rail
        {
            get { return _Rails; }
        }
        public string Name
        {
            get { return _Name; }
        }
        public string Date
        {
            get { return _Date; }
        }
        public string Time
        {
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
