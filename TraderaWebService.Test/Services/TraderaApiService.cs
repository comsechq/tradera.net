using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Public = TraderaWebService.PublicService;
using Search = TraderaWebService.SearchService;

namespace TraderaWebService.Test.Services
{
    /// <summary>
    /// Class to search the Tradera API
    /// </summary>
    public class TraderaApiService : ITraderaApiService
    {
        private const string publicEndpoint = "https://api.tradera.com/v3/publicservice.asmx";
        private const string searchEndpoint = "https://api.tradera.com/v3/searchservice.asmx";

        /// <summary>
        /// Constructor.
        /// </summary>
        public TraderaApiService(int appId, string appServiceKey)
        {
            AppId = appId;
            AppServiceKey = appServiceKey;
        }
        
        private BasicHttpBinding binding;

        private Public.AuthenticationHeader publicAuthenticationHeader;
        private Search.AuthenticationHeader searchAuthenticationHeader;

        private Public.ConfigurationHeader publicConfigurationHeader;
        private Search.ConfigurationHeader searchConfigurationHeader;

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public int AppId { get; }

        /// <summary>
        /// Gets the application service key.
        /// </summary>
        /// <value>
        /// The application service key.
        /// </value>
        public string AppServiceKey { get; }

        /// <summary>
        /// Gets the public authentication header.
        /// </summary>
        /// <value>
        /// The public authentication header.
        /// </value>
        public Public.AuthenticationHeader PublicAuthenticationHeader  => publicAuthenticationHeader ??= new Public.AuthenticationHeader {AppId = AppId, AppKey = AppServiceKey};

        /// <summary>
        /// Gets the search authentication header.
        /// </summary>
        /// <value>
        /// The search authentication header.
        /// </value>
        public Search.AuthenticationHeader SearchAuthenticationHeader => searchAuthenticationHeader ??= new Search.AuthenticationHeader {AppId = AppId, AppKey = AppServiceKey};

        /// <summary>
        /// Gets the public configuration header.
        /// </summary>
        /// <value>
        /// The public configuration header.
        /// </value>
        public Public.ConfigurationHeader PublicConfigurationHeader => publicConfigurationHeader ??= new Public.ConfigurationHeader();

        /// <summary>
        /// Gets the search configuration header.
        /// </summary>
        /// <value>
        /// The search configuration header.
        /// </value>
        public Search.ConfigurationHeader SearchConfigurationHeader => searchConfigurationHeader ??= new Search.ConfigurationHeader();

        /// <summary>
        /// Gets the binding.
        /// </summary>
        /// <value>
        /// The binding.
        /// </value>
        public BasicHttpBinding Binding => binding ??= new BasicHttpBinding(BasicHttpSecurityMode.Transport) {MaxReceivedMessageSize = 15000000};

        /// <summary>
        /// Gets the public service SOAP client.
        /// </summary>
        /// <value>
        /// The public service SOAP client.
        /// </value>
        public Public.PublicServiceSoapClient PublicServiceSoapClient => new(Binding, new EndpointAddress(publicEndpoint));

        /// <summary>
        /// Gets the search service SOAP client.
        /// </summary>
        /// <value>
        /// The search service SOAP client.
        /// </value>
        public Search.SearchServiceSoapClient SearchServiceSoapClient => new(Binding, new EndpointAddress(searchEndpoint));

        /// <summary>
        /// Returns the official Tradera.com local time (for use with auction endings).
        /// </summary>
        /// <returns></returns>
        public DateTime GetOfficialTime()
        {
            return PublicServiceSoapClient.GetOfficalTime(PublicAuthenticationHeader, null);
        }

        /// <summary>
        /// Return a hierarchy of Category objects
        /// </summary>
        /// <returns></returns>
        public Task<Public.GetCategoriesResponse> GetCategoriesAsync()
        {
            return PublicServiceSoapClient.GetCategoriesAsync(PublicAuthenticationHeader, PublicConfigurationHeader);
        }

        /// <summary>
        /// Search for items
        /// </summary>
        /// <param name="q">The search query</param>
        /// <param name="categoryId">The id of the category to search</param>
        /// <param name="page">To page to return</param>
        /// <returns></returns>
        public async Task<Search.SearchResponse> SearchAsync(string q, int categoryId, int page)
        {
            return await SearchServiceSoapClient.SearchAsync(SearchAuthenticationHeader, SearchConfigurationHeader, q, categoryId, page, "EndDateAscending");
        }

        /// <summary>
        /// Gets an item
        /// </summary>
        /// <param name="itemId">The id of the item</param>
        /// <returns></returns>
        public async Task<Public.GetItemResponse> GetItemAsync(int itemId)
        {
            return await PublicServiceSoapClient.GetItemAsync(PublicAuthenticationHeader, PublicConfigurationHeader, itemId);
        }
    }
}