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
    
    public partial class LoyalityLog
    {
        public int LoyalityID { get; set; }
        public Nullable<double> Points { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> LastUpdatedDate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}