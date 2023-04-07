using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Contracts;
using AutoMapper;
using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        
        private readonly IHotelRepository hotelRepository;
        private readonly IMapper mapper;

        public HotelsController( IHotelRepository hotelRepository , IMapper mapper)
        {

            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotels = await hotelRepository.GetAllAsync();
            return Ok(mapper.Map<List<HotelDto>>(hotels));
           // return await hotelRepository.GetAllAsync();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {

            var hotel = await hotelRepository.GetAsync(id);
           
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<HotelDto>(hotel));
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto hoteldto)
        {
            if (id != hoteldto.Id)
            {
                return BadRequest();
            }

            //  _context.Entry(hotel).State = EntityState.Modified;
            var hotel = await hotelRepository.GetAsync(id);
            if(hotel == null)
            {
                return NotFound();
            }

            mapper.Map(hoteldto, hotel);

            try
            {
                await hotelRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(HotelDto hotelDto)
        {
            //if (_context.Hotels == null)
            //{
            //    return Problem("Entity set 'HotelListingDbContext.Hotels'  is null.");
            //}
            //_context.Hotels.Add(hotel);
            //await _context.SaveChangesAsync();

            var hotel = mapper.Map<Hotel>(hotelDto);
            await hotelRepository.AddAsync(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            //if (_context.Hotels == null)
            //{
            //    return NotFound();
            //}
            var hotel = await hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            //_context.Hotels.Remove(hotel);
            //await _context.SaveChangesAsync();
            await hotelRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await hotelRepository.Exists(id);
        }
    }
}
