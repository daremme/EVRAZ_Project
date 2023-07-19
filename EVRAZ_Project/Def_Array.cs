using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRAZ_Project
{
    class Def_Array
    {
        public double[] Array { get; set; }

        public override string ToString()
        {
            if (Array[0]==0)
                return "Трещина " + Array[1] + " м";
            else return "Излом " + Array[1] + " м";
        }
    }
}
