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

        private int _Steel_grade, _Profile, _Year, _Position, _PrewiosPos;



        public override string ToString()
        {
            return "Балка " + _Stamp;
        }

        int k = 0;
        public string ReportString
        {
            get
            {
                //Поставка
                if (Position == 0) { return "Создайте ведомость о поставке: '" + ToString() + "'"; }
                //Хранение на склад
                else if (Position == 1) { return "Создайте ведомость о перемещениии на склад: '" + ToString() + "'"; }
                //Передача со склада в печь 
                else if (Position == 2 && PrewiosPos == 1 && k == 0) { k = 1; return "Создайте ведомость о перемещениии: '" + ToString() + "' в печь со склада"; }
                else if (Position == 2 && PrewiosPos == 1 && k == 1) { k = 0; return "Создайте ведомость о поставке: '" + ToString() + "' в печь со склада"; }
                //Передача с зоны поставки в печь 
                else if (Position == 2 && PrewiosPos == 0 && k == 0) { k = 1; return "Создайте ведомость о перемещениии: '" + ToString() + "' в печь с зоны поставки"; }
                else if (Position == 2 && PrewiosPos == 0 && k == 1) { k = 0; return "Создайте ведомость о поставке: '" + ToString() + "' в печь с зоны поставки"; }
                //С печи на стан
                else if (Position == 3 && k == 0) { k = 1; return "Создайте ведомость о перемещениии: '" + ToString() + "' с печи на прокатный стан"; }
                else if (Position == 3 && k == 1) { k = 0; return "Создайте ведомость о поставке: '" + ToString() + "' с печи на прокатный стан"; }
                //Со стана в холодильник
                else if (Position == 4 && k == 0) { k = 1; return "Создайте ведомость о перемещениии: '" + ToString() + "' со стана в холодильник"; }
                else if (Position == 4 && k == 1) { k = 0; return "Создайте ведомость о поставке: '" + ToString() + "' со стана в холодильник"; }
                //С холодильника в хранилище
                else if (Position == 5 && k == 0) { k = 1; return "Создайте ведомость о перемещениии в хранилище: '" + ToString() + "'"; }
                //С хранилища на линию контроля
                else if (Position == 6 && PrewiosPos == 2 && k == 0) { k = 1; return "Создайте ведомость о перемещениии: '" + ToString() + "' с хранилища на линию контроля"; }
                else if (Position == 6 && PrewiosPos == 2 && k == 1) { k = 0; return "Создайте ведомость о поставке: '" + ToString() + "' с хранилища на линию контроля"; }
                //С холодильника на линию контроля
                else if (Position == 6 && (PrewiosPos == 1 || PrewiosPos == 0) && k == 0) { k = 1; return "Создайте ведомость о перемещениии: '" + ToString() + "' с холодильника на линию контроля"; }
                else if (Position == 6 && (PrewiosPos == 1 || PrewiosPos == 0) && k == 1) { k = 0; return "Создайте ведомость о поставке: '" + ToString() + "' С холодильника на линию контроля"; }
                //С линии контроля на отгрузку
                else if (Position == 7 && k == 0) { k = 1; return "Создайте ведомость о перемещениии: '" + ToString() + "' с линии контроля на отгрузку"; }
                else if (Position == 7 && k == 1) { k = 0; return "Создайте ведомость о поставке: '" + ToString() + "' с линии контроля на отгрузку"; }
                //Нужны ли уведомления с отгрузки??
                else
                    return "0";
            }
        }

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
        public int PrewiosPos
        {
            set { _PrewiosPos = value; }
            get { return _PrewiosPos; }
        }
    }
}
