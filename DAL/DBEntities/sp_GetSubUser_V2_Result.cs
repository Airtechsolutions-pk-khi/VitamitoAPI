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
    
    public partial class sp_GetSubUser_V2_Result
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string ImagePath { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<bool> Subscribe { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string Passcode { get; set; }
        public Nullable<System.DateTime> DateFrom { get; set; }
        public Nullable<System.DateTime> DateTo { get; set; }
        public Nullable<int> TimeZoneID { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public int StatusID { get; set; }
        public string States { get; set; }
        public string Zipcode { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<bool> IsFBR { get; set; }
        public string FbrPOSID { get; set; }
        public string FbrUserCode { get; set; }
        public string Token { get; set; }
    }
}
