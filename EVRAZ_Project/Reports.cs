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

        private int _Position, k = 0;
        private Rails _Rails;
        public override string ToString()
        {
            //Поставка
            if (Position == 0) { return "Ведомость о поставке: '" + Rail.ToString() + "'"; }
            //Хранение на склад
            else if (Position == 1) {return "Ведомость о перемещениии на склад: '" + Rail.ToString() + "'"; }
            //Передача со склада в печь 
            else if (Position == 2 && k == 0) { k = 1; return "Ведомость о перемещениии: '" + Rail.ToString() + "' в печь со склада"; }
            else if (Position == 2 && k == 1) { k = 0; return "Ведомость о поставке: '" + Rail.ToString() + "' в печь со склада"; }
            //Передача с зоны поставки в печь 
            else if (Position == 3 && k == 0) { k = 1; return "Ведомость о перемещениии: '" + Rail.ToString() + "' в печь с зоны поставки"; }
            else if (Position == 3 && k == 1) { k = 0; return "Ведомость  о поставке: '" + Rail.ToString() + "' в печь с зоны поставки"; }
            //С печи на стан
            else if (Position == 4 && k == 0) { k = 1; return "Ведомость о перемещениии: '" + Rail.ToString() + "' с печи на прокатный стан"; }
            else if (Position == 4 && k == 1) { k = 0; return "Ведомость о поставке: '" + Rail.ToString() + "' с печи на прокатный стан"; }
            //Со стана в холодильник
            else if (Position == 5 && k == 0) { k = 1; return "Ведомость о перемещениии: '" + Rail.ToString() + "' со стана в холодильник"; }
            else if (Position == 5 && k == 1) { k = 0; return "Ведомость о поставке: '" + Rail.ToString() + "' со стана в холодильник"; }
            //С холодильника в хранилище
            else if (Position == 6) {return "Создайте ведомость о перемещениии в хранилище: '" + Rail.ToString() + "'"; }
            //С хранилища на линию контроля
            else if (Position == 7 && k == 0) { k = 1; return "Ведомость о перемещениии: '" + Rail.ToString() + "' с хранилища на линию контроля"; }
            else if (Position == 7 && k == 1) { k = 0; return "Ведомость о поставке: '" + Rail.ToString() + "' с хранилища на линию контроля"; }
            //С холодильника на линию контроля
            else if (Position == 8 && k == 0) { k = 1; return "Ведомость о перемещениии: '" + Rail.ToString() + "' с холодильника на линию контроля"; }
            else if (Position == 8 && k == 1) { k = 0; return "Ведомость о поставке: '" + Rail.ToString() + "' С холодильника на линию контроля"; }
            //С линии контроля на отгрузку
            else if (Position == 9 && k == 0) { k = 1; return "Ведомость о перемещениии: '" + Rail.ToString() + "' с линии контроля на отгрузку"; }
            else if (Position == 9 && k == 1) { k = 0; return "Ведомость о поставке: '" + Rail.ToString() + "' с линии контроля на отгрузку"; }
            //C отгрузки??
            else if (Position == 10) { return "Ведомость об отгрузке: '" + Rail.ToString(); }
            else
                return "0";
        }

        public Reports() { }
        public Reports(int position, Rails rails)
        {
            _Position = position;
            _Rails = rails;
        }
        public Reports(int position, int prewiospos, Rails rails)
        {
            _Position = position;
            _Rails = rails;
        }
        public Reports(int position, string name, string data, string time, Rails rails)
        {
            _Position = position;
            _Name = name;
            _Date = data;
            _Time = time;
            _Rails = rails;
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
    }
}
