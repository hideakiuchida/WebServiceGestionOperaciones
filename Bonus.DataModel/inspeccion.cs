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
    
    public partial class inspeccion
    {
        public inspeccion()
        {
            this.foto = new HashSet<foto>();
        }
    
        public int id { get; set; }
        public string nro_inspeccion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> cantida_muestra { get; set; }
        public string lugar { get; set; }
        public int id_orden { get; set; }
    
        public virtual ICollection<foto> foto { get; set; }
        public virtual orden orden { get; set; }
    }
}
