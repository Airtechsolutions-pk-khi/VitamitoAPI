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
    
    public partial class sp_GetMyOrdersById_Vitamito_Result
    {
        public Nullable<long> Row_Counter { get; set; }
        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> TransactionNo { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<int> PaymentMode { get; set; }
        public Nullable<double> AmountPaid { get; set; }
        public Nullable<double> DiscountPercent { get; set; }
        public Nullable<int> DiscountType { get; set; }
        public Nullable<double> AmountDiscount { get; set; }
        public Nullable<double> ItemDiscountAmount { get; set; }
        public Nullable<double> AmountTotal { get; set; }
        public Nullable<double> GrandTotal { get; set; }
        public Nullable<double> Tax { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public Nullable<System.DateTime> CheckoutDate { get; set; }
        public string SessionID { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public string LastUpdateBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<double> ServiceCharges { get; set; }
        public Nullable<bool> IsPartial { get; set; }
        public Nullable<double> PartialAmount { get; set; }
        public string DiscountReason { get; set; }
        public Nullable<double> FbrAmount { get; set; }
        public string FbrInvoiceNumber { get; set; }
        public string FbrInvoiceResponse { get; set; }
        public string CustomerName { get; set; }
    }
}
