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
    
    public partial class Error_Bank
    {
        public int Id { get; set; }
        public System.DateTime SubmitDate { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<System.DateTimeOffset> DeleteDate { get; set; }
        public bool IsDelete { get; set; }
        public string Employee_Id { get; set; }
        public string Class_Id { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
