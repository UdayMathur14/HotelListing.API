using HotelListing.API.Contracts;
using HotelListing.API.Data;

namespace HotelListing.API.Repository
{
    public class HotelsRepositary : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelsRepositary(HotelListingDbContext context) : base(context)
        {

        }
    }
}
