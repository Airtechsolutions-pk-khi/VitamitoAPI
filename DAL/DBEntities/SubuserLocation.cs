//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.DBEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubuserLocation
    {
        public int SubUserLocationID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> SubUserID { get; set; }
    
        public virtual Location Location { get; set; }
        public virtual SubUser SubUser { get; set; }
    }
}
