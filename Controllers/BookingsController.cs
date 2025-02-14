using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.API;
using HotelBooking.API.Models;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace HotelBooking.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(HotelDbContext context) : ControllerBase
{
    // GET: api/Bookings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookingsAsync()
    {
        return await context.Bookings.ToListAsync();
    }

    // GET: api/AvailableRooms
    [HttpGet("AvailableRooms")]
    public async Task<ActionResult<IEnumerable<Room>>> AvailableRoomsAsync(DateOnly startDate, DateOnly endDate,
        int minCapacity)
    {
        try
        {
            var availableRooms = await context.Rooms.Where(room =>
                room.Capacity >= minCapacity &&
                !context.Bookings.Any(booking =>
                    booking.RoomId == room.Id &&
                    DateOnly.FromDateTime(booking.Arrival) < endDate &&
                    DateOnly.FromDateTime(booking.Departure) > startDate)).ToListAsync();

            return Ok(availableRooms);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
        }
    }

    // GET: api/GetBooking/id
    [HttpGet("GetBooking")]
    public async Task<ActionResult<Booking>> GetBookingAsync(int id)
    {
        try
        {
            var booking = await context.Bookings.FirstOrDefaultAsync(e => e.Id == id);

            if (booking is null)
                return Conflict(new { message = "No booking exists for that id" });

            return Ok(booking);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
        }
    }


    // POST: api/AddBooking
    [HttpPost("AddBooking")]
    public async Task<ActionResult<Booking>> AddBookingAsync([FromBody] Booking newBooking)
    {
        try
        {
            // Get the list of available rooms
            var roomsAvailable = await context.Rooms.Where(room =>
                room.Capacity >= newBooking.NumberOfGuests &&
                !context.Bookings.Any(booking =>
                    booking.RoomId == room.Id &&
                    DateOnly.FromDateTime(booking.Arrival) < DateOnly.FromDateTime(newBooking.Departure) &&
                    DateOnly.FromDateTime(booking.Departure) > DateOnly.FromDateTime(newBooking.Arrival))).ToListAsync();

            // Check if the room is available
            if (roomsAvailable.All(x => x.Id != newBooking.RoomId))
            {
                return Conflict(new { message = "No available room for the specified dates." });
            }
            else
            {
                context.Bookings.Add(newBooking);
                await context.SaveChangesAsync();
                return Ok(newBooking);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
        }
    }

    // DELETE: api/Bookings
    [HttpDelete]
    public async Task<ActionResult<IEnumerable<Hotel>>> ResetDataAsync()
    {
        try
        {
            var sqlCommand = "DELETE FROM [HotelBookings].[dbo].[Bookings]";
            await context.Database.ExecuteSqlRawAsync(sqlCommand);
            return Ok(new { message = "SQL command executed successfully - all test data reset to default state" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error executing SQL query: {ex.Message}");
        }
    }

}

