using System;
using System.Threading.Tasks;
using TraderaWebService.PublicService;

namespace TraderaWebService.Test.Services
{
    /// <summary>
    /// Interface for the Tradera service wrapping access to the TraderaWebService WSDL generated code.
    /// </summary>
    public interface ITraderaApiService
    {
        /// <summary>
        /// Returns the offical Tradera.com local time (for use with auction endings).
        /// </summary>
        /// <returns></returns>
        DateTime GetOfficialTime();

        /// <summary>
        /// Return a hieradchy of Category objects
        /// </summary>
        /// <returns></returns>
        Task<GetCategoriesResponse> GetCategoriesAsync();

        /// <summary>
        /// Search for items
        /// </summary>
        /// <param name="q">The search query</param>
        /// <param name="categoryId">The id of the category to search</param>
        /// <param name="page">To page to return</param>
        /// <returns></returns>
        Task<SearchService.SearchResponse> SearchAsync(string q, int categoryId, int page);

        /// <summary>
        /// Gets an item
        /// </summary>
        /// <param name="itemId">The id of the item</param>
        /// <returns></returns>
        Task<PublicService.GetItemResponse> GetItemAsync(int itemId);
    }
}