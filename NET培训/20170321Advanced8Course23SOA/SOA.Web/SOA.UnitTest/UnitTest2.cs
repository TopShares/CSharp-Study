using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace SOA.UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {

            string url = "https://api.test.hotelbeds.com/hotel-api/1.0/hotels";
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler();//{ AutomaticDecompression = DecompressionMethods.GZip };

            using (var http = new HttpClient(handler))
            {
                var content=@"<availabilityRQ xmlns='http://www.hotelbeds.com/schemas/messages' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' >
	<stay checkIn='2016-06-15' checkOut='2016-06-20' shiftDays='2'/>
	<occupancies>
		<occupancy rooms='1' adults='2' children='1'>
			<paxes>
				<pax type='AD'/>
				<pax type='AD'/>
				<pax type='CH' age='8'/>
			</paxes>
		</occupancy>
	</occupancies>
	<hotels>
		<hotel>1067</hotel>
		<hotel>1070</hotel>
		<hotel>1075</hotel>
		<hotel>135813</hotel>
		<hotel>145214</hotel>
		<hotel>1506</hotel>
		<hotel>1508</hotel>
		<hotel>1526</hotel>
		<hotel>1533</hotel>
		<hotel>1539</hotel>
		<hotel>1550</hotel>
		<hotel>161032</hotel>
		<hotel>170542</hotel>
		<hotel>182125</hotel>
		<hotel>187939</hotel>
		<hotel>212167</hotel>
		<hotel>215417</hotel>
		<hotel>228671</hotel>
		<hotel>229318</hotel>
		<hotel>23476</hotel>
	</hotels>
</availabilityRQ>";
                //await异步等待回应
                var response = http.PostAsync(url,content).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
            }
        }
    }
}
