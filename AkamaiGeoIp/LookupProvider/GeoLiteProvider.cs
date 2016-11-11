 using Sitecore.Analytics.Lookups;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using System;
using System.Web;
using System.Web.Hosting;

namespace Akamai.GeoIp.LookupProvider
{
    public class AkamaiGEoIpProvider : LookupProviderBase
    {       
        public override WhoIsInformation GetInformationByIp(string ip)
        {
            WhoIsInformation information = new WhoIsInformation();
            var headerValue = HttpContext.Current.Request.Headers["X-Akamai-Edgescape"];
            information.Country = ExtractValue("country_code", headerValue);
            information.PostalCode = ExtractValue("zip", headerValue);
            information.City = ExtractValue("city", headerValue);
            information.Region = ExtractValue("region_code", headerValue);
            information.Latitude = ExtractValue("lat", headerValue);
            information.Longitude = ExtractValue("long", headerValue);
            information.AreaCode = ExtractValue("areacode", headerValue);
            //ToDo: double check if I forgot any relevant values... I personalise only on country and city...
         
            return information;
        }

        public static string ExtractValue(string keyName, string headerValue)
        {
            //ToDo: nice regex to Parse Value
            var keyPosition = headerValue.LastIndexOf(keyName) + keyName.Length;
            var remString = headerValue.Substring(keyPosition + 1, headerValue.Length - keyPosition - 1);
            var firstComma = remString.IndexOf(',');
            return headerValue.Substring(keyPosition + 1, firstComma);
        }
    }
}


 