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
    
    public partial class sp_InsertOrder_P_API_V2_Result
    {
        public Nullable<int> OrderID { get; set; }
        public string OrderType { get; set; }
        public string PaymentType { get; set; }
        public string CounterType { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<double> total { get; set; }
        public Nullable<double> AmountDiscount { get; set; }
        public Nullable<double> VATper { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<int> TransactionNo { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Cashier { get; set; }
        public Nullable<double> GrandTotal { get; set; }
        public Nullable<double> Tax { get; set; }
    }
}