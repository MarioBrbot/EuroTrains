# EuroTrains - General
Reserve tickets for European trains

Technologies used: .NET, C#, ASP.NET, SQL Server, Angular, Typescript, HTML, CSS

This is a practice application that has the functionality of reserving tickets for European trains. Fontend is built using Angluar 14 and the backend is developed with .NET 6. If you want to run the app locally please first deploy the SQL database with all the necessary tables, you can find it in ~\EuroTrains\Data\eurotrains_backup.sql .


# Main Page - Search For Trains

Navbar consists of application and module names. It also displays the name of the logged in passenger.

![image](https://github.com/MarioBrbot/EuroTrains/assets/150728108/8f58c067-2640-47f8-a21a-69ec70f188f5)

On the main page we can search and filter trains, just as shown in the image bellow. We can choose to book a train.

![image](https://github.com/MarioBrbot/EuroTrains/assets/150728108/424979b1-894c-48e9-b238-a5b180dbc39e)

# Login And Booking

After we click the "Book" we are redirected to the login screen if no user is already logged in. After that are shown the booking page where we can book our train. Input is validated and covered for concurrency conflicts.

![image](https://github.com/MarioBrbot/EuroTrains/assets/150728108/69186145-4779-474a-8ef0-d20cbbe5d1a5)

# Switch Passenger and My Bookings

We can always choose to switch passenger which takes us to the new login screen. We can also see our current bookings on the "My Bookings" tab as shown below.

![image](https://github.com/MarioBrbot/EuroTrains/assets/150728108/264cc63c-3d75-4f20-ac56-4671a0addef3)
