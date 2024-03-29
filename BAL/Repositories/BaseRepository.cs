﻿using System.Configuration;
using DAL.DBEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using DAL.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace BAL.Repositories
{
    public class BaseRepository : IDisposable
    {

        StreamWriter _sw;
        public db_a74425_premiumposEntities DBContext;
        public BaseRepository()
        {
            DBContext = new db_a74425_premiumposEntities();
        }

        public BaseRepository(db_a74425_premiumposEntities ContextDB)
        {
            DBContext = ContextDB;
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DBContext != null)
                {
                    DBContext.Dispose();
                    DBContext = null;

                }
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~BaseRepository()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public void ErrorLog(Exception e, string FnName, string FileName)
        {
            try
            {
            }
            catch
            {
            }
        }
        public void LogWrite(string msg, string fileName)
        {
            _sw.WriteLine(DateTime.UtcNow.ToLongTimeString() + " " + msg);
            _sw.Close();
        }
        public string DateFormat(string Date)
        {
            if (Date != "")
                return Convert.ToDateTime(Date).ToString("yyyy-MM-dd hh:mm:ss");
            else
                return "";
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public void Email(string _SubjectEmail, string _BodyEmail, string _To, string FromAddress, string Password, string SMTP, int Port)
        {
            try
            {
                using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
                {
                    mail.From = new MailAddress(FromAddress, "MarnPos");
                    mail.To.Add(_To);
                    mail.Subject = _SubjectEmail;
                    mail.Body = _BodyEmail;
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient(SMTP, Port))
                    {
                        smtp.Credentials = new NetworkCredential(FromAddress, Password);
                        smtp.EnableSsl = false;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {

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
		public Rsp InsertCustomerToken(TokenBLL obj)
		{
			Rsp rsp;
			try
			{
				PushToken token = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(obj)).ToObject<PushToken>();
				token.StatusID = 1;
				var chk = DBContext.PushTokens.Where(x => x.Token == obj.Token && x.CustomerID == obj.CustomerID).Count();
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
		public void PushNotificationAndroid(PushNoticationBLL obj)
        {
            try
            {              
                var applicationID = "AAAAOEAc4Ss:APA91bGk3GivYxg0kfQ8l-MDWhBo9jgmgoRI6SDCY-KDDm2EG1cibeTmSKOFLLoFF6mVaV2cmRGwCJRrz-xvKbVYe7twHVwgMjP3luqBuTwcmvDMYSDqjzVjlpRJclXGUaOykMAk9ZdB";
                var senderId = "241593803051";
                string deviceId = obj.DeviceID;
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = obj.Message,
                        title = obj.Title,
                        icon = "myicon"

                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
		public void PushNotificationAndroidCustomer(PushNoticationBLL obj)
		{
			try
			{
				var applicationID = "AAAA3z5BiLk:APA91bESrcEdyzX52s4sOMivbjNz5YKRDZvPK9nIJGAXtZ1l3LBwLhBd4QKTsJIUSiJ9V0wiAxM4-4pX0yIajRnSPPTHT5ExEezXAK4VblnwL3UiSFKnDoH_q5DFdY0x-a8W0hAlNBtV";
				var senderId = "958822189241";
				string deviceId = obj.DeviceID;
				WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
				tRequest.Method = "post";
				tRequest.ContentType = "application/json";
				var data = new
				{
					to = deviceId,
					notification = new
					{
						body = obj.Message,
						title = obj.Title,
						icon = "myicon"

					}
				};
				var serializer = new JavaScriptSerializer();
				var json = serializer.Serialize(data);
				Byte[] byteArray = Encoding.UTF8.GetBytes(json);
				tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
				tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
				tRequest.ContentLength = byteArray.Length;
				using (Stream dataStream = tRequest.GetRequestStream())
				{
					dataStream.Write(byteArray, 0, byteArray.Length);
					using (WebResponse tResponse = tRequest.GetResponse())
					{
						using (Stream dataStreamResponse = tResponse.GetResponseStream())
						{
							using (StreamReader tReader = new StreamReader(dataStreamResponse))
							{
								String sResponseFromServer = tReader.ReadToEnd();
								string str = sResponseFromServer;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				string str = ex.Message;
			}
		}

	}
}
