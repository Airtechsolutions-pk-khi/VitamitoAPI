using DAL.DBEntities;
using DAL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebAPICode.Helpers;

namespace BAL.Repositories
{

    public class menuRepository : BaseRepository
    {

        public menuRepository()
            : base()
        {
            DBContext = new db_a74425_premiumposEntities();

        }

        public menuRepository(db_a74425_premiumposEntities contextDB)
            : base(contextDB)
        {
            DBContext = contextDB;
        }
        public RspMenu GetMenu(int locationID,int UserID)
        {
            var CategoryLst = new List<CategoryBLL>();
            var ItemLst = new List<ItemBLL>();
            var SubCategoryLst = new List<SubCategoryBLL>();
            var lstModifier = new List<ModifierBLL>();
            var lstVariant = new List<VariantsBLL>();
            var lstFeatured = new List<FeaturedBLL>();
            //var lstNewArrival = new List<NewArrivalBLL>();
            var lstPopular = new List<PopularBLL>();

            var lstIM = new List<string>();
            var rsp = new RspMenu();
            try
            {
                var catlist = DBContext.sp_GetCategory_menu(locationID).ToList();
                var subcatlist = DBContext.sp_GetSubCategory_menu(locationID).ToList();
                var itemslist = DBContext.sp_GetItem_menu(locationID).ToList();
                var modifierlist = DBContext.sp_GetModifiersForItem_menu(UserID).ToList();
                var variantlist = DBContext.sp_GetVariantsForItem_menu(UserID).ToList();

                


                if (catlist != null && catlist.Count() > 0)
                {
                    lstFeatured = new List<FeaturedBLL>();

                    foreach (var featured in itemslist.OrderByDescending(x => x.DisplayOrder).Where(x => x.IsFeatured == true).OrderBy(c => Guid.NewGuid()).Take(6).ToList())
                    {
                        lstIM = new List<string>();
                        lstIM.Add(featured.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + featured.Image);


                        lstFeatured.Add(new FeaturedBLL
                        {                          
                            ID = featured.ID,
                            Name = featured.Name,
                            Description = featured.Description,
                            Image = featured.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + featured.Image,
                            ItemType = featured.ItemType,
                            SubCategoryID = featured.SubCategoryID,
                            NameOnReceipt = featured.NameOnReceipt,
                            StatusID = featured.StatusID,
                            Barcode = featured.Barcode,
                            SKU = featured.SKU,
                            Price = featured.Price,
                            NewPrice = featured.NewPrice,
                            //DiscountPercent = DiscountPercent,
                            Cost = featured.Cost,
                            ItemImages = lstIM.ToArray(),
                            DisplayOrder = featured.DisplayOrder,
                            IsFeatured = false,
                            Modifiers = lstModifier,
                            Variants = lstVariant,
                            CurrentStock = featured.CurrentStock,
                            IsInventoryItem = featured.IsInventoryItem > 0 ? true : false
                        });
                    }


                    try
                    {
                        DataSet _ds;
                        SqlParameter[] p = new SqlParameter[1];
                        p[0] = new SqlParameter("@LocationID", locationID);
                        _ds = (new DBHelper().GetDatasetFromSP)("sp_GetSelectedFlashItem", p);

                        
                        var _dt1 = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_ds.Tables[0])).ToObject<List<WebSalesBLL>>().ToList();
                        var _dt2 = _ds.Tables[1] == null ? new List<WebSalesDetailBLL>() : JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_ds.Tables[1])).ToObject<List<WebSalesDetailBLL>>().ToList();

                        foreach (var item in _dt1)
                        {
                            item.WebSaleDetails = _dt2.Where(x => x.WebCustomizedSaleID == item.WebCustomisedSaleID).ToList();
                        }
                        
