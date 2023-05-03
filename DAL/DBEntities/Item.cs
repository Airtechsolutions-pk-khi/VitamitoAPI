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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.CustomerWishLists = new HashSet<CustomerWishList>();
            this.DealsDetails = new HashSet<DealsDetail>();
            this.Inventories = new HashSet<Inventory>();
            this.IssueStockDetails = new HashSet<IssueStockDetail>();
            this.ItemModiferMappings = new HashSet<ItemModiferMapping>();
            this.ItemVariants = new HashSet<ItemVariant>();
            this.OrderDealDetails = new HashSet<OrderDealDetail>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            this.Reveiws = new HashSet<Reveiw>();
            this.Stocks = new HashSet<Stock>();
        }
    
        public int ID { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string NameOnReceipt { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public string Image { get; set; }
        public string Barcode { get; set; }
        public string SKU { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> SortByAlpha { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> NewPrice { get; set; }
        public Nullable<double> Cost { get; set; }
        public string ItemType { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<bool> HasVariant { get; set; }
        public Nullable<bool> IsVATApplied { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        public Nullable<bool> IsStockOut { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerWishList> CustomerWishLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealsDetail> DealsDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueStockDetail> IssueStockDetails { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemModiferMapping> ItemModiferMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemVariant> ItemVariants { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDealDetail> OrderDealDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reveiw> Reveiws { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
