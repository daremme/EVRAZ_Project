//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EVRAZ_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Defects_Prod
    {
        public int ID { get; set; }
        public int ID_Products { get; set; }
        public int Type_defects { get; set; }
        public float Lenght { get; set; }
    
        public virtual Type_Def Type_Def { get; set; }
        public virtual Products_Ved Products_Ved { get; set; }
    }
}
