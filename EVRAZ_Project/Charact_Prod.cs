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
    
    public partial class Charact_Prod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Charact_Prod()
        {
            this.Products_Ved = new HashSet<Products_Ved>();
        }
    
        public int ID { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public double Thiickness { get; set; }
        public double Year { get; set; }
        public string Creater { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products_Ved> Products_Ved { get; set; }
    }
}