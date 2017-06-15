//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PS_project_auto.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAR()
        {
            this.INFO_COMPREHENSIVE_COVER = new HashSet<INFO_COMPREHENSIVE_COVER>();
            this.INSURANCE_INFO = new HashSet<INSURANCE_INFO>();
        }
    
        public int ID { get; set; }
        public string MARK { get; set; }
        public string MODEL { get; set; }
        public string REGISTRATION { get; set; }
        public string DATA { get; set; }
        public Nullable<int> ENGINE_LITERS { get; set; }
        public Nullable<int> OWNER_ID { get; set; }
    
        public virtual OWNER OWNER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFO_COMPREHENSIVE_COVER> INFO_COMPREHENSIVE_COVER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INSURANCE_INFO> INSURANCE_INFO { get; set; }
    }
}
