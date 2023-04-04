using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Data
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public double Rating { get; set; }


        //every hotel belongs to a country , this is the foriegn key 
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }  

        public Country Country { get; set; }

    }
}
