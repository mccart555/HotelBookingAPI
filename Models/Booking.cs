using System.ComponentModel.DataAnnotations;

namespace HotelBooking.API.Models;
public record Booking(
    [Required] int Id,
    [Required] int RoomId,
    [Required] string Title,
    [Required] string FirstName,
    [Required] string Surname,
    [Required] string EmailAddress,
    string PhoneNumber,
    bool Paid,
    [Required] DateTime Arrival,
    [Required] DateTime Departure,
    [Required] int NumberOfGuests,
    bool Breakfast
);

