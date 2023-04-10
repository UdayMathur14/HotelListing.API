using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Data
{
    public class ApiUser :IdentityUser
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

    }
}
