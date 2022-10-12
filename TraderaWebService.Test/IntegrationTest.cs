using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TraderaWebService.Test.Services;

namespace TraderaWebService.Test
{
    [TestFixture]
    public class IntegrationTest
    {
        [Test]
        public async Task SearchAndGetItemDetails()
        {
            // NEVER push real appId and service key values!
            var appId = 123;
            var appServiceKey = "no-no-no";

            var traderaApiService = new TraderaApiService(appId, appServiceKey);

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
