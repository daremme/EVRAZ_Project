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
    
    public partial class Personal_Ved
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal_Ved()
        {
            this.VEDOMOST = new HashSet<VEDOMOST>();
        }
    
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Dolg { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEDOMOST> VEDOMOST { get; set; }
    }
}
