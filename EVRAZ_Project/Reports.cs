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
        public Rails _Rails;
        public int k = 0;
        
        public override string ToString()
        {
            //Поставка
            if (_Rails.Position == 0) { return "Создайте ведомость о поставке: '" + _Rails.ToString()+"'"; }
            //Хранение на склад
            else if (_Rails.Position == 1) { _Type = 1; return "Создайте ведомость о перемещениии на склад: '" + _Rails.ToString() + "'"; }
            //Передача со склада в печь 
            else if (_Rails.Position == 2 && _Rails.PrewiosPos == 1 && k == 0) { _Type = 3; k = 1;  return "Создайте ведомость о перемещениии: '" + _Rails.ToString() + "' в печь со склада"; }
            else if (_Rails.Position == 2 && _Rails.PrewiosPos == 1 && k == 1) { _Type = 0;  return "Создайте ведомость о поставке: '" + _Rails.ToString() + "' в печь со склада"; }
            //Передача с зоны поставки в печь  
            else if (_Rails.Position == 2 && _Rails.PrewiosPos == 0 && k == 0) { _Type = 3; k = 1; return "Создайте ведомость о перемещениии: '" + _Rails.ToString() + "' в печь с зоны поставки"; }
            else if (_Rails.Position == 2 && _Rails.PrewiosPos == 0 && k == 1) { _Type = 0; return "Создайте ведомость о поставке: '" + _Rails.ToString() + "' в печь с зоны поставки"; }
            //С печи на стан
            else if (_Rails.Position == 3 && k == 0) { _Type = 3; k = 1; return "Создайте ведомость о перемещениии: '" + _Rails.ToString() + "' с печи на прокатный стан"; }
            else if (_Rails.Position == 3 && k == 1) { _Type = 0; return "Создайте ведомость о поставке: '" + _Rails.ToString() + "' с печи на прокатный стан"; }
            //Со стана в холодильник
            else if (_Rails.Position == 4 && k == 0) { _Type = 3; k = 1; return "Создайте ведомость о перемещениии: '" + _Rails.ToString() + "' со стана в холодильник"; }
            else if (_Rails.Position == 4 && k == 1) { _Type = 0; return "Создайте ведомость о поставке: '" + _Rails.ToString() + "' со стана в холодильник"; }
            //С холодильника в хранилище
            else if (_Rails.Position == 5) { return "Создайте ведомость о перемещениии в хранилище: '" + _Rails.ToString() + "'"; }
            //С хранилища на линию контроля
            else if (_Rails.Position == 6 && _Rails.PrewiosPos == 2 && k == 0) { _Type = 3; k = 1; return "Создайте ведомость о перемещениии: '" + _Rails.ToString() + "' с хранилища на линию контроля"; }
            else if (_Rails.Position == 6 && _Rails.PrewiosPos == 2 && k == 1) { _Type = 0; return "Создайте ведомость о поставке: '" + _Rails.ToString() + "' с хранилища на линию контроля"; }
            //С холодильника на линию контроля
            else if (_Rails.Position == 6 && (_Rails.PrewiosPos == 1 || _Rails.PrewiosPos == 0) && k == 0) { _Type = 3; k = 1; return "Создайте ведомость о перемещениии: '" + _Rails.ToString() + "' с холодильника на линию контроля"; }
            else if (_Rails.Position == 6 && (_Rails.PrewiosPos == 1 || _Rails.PrewiosPos == 0) && k == 1) { _Type = 0; return "Создайте ведомость о поставке: '" + _Rails.ToString() + "' С холодильника на линию контроля"; }
            //С линии контроля на отгрузку
            else if (_Rails.Position == 7 && k == 0) { _Type = 3; k = 1; return "Создайте ведомость о перемещениии: '" + _Rails.ToString() + "' с линии контроля на  зону отгрузки"; }
            else if (_Rails.Position == 7 && k == 1) { _Type = 0; return "Создайте ведомость о поставке: '" + _Rails.ToString() + "' с линии контроля на зону отгрузки"; }
            //Нужны ли уведомления с отгрузки??
            else
                return "0";
        }
        public Rails Rail
        {
            set { _Rails = value; }
            get { return _Rails; }
        }
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
