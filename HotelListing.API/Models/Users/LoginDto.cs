using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Users
{
    public class LoginDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(15 , ErrorMessage ="your password is limited to {2} to {1} character",MinimumLength = 5)]
        public string Password { get; set; }    
    }
}
