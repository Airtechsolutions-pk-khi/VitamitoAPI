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
    
    public partial class sp_GetCustomerOrders_api_Result
    {
        public int ID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> TransactionNo { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<int> TableNo { get; set; }
        public Nullable<int> WaiterNo { get; set; }
        public Nullable<int> OrderTakerID { get; set; }
        public Nullable<System.DateTime> OrderCreatedDT { get; set; }
        public string OrderType { get; set; }
        public Nullable<int> GuestCount { get; set; }
        public string DeliveryAddress { get; set; }
        public Nullable<int> AgentID { get; set; }
        public string AgentName { get; set; }
        public string DeliveryTime { get; set; }
        public Nullable<double> Points { get; set; }
        public string OrderMode { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string SessionID { get; set; }
        public string LastUpdateBy { get; set; }
        public Nullable<System.DateTime> LastUpdateDT { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<bool> IsAvailiable { get; set; }
        public string CounterType { get; set; }
        public Nullable<int> DeliveryStatus { get; set; }
        public string FbrInvoiceNumber { get; set; }
        public Nullable<bool> IsOrderFbr { get; set; }
        public string FbrStatus { get; set; }
        public Nullable<int> CustomerAddressID { get; set; }
        public string Address { get; set; }
        public string NickName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<int> StatusID1 { get; set; }
        public string StreetName { get; set; }
        public Nullable<int> CustomerID1 { get; set; }
        public string Country { get; set; }
        public string ContactNo { get; set; }
    }
}
