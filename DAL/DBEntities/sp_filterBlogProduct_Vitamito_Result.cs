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
    
    public partial class sp_filterBlogProduct_Vitamito_Result
    {
        public int BlogID { get; set; }
        public Nullable<int> BlogCategoryID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public Nullable<bool> IsPublish { get; set; }
        public Nullable<System.DateTime> PostedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string ImageSmall { get; set; }
        public string ImageLarge { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
    }
}
