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
    
    public partial class sp_GetOrderModifiers_P_API_Result
    {
        public int ID { get; set; }
        public Nullable<int> OrderDetailID { get; set; }
        public Nullable<int> ModifierID { get; set; }
        public Nullable<int> VariantID { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Type { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string Name { get; set; }
        public string Name1 { get; set; }
    }
}