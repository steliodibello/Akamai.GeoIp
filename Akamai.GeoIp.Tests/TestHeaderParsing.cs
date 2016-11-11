using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akamai.GeoIp.LookupProvider;
using NUnit.Framework;

namespace Akamai.GeoIp.Tests
{
    [TestFixture]
    public class TestHeaderParsing
    {
        private const string HeaderValue = "georegion=263,country_code=US,region_code=MA,city=CAMBRIDGE,dma=50 6,pmsa=1120,areacode=617,county=MIDDLESEX,fips=25017,lat=42.3933,long=-71.1333,timezone=EST,zip=02138-02142+02238-02239,continent=NA ,throughput=vhigh,asnum=21399";
        [Test]
        public void TestCountryCode()
        {
            var value = AkamaiGEoIpProvider.ExtractValue("country_code", HeaderValue);
            Assert.AreEqual(value,"US");

        }

        [Test]
        public void TestZIP()
        {
            var value = AkamaiGEoIpProvider.ExtractValue("zip", HeaderValue);
            Assert.AreEqual(value, "02138-02142+02238-02239");

        }
    }
}