                        rsp.FlashSale = _dt1.Where(x => x.Type == "flash").FirstOrDefault();
                        rsp.NewArrival = _dt1.Where(x => x.Type == "newarrival").FirstOrDefault();
                        rsp.Clearance = _dt1.Where(x => x.Type == "clearance").FirstOrDefault();


                    }
                    catch(Exception ex)
                    { }


                    //lstNewArrival = new List<NewArrivalBLL>();
                    //foreach (var newArrival in itemslist.OrderByDescending(c => c.LastUpdatedDate).Take(7).OrderBy(c => Guid.NewGuid()).ToList())
                    //{
                    //    lstIM = new List<string>();
                    //    lstIM.Add(newArrival.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + newArrival.Image);


                    //    lstNewArrival.Add(new NewArrivalBLL
                    //    {
                    //        ID = newArrival.ID,
                    //        Name = newArrival.Name,
                    //        Description = newArrival.Description,
                    //        Image = newArrival.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + newArrival.Image,
                    //        ItemType = newArrival.ItemType,
                    //        SubCategoryID = newArrival.SubCategoryID,
                    //        NameOnReceipt = newArrival.NameOnReceipt,
                    //        StatusID = newArrival.StatusID,
                    //        Barcode = newArrival.Barcode,
                    //        SKU = newArrival.SKU,
                    //        Price = newArrival.Price,
                    //        NewPrice = newArrival.NewPrice,
                    //        //DiscountPercent = DiscountPercent,
                    //        Cost = newArrival.Cost,
                    //        ItemImages = lstIM.ToArray(),
                    //        DisplayOrder = newArrival.DisplayOrder,
                    //        IsFeatured = false,
                    //        Modifiers = lstModifier,
                    //        Variants = lstVariant,
                    //        CurrentStock = newArrival.CurrentStock,
                    //        IsInventoryItem = newArrival.IsInventoryItem > 0 ? true : false
                    //    });
                    //}


