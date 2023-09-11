using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRAZ_Project
{
    public class Defect
    {
        private string _Type_Def;
        private double _Lenght_def;

        public override string ToString()
        {
            return _Type_Def + " - " + _Lenght_def + " см";
        }

        public Defect() { }

        public Defect(string Type_Def, double Lenght_def)
        {
            _Type_Def = Type_Def;
            _Lenght_def = Lenght_def;
        }

        public string Type_Def
        {
            get { return _Type_Def; }
        }

        public double Lenght_def
        {
            get { return _Lenght_def; }
        }
    }
}
