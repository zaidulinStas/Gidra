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
    
    public partial class ProceduresParameters
    {
        public int ProcedureParameterId { get; set; }
        public int BaseProcedureParameterNameId { get; set; }
        public int ProcedureId { get; set; }
        public Nullable<double> Value { get; set; }
    
        public virtual BaseProcedureParameterNames BaseProcedureParameterNames { get; set; }
        public virtual Procedures Procedures { get; set; }
    }
}
