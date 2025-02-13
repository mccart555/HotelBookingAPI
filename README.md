# HotelBooking.API

This solution has been created in a way that you can run everything locally providing you have Docker desktop installed and running.

# Installation instructions for local debug

Step 1 - Ensure Docker Desktop is running.

Step 2 - While holding the Windows Key, press the x key, release both keys and press i to open a PowerShell window.

Step 3 - Run the following command in the PowerShell window to pull an up to date SQL Server image to your local Docker
         
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
  
         dotnet ef database update 

***OR*** if you don't have the .NET core CLI installed you can do this in the Visual Studio Package Manager Console: 

         Update-Database

Step 7 - Open Sql Server Management Studio (use the sa account and the password WaracleRocks! to connect.) In the Hotels database (created by 
         the previous step) run the following SQL script:
  
         SqlTestData\TestData.sql

Step 8 - I don't have an Azure account since Microsoft tried to charge me for using it, so either: 
         
Run the project using Visual Studio - select http or https from the dropdown and run with Visual Studio web server.
  
***OR*** Right Click on the Docker file in Visual Studio and Select Build Docker image, once complete restart visual studio and then select 
Container (Docker File) in the drop down in Visual Studio and run as a container.
   
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

With regards to using the SA Account for SQL Server - bad I know, but I thought it would be ok for this test to keep it simple.
