using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TraderaWebService.Test.Services;

namespace TraderaWebService.Test
{
    [TestFixture]
    public class IntegrationTest
    {
        private TraderaApiService Setup()
        {
            // NEVER push real appId and service key values!
            var appId = 1234;
            var appServiceKey = "no-no-no";

            return new TraderaApiService(appId, appServiceKey);
        }

        [Test]
        public async Task GetOfficialTime()
        {
            var traderaApiService = Setup();

            var now = await traderaApiService.GetOfficialTime();

            Assert.Less(DateTime.MinValue, now);
        }

        [Test]
        public async Task SearchAndGetItemDetails()
        {
            var traderaApiService = Setup();

            var response = await traderaApiService.SearchAsync("batman", 33, 0);

            Assert.Less(0, response.SearchResult.TotalNumberOfItems);
            Assert.Less(0, response.SearchResult.Items.Length);
            
            foreach (var result in response.SearchResult.Items.Take(1))
            {
                var moreInfo = await traderaApiService.GetItemAsync(result.Id);

                Assert.IsNotNull(moreInfo.GetItemResult.ItemLink);
            }
        }
    }
}
