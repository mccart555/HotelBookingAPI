using System.ComponentModel.DataAnnotations;

namespace HotelBooking.API.Models;
public record Room(
    [Required] int Id,
    [Required] int HotelId,
    [Required] int Capacity,
    [Required] string RoomType
);
