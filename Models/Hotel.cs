using System.ComponentModel.DataAnnotations;

namespace HotelBooking.API.Models;
public record Hotel( 
    [Required] int Id,
    [Required] string Name,
    [Required] string Address,
    [Required] string Postcode,
    string WebAddress
);

