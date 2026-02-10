using Sayara.Models.DTOs;
using Sayara.Repositories;

namespace Sayara.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly ILogger<ListingService> _logger;

        public ListingService(IListingRepository listingRepository, ILogger<ListingService> logger)
        {
            _listingRepository = listingRepository;
            _logger = logger;
        }
    }
}
