//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GidraSIM.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Procedures
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Procedures()
        {
            this.ProceduresResources = new HashSet<ProceduresResources>();
        }
    
        public int ProcedureId { get; set; }
        public Nullable<int> ProcessId { get; set; }
        public int ProcedureNameId { get; set; }
        public string FunctionExpression { get; set; }
        public System.DateTime TotalTime { get; set; }
        public decimal TotalPrice { get; set; }
    
        public virtual ProcedureNames ProcedureNames { get; set; }
        public virtual Processes Processes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProceduresResources> ProceduresResources { get; set; }
    }
}
