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
    
    public partial class ItemModiferMapping
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> ModifierID { get; set; }
        public Nullable<int> VariantID { get; set; }
        public string Type { get; set; }
    
        public virtual Modifier Modifier { get; set; }
        public virtual Variant Variant { get; set; }
        public virtual Item Item { get; set; }
    }
}
