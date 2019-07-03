//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BootcampManagement.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Education
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Education()
        {
            this.Education_History = new HashSet<Education_History>();
        }
    
        public string Id { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<System.DateTimeOffset> DeleteDate { get; set; }
        public bool IsDelete { get; set; }
        public string Degree_Id { get; set; }
        public string Major_Id { get; set; }
        public string University_Id { get; set; }
    
        public virtual Degree Degree { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_History> Education_History { get; set; }
        public virtual Major Major { get; set; }
        public virtual University University { get; set; }
    }
}