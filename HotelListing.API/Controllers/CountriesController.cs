using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using HotelListing.API.Contracts;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository countriesRepository;
        private readonly IMapper mapper;

        public CountriesController(ICountriesRepository countriesRepository , IMapper mapper)
        {
            this.countriesRepository = countriesRepository;
            this.mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
          //if (_context.Countries == null)
          //{
          //    return NotFound();
          //}
          var countries = await countriesRepository.GetAllAsync();  
          var records = mapper.Map<List<GetCountryDto>>(countries);   
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
      
            var country = await countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDto = mapper.Map<CountryDto>(country);


            return Ok(countryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(updateCountryDto).State = EntityState.Modified;
            var country = await countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }
            //update country ko lo and country m daal do 
            //take everything from the left object and places into the right object 
            mapper.Map(updateCountryDto, country);

            try
            {
                await countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {
            //i want you to map createcountry into country
            var country = mapper.Map<Country>(createCountry);



            //without automapper
            //var country = new Country
            //{
            //    Name = createCountry.Name,
            //    ShortName = createCountry.ShortName
            //};

            //_context.Countries.Add(country);
            //await _context.SaveChangesAsync();

            await countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }









        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            //with the help of repositary or abstraction 
            var country = await countriesRepository.GetAsync(id);

            //with the help of db context which is injected into the controller 
            //var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            //_context.Countries.Remove(country);
            //await _context.SaveChangesAsync();

            await countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await countriesRepository.Exists(id);
        }
    }
}