                    foreach (var popular in itemslist.OrderByDescending(c => c.LastUpdatedDate).Take(7).OrderBy(c => Guid.NewGuid()).ToList())
                    {
                        lstIM = new List<string>();
                        lstIM.Add(popular.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + popular.Image);


                        lstPopular.Add(new PopularBLL
                        {
                            ID = popular.ID,
                            Name = popular.Name,
                            Description = popular.Description,
                            Image = popular.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + popular.Image,
                            ItemType = popular.ItemType,
                            SubCategoryID = popular.SubCategoryID,
                            NameOnReceipt = popular.NameOnReceipt,
                            StatusID = popular.StatusID,
                            Barcode = popular.Barcode,
                            SKU = popular.SKU,
                            Price = popular.Price,
                            NewPrice = popular.NewPrice,
                            //DiscountPercent = DiscountPercent,
                            Cost = popular.Cost,                           
                            ItemImages = lstIM.ToArray(),
                            DisplayOrder = popular.DisplayOrder,
                            IsFeatured = false,
                            Modifiers = lstModifier,
                            Variants = lstVariant,
                            CurrentStock = popular.CurrentStock,
                            IsInventoryItem = popular.IsInventoryItem > 0 ? true : false
                        });
                    }
                    #region category
                    CategoryLst = new List<CategoryBLL>();
                    foreach (var Cat in catlist)
                    {
                        #region subcategory
                        SubCategoryLst = new List<SubCategoryBLL>();
                        foreach (var SubCat in subcatlist.Where(x => x.StatusID == 1 && x.CategoryID == Cat.ID).OrderBy(x => x.DisplayOrder).ToList())
                        {
                            #region item
                            ItemLst = new List<ItemBLL>();
                            foreach (var item in itemslist.Where(x => x.StatusID == 1 && x.SubCategoryID == SubCat.ID).OrderBy(x => Guid.NewGuid()).ToList())
                            {

                                lstModifier = new List<ModifierBLL>();
                                foreach (var modifiers in modifierlist.Where(x => x.StatusID == 1 && x.ItemID == item.ID).OrderBy(x => x.DisplayOrder).ToList())
                                {
                                    lstModifier.Add(new ModifierBLL
                                    {
                                        ID = modifiers.ID,
                                        Name = modifiers.Name,
                                        ArabicName = modifiers.ArabicName,
                                        Description = modifiers.Description,
                                        Type = modifiers.Type,
                                        Barcode = modifiers.Barcode,
                                        SKU = modifiers.SKU,
                                        Price = Convert.ToDouble(modifiers.Price),
                                        StatusID = Convert.ToInt32(modifiers.StatusID)

                                    });
                                }
                                lstVariant = new List<VariantsBLL>();
                                foreach (var variant in variantlist.Where(x => x.StatusID == 1 && x.ItemID == item.ID).OrderBy(x => x.DisplayOrder).ToList())
                                {
                                    lstVariant.Add(new VariantsBLL
                                    {
                                        ID = variant.ID,
                                        Name = variant.Name,
                                        ArabicName = variant.ArabicName,
                                        Description = variant.Description,
                                        Type = variant.Type,
                                        Barcode = variant.Barcode,
                                        SKU = variant.SKU,
                                        Price = Convert.ToDouble(variant.Price),
                                        StatusID = Convert.ToInt32(variant.StatusID)
                                    });
                                }

                                

                               

                                lstIM = new List<string>();
                                lstIM.Add(item.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + item.Image) ;

                                var random = new Random();
                                var randomIF = new List<string> { "true","false"};

                                var dis = (item.NewPrice / item.Price) * 100;
                                var per = 100 - dis;
                                var DiscountPercent = per;
                                ItemLst.Add(new ItemBLL
                                {
                                    
                                    ID = item.ID,
                                    Name = item.Name,
                                    Description = item.Description,
                                    Image = item.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + item.Image,
                                    ItemType = item.ItemType,
                                    SubCategoryID = item.SubCategoryID,
                                    NameOnReceipt = item.NameOnReceipt,
                                    StatusID = item.StatusID,
                                    Barcode = item.Barcode,
                                    SKU = item.SKU,
                                    Price = item.Price,
                                    NewPrice = item.NewPrice,
                                    DiscountPercent = DiscountPercent,
                                    Cost = item.Cost,
                                    Modifiers = lstModifier,
                                    Variants = lstVariant,                                   
                                    ItemImages=lstIM.ToArray(),
                                    DisplayOrder=item.DisplayOrder,
                                    IsFeatured= false,
                                    CurrentStock = item.CurrentStock,
                                    IsInventoryItem=item.IsInventoryItem>0?true:false
                                });
                            }
                            SubCategoryLst.Add(new SubCategoryBLL
                            {
                                SubCategoryID = SubCat.ID,
                                CategoryID = SubCat.CategoryID,
                                CategoryName = Cat.Name,
                                Name = SubCat.Name,
                                Description = SubCat.Description,
                                Image = SubCat.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + SubCat.Image,
                                StatusID = SubCat.StatusID,
                                Items = ItemLst
                            });
                            #endregion items
                        }
                        CategoryLst.Add(new CategoryBLL
                        {
                            ID = Cat.ID,
                            Name = Cat.Name,
                            Description = Cat.Description,
                            Image = Cat.Image == null ? ConfigurationSettings.AppSettings["ApiURL"].ToString() + "/assets/images/defaultimg.jpg" : ConfigurationSettings.AppSettings["AdminURL"].ToString() + Cat.Image,
                            StatusID = Cat.StatusID,
                            LocationID = Cat.LocationID,
                            Subcategories = SubCategoryLst
                        });
                        #endregion subcategory
                    }
                    #endregion category
                }
                rsp.Categories = CategoryLst;
                rsp.FeaturedProducts = lstFeatured;
                rsp.PopularProducts = lstPopular;
                //rsp.NewArrival = lstNewArrival;

               
                rsp.status = 1;
                rsp.description = "Success";


                return rsp;
            }
            catch (Exception ex)
            {
                rsp.Categories = new List<CategoryBLL>();
                rsp.status = 0;
                rsp.description = "Failed";
                return rsp;
            }
        }
        //public RspMenu GetMenuV2(int brandID)
        //{
        //    var bll = new List<CategoryBLL>();
        //    var lstItem = new List<ItemBLL>();
        //    var lstModifier = new List<ModifierBLL>();
        //    var rsp = new RspMenu();
        //    try
        //    {
        //        var ds = GetMenu_ADO(brandID);
        //        var _dsCategory = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0])).ToObject<List<CategoryBLL>>();
        //        var _dsItem = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[1])).ToObject<List<ItemBLL>>();
        //        var _dsModifier = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[2])).ToObject<List<ModifierBLL>>();

        //        foreach (var i in _dsCategory)
        //        {
        //            lstItem = new List<ItemBLL>();
        //            foreach (var j in _dsItem.Where(x => x.StatusID == 1 && x.CategoryID == i.CategoryID))
        //            {
        //                lstModifier = new List<ModifierBLL>();
        //                foreach (var k in _dsModifier.Where(x => x.StatusID == 1 && x.ItemID == j.ItemID))
        //                {
        //                    lstModifier.Add(new ModifierBLL
        //                    {
        //                        Name = k.Name,
        //                        StatusID = k.StatusID,
        //                        ArabicName = k.ArabicName,
        //                        Description = k.Description,
        //                        Image = k.Image == null ? "" : ConfigurationManager.AppSettings["AdminURL"].ToString() + k.Image,
        //                        LastUpdatedBy = k.LastUpdatedBy,
        //                        LastUpdatedDate = k.LastUpdatedDate,
        //                        Price = k.Price,
        //                        BrandID = k.BrandID,
        //                        ModifierID = k.ModifierID
        //                    });
        //                }

        //                lstItem.Add(new ItemBLL
        //                {
        //                    Name = j.Name,
        //                    StatusID = j.StatusID,
        //                    ArabicName = j.ArabicName,
        //                    Barcode = j.Barcode,
        //                    CategoryID = j.CategoryID,
        //                    Cost = j.Cost,
        //                    Description = j.Description,
        //                    DisplayOrder = j.DisplayOrder,
        //                    Image = j.Image == null ? "" : ConfigurationManager.AppSettings["AdminURL"].ToString() + j.Image,
        //                    ItemID = j.ItemID,
        //                    ItemType = j.ItemType,
        //                    LastUpdatedBy = j.LastUpdatedBy,
        //                    LastUpdatedDate = j.LastUpdatedDate,
        //                    Price = j.Price,
        //                    SKU = j.SKU,
        //                    UnitID = j.UnitID,
        //                    Calories = j.Calories,
        //                    IsSoldOut = false,
        //                    modifiers = lstModifier
        //                });
        //            }
        //            bll.Add(new CategoryBLL
        //            {
        //                BrandID = i.BrandID,
        //                ArabicName = i.ArabicName,
        //                LastUpdatedDate = i.LastUpdatedDate,
        //                LastUpdatedBy = i.LastUpdatedBy,
        //                CategoryID = i.CategoryID,
        //                Description = i.Description,
        //                DisplayOrder = i.DisplayOrder,
        //                LocationID = i.BrandID,
        //                Name = i.Name,
        //                Image = i.Image,
        //                StatusID = i.StatusID,
        //                items = lstItem
        //            });
        //        }

        //        rsp.categories = bll;
        //        rsp.status = 1;
        //        rsp.description = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        rsp.categories = bll;
        //        rsp.status = 0;
        //        rsp.description = "Failed";
        //    }
        //    return rsp;
        //}
        public DataSet GetMenu_ADO(int BrandID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@BrandID", BrandID);
                ds = (new DBHelper().GetDatasetFromSP)("sp_GetMenu_api", p);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
