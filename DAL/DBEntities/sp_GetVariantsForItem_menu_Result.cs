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
    
    public partial class sp_GetVariantsForItem_menu_Result
    {
        public Nullable<int> ItemID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public string Type { get; set; }
        public string Barcode { get; set; }
        public string SKU { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}
