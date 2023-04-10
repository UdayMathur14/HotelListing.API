namespace HotelListing.API.Models.Users
{
    public class AuthResponseDto
    {
        internal string RefreshToken;

        public string UserId { get; set; }

        public string Token { get; set; }


    }
}
