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
    
    public partial class sp_GetModifierAndVariant_Result
    {
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> ModifierID { get; set; }
        public string ModifierName { get; set; }
        public Nullable<double> ModifierPrice { get; set; }
        public string ModifierType { get; set; }
        public string ModifierBarcode { get; set; }
        public Nullable<int> VariantID { get; set; }
        public string VariantName { get; set; }
        public Nullable<decimal> VariantPrice { get; set; }
        public string VariantType { get; set; }
        public string VariantBarcode { get; set; }
        public string Type { get; set; }
    }
}
