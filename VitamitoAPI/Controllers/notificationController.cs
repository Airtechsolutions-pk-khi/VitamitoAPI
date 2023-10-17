using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace VitamitoAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class notificationController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("api/push/android")]
        public void PushNotification()
        
        {
            try
            {
                var applicationID = "AAAA3z5BiLk:APA91bESrcEdyzX52s4sOMivbjNz5YKRDZvPK9nIJGAXtZ1l3LBwLhBd4QKTsJIUSiJ9V0wiAxM4-4pX0yIajRnSPPTHT5ExEezXAK4VblnwL3UiSFKnDoH_q5DFdY0x-a8W0hAlNBtV";
                var senderId = "958822189241";
                string deviceId = "cEw3E8_OQxm-LihrCL4LLc:APA91bHyjQQuwKW0uJvsFLVQHRQgiprn48S8NaJENqC8LGNg7KR06ae2Nqu1c1xg_u9b0DdrNWCMH4syuLqK1uCto_S0DKYcTlEbJtm2m7gZu3Hy-q4yfUKFAmJlPzTBtnvlVbYIwCmV";
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = "test",
                        title = "test",
                        icon = "myicon",
                        sound = "default"

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
