# HotelBooking.API

This solution has been created in a way that you can run everything locally providing you have Docker desktop installed and running.

# Installation instructions for local debug

Step 1 - Ensure Docker Desktop is running.

Step 2 - While holding the Windows Key, press the x key, release both keys and press i to open a powershell window.

Step 3 - Run the following command in the powershell window to pull an up to date SQL Server image to your local Docker
  docker pull mcr.microsoft.com/mssql/server:2022-latest

Step 4 - Run the following command for Docker to launch a Sql Server container (using the pulled image from the previous step)
  docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=WaracleRocks!" -p 1433:1433 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest

Step 5 - Create a Secrets File (Right click on the project and select "Manage User Secrets" with the following:
{
  "ConnectionStrings": {
    "SqlServer": "Server=localhost,1433;Database=Hotels;User Id=sa;Password=WaracleRocks!;TrustServerCertificate=True;"
  }
}

Step 6 - Run the following command in a command window (while in the HotelBooking.API project directory)
  dotnet ef migrations add InitialCreate 
Or if you don't have the .NET core CLI installed you can do this in a PowerShell window (while in the HotelBooking.API project directory) or 
the Visual Studio Package Manager Console
  Add-Migration InitialCreate

Step 7 - Run the following command in a command window (while in the HotelBooking.API project directory)
  dotnet ef database update 
Or if you don't have the .NET core CLI installed you can do this in a PowerShell window (while in the HotelBooking.API project directory) or 
the Visual Studio Package Manager Console
  Update-Database

Step 8 - Open Sql Server Management Studio and run the following SQL script found in the project SQLTestData folder into the Hotels database
using the sa account and the WaracleRocks! password:
  TestData.sql

Step 9 - Run the project using Visual Studio.

#For post operation on swagger use this - the other endpoints are fairly easy to get working.
{
  "RoomId": 11,
  "Title": "Mr",
  "FirstName": "Conor",
  "Surname": "McCartney",
  "EmailAddress": "mccart",
  "PhoneNumber": "123",
  "Paid": true,
  "Arrival": "2025-04-13T16:52:50.130Z",
  "Departure": "2025-04-15T16:52:50.130Z",
  "NumberOfGuests": 2,
  "Breakfast": true
}

All EFCore SQL goes to console for debugging and optimisation.
