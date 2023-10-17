using DAL.DBEntities;
using DAL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebAPICode.Helpers;

namespace BAL.Repositories
{

    public class loginRepository : BaseRepository
    {
        public loginRepository()
            : base()
        {
            DBContext = new db_a74425_premiumposEntities();

        }
        public loginRepository(db_a74425_premiumposEntities contextDB)
            : base(contextDB)
        {
            DBContext = contextDB;
        }
        public static DataTable _dt;
        public static DataSet _ds;
        public AppSettings GetSetting(int UserID)
        {           
            try
            {  
                var lst = new AppSettings();
                var coupon = new List<CouponVM>();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@UserID", UserID);
                _ds = (new DBHelper().GetDatasetFromSP)("sp_GetSettings_Vitamito", p);         
                if (_ds != null)
                {
                    if (_ds.Tables[0] != null)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_ds.Tables[0])).ToObject<List<AppSettings>>().FirstOrDefault();                    }
                    if (_ds.Tables[1] != null)
                    {
                        coupon = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_ds.Tables[1])).ToObject<List<CouponVM>>();
                    }
                    lst.Coupons = coupon;
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public RspBanner GetBanners(int UserID,int LocationID)
        {
            var banners = new List<BannerBLL>();
            var rsp = new RspBanner();
            try
            {
                var list = DBContext.Banners.Where(x => x.StatusID == 1  && x.LocationID == LocationID).Where(x => x.Type == "Header" || x.Type == "Featured").ToList();
               
                foreach (var i in list)
                {
                    banners.Add(new BannerBLL
                    {
                        BannerID = i.BannerID,
                        Description = "",
                        Name = i.Title,
                        UserID = UserID,
                        LocationID = i.LocationID,
                         Type = i.Type,
                       Image = i.Image == null ? "" : ConfigurationManager.AppSettings["AdminURL"].ToString() + i.Image,
                        StatusID = i.StatusID
                    });
                }

                rsp.Banners = banners;
                rsp.status = 1;
                rsp.description = "Success";
                return rsp;
            }
            catch (Exception ex)
            {
                rsp.Banners = banners;
                rsp.status = 0;
                rsp.description = "Failed";
                return rsp;
            }
        }
        public RspAdminLogin GetLoginAdmin(string passcode)
        {
            var rsp = new RspAdminLogin();
            try
            {
                var data = DBContext.Locations.Where(x => x.Passcode == passcode).FirstOrDefault();
                if (data != null)
                {
                    rsp.LocationID = data.ID;
                    rsp.Longitude = data.Longitude;
                    rsp.Latitude = data.Latitude;
                    rsp.ContactNo = data.ContactNo;
                    rsp.Name = data.Name;
                    rsp.status = 1;
                    rsp.description = "Login successfully.";
                }
                else
                {
                    rsp.status = 0;
                    rsp.description = "User not found.";
                }

                return rsp;
            }
            catch (Exception ex)
            {
                rsp.status = 0;
                rsp.description = "Login failed.";
                return rsp;
            }
        }

        public Rsp InsertToken(TokenBLL obj)
        {
            Rsp rsp;
            try
            {
                PushToken token = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(obj)).ToObject<PushToken>();
                token.StatusID = 1;
                var chk = DBContext.PushTokens.Where(x => x.Token == obj.Token).Count();
                if (chk == 0)
                {
                    PushToken data = DBContext.PushTokens.Add(token);
                    DBContext.SaveChanges();
                }


                rsp = new Rsp();
                rsp.status = (int)eStatus.Success;
                rsp.description = "Token Added";
            }
            catch (Exception ex)
            {
                rsp = new Rsp();
                rsp.status = (int)eStatus.Exception;
                rsp.description = "Failed to add token";
            }
            return rsp;
        }
    }
}
