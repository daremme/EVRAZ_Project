using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRAZ_Project
{
    class Rails
    {
        private string _Stamp, _Maker;

        private double _Length, _Width, _Height;

        private int _Steel_grade, _Profile, _Year, _Position;

        public string Stamp
        {
            set { _Stamp = value; }
            get { return _Stamp; }
        }
        public string Steel_grade
        {
            set
            {
                if (Steel_grade == "СТ0")
                    _Steel_grade = 0;
                else if (Steel_grade == "СТ1")
                    _Steel_grade = 1;
                if (Steel_grade == "СТ2")
                    _Steel_grade = 2;
                else if (Steel_grade == "СТ3")
                    _Steel_grade = 3;
                if (Steel_grade == "СТ4")
                    _Steel_grade = 4;
                else if (Steel_grade == "СТ5")
                    _Steel_grade = 5;
                if (Steel_grade == "СТ6")
                    _Steel_grade = 6;
                else if (Steel_grade == "СТ7")
                    _Steel_grade = 7;
            }
            get
            {
                if (_Steel_grade == 0)
                    return "СТ0";
                else if (_Steel_grade == 1)
                    return "СТ1";
                else if (_Steel_grade == 2)
                    return "СТ2";
                else if (_Steel_grade == 3)
                    return "СТ3";
                else if (_Steel_grade == 4)
                    return "СТ4";
                else if (_Steel_grade == 5)
                    return "СТ5";
                else if (_Steel_grade == 6)
                    return "СТ6";
                else
                    return "СТ7";
            }
        }
        public int Steel_grade_ID
        {
            get { return _Steel_grade; }
        }        
        public string Profile
        {
            set
            {
                if (Profile == "T58")
                    _Profile = 0;
                else if (Profile == "P65")
                    _Profile = 1;
            }
            get
            {
                if (_Profile == 0)
                    return "T58";
                else
                    return "P65";
            }
        }
        public int Profile_ID
        {
            get { return _Profile; }
        }
        public string Maker
        {
            set { _Maker = value; }
            get { return _Maker; }
        }

        public double Length
        {
            set { _Length = value; }
            get { return _Length; }
        }
        public double Width
        {
            set { _Width = value; }
            get { return _Width; }
        }
        public double Height
        {
            set { _Height = value; }
            get { return _Height; }
        }
        public int Year
        {
            set { _Year = value; }
            get { return _Year; }
        }
        public int Position
        {
            set { _Position = value; }
            get { return _Position; }
        }

    }
}
