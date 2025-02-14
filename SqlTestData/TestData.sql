--hotel_test_data.sql
DECLARE @hotel1Id INT, @hotel2Id INT, @hotel3Id INT

INSERT INTO [HotelBookings].[dbo].[Hotels](name, address, postcode, web_address) VALUES ('Fawlty Towers', '1 Liverpool Road', 'BT170HY', 'www.google.com');

SET @hotel1Id = SCOPE_IDENTITY();

INSERT INTO [HotelBookings].[dbo].[Hotels] (name, address, postcode, web_address) VALUES ('Hotel California', '2 Vegas Road', 'EH76JL', 'www.microsoft.com');
SET @hotel2Id = SCOPE_IDENTITY();

INSERT INTO [HotelBookings].[dbo].[Hotels] (name, address, postcode, web_address) VALUES ('Jurassic Park Resort', '3 Pacific Avenue', 'EH76JL', 'www.apple.com');
SET @hotel3Id = SCOPE_IDENTITY();

INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel1Id, 2, 'Double');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel1Id, 1, 'Single');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel1Id, 2, 'Double');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel1Id, 1, 'Single');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel1Id, 4, 'Deluxe');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel1Id, 2, 'Double');

INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel2Id, 2, 'Double');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel2Id, 1, 'Single');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel2Id, 2, 'Double');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel2Id, 2, 'Double');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel2Id, 4, 'Deluxe');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel2Id, 2, 'Double');

INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel3Id, 2, 'Double');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel3Id, 1, 'Single');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel3Id, 2, 'Double');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel3Id, 2, 'Double');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel3Id, 4, 'Deluxe');
INSERT INTO [HotelBookings].[dbo].[Rooms] (hotel_id, capacity, room_type) VALUES (@hotel3Id, 6, 'Deluxe');






