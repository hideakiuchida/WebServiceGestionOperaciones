//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bonus.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class foto
    {
        public int id { get; set; }
        public string foto1 { get; set; }
        public int id_inspeccion { get; set; }
    
        public virtual inspeccion inspeccion { get; set; }
    }
}
