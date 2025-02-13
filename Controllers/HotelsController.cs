using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.API;
using HotelBooking.API.Models;
using Microsoft.Data.SqlClient;

namespace HotelBooking.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController(HotelDbContext context) : ControllerBase
{
    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
    {
        try
        {
            return Ok(await context.Hotel.ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
        }
    }

    // GET: api/SearchHotel/searchString
    [HttpGet("SearchHotel")]
    public async Task<ActionResult<IEnumerable<Hotel>>> SearchHotel(string searchString)
    {
        try
        {
            return Ok(await context.Hotel
                .Where(e => e.Name.Contains(searchString)).ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
        }
    }

    [HttpGet("ResetData")]
    public async Task<ActionResult<IEnumerable<Hotel>>> ResetData()
    {
        try
        {
            var sqlCommand = "DELETE FROM [Hotels].[dbo].[Booking]";
            await context.Database.ExecuteSqlRawAsync(sqlCommand);
            return Ok(new { message = "SQL command executed successfully - all test data reset to default state" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error executing SQL query: {ex.Message}");
        }
    }
}

