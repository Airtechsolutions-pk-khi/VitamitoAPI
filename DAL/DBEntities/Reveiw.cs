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
    
    public partial class Reveiw
    {
        public int ID { get; set; }
        public Nullable<int> Stars { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> LocationID { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
