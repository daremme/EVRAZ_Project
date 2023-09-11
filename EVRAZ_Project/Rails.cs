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



        public override string ToString()
        {
            return "Балка " + _Stamp;
        }

        int k = 0;

        public Rails() { }

        public Rails(string stamp, string steel_grade, string profile, string maker, double length, double width, double height, int year)
        {
            _Stamp = stamp;
            _Maker = maker;
            _Length = length;
            _Width = width;
            _Height = height;

            if (steel_grade == "СТ0")
                _Steel_grade = 0;
            else if (steel_grade == "СТ1")
                _Steel_grade = 1;
            if (steel_grade == "СТ2")
                _Steel_grade = 2;
            else if (steel_grade == "СТ3")
                _Steel_grade = 3;
            if (steel_grade == "СТ4")
                _Steel_grade = 4;
            else if (steel_grade == "СТ5")
                _Steel_grade = 5;
            if (steel_grade == "СТ6")
                _Steel_grade = 6;
            else if (steel_grade == "СТ7")
                _Steel_grade = 7;

            if (profile == "Т58")
                _Profile = 0;
            if (profile == "Р65")
                _Profile = 1;

            _Year = year;
        }

        public string Stamp
        {
            get { return _Stamp; }
        }
        public string Steel_grade
        {
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
            get
            {
                if (_Profile == 0)
                    return "Т58";
                else
                    return "Р65";
            }
        }
        public int Profile_ID
        {
            get { return _Profile; }
        }
        public string Maker
        {
            get { return _Maker; }
        }

        public double Length
        {
            get { return _Length; }
        }
        public double Width
        {
            get { return _Width; }
        }
        public double Height
        {
            get { return _Height; }
        }
        public int Year
        {
            get { return _Year; }
        }
        public int Position
        {
            set { _Position = value; }
            get { return _Position; }
        }
    }
}
