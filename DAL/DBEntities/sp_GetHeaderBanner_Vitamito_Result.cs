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
    
    public partial class sp_GetHeaderBanner_Vitamito_Result
    {
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string PlatformType { get; set; }
        public Nullable<int> IsSilder { get; set; }
        public Nullable<int> IsFeatured { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string Description { get; set; }
        public string ButtonURL { get; set; }
        public Nullable<int> LocationID { get; set; }
    }
}
