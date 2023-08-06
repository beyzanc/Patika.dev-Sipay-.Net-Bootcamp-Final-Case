# ResiPay - Residential Payment System

## Prerequisites
Before proceeding, make sure you have the following installed on your machine:

- .NET SDK - version compatible with the project (recommended: .NET 5 or later)
- PostgreSQL - a relational database management system
- MongoDB - a NoSQL database (for the Card service)

## How to use

1. Clone the repository from GitHub.
2. Install the required NuGet packages by navigating to the project root directory (where the .csproj file is located) and running the following command:
   
   `dotnet restore` 
3. Make sure you have a **PostgreSQL** database server running. Update the connection string in the **appsettings.json** file located in the project root. Modify the "PostgreSqlConnection" value with your database credentials.
4. Ensure you have a **MongoDB** server running. The MongoDB connection string is already specified in the **launchsettings.json** file under the "ResiPay" profile. If needed, update the "CONNECTION_STRING" with your MongoDB server details.
5. To create the necessary database tables, run the following command:
   
   `dotnet ef database update`
6. Build and run project.

## Database Relationships

### Apartment - Bill (One-to-Many):

- An apartment can have multiple bills (One-to-Many relationship).
- The "Bill" entity has a foreign key "ApartmentId" that references the "Apartment" entity.
- Each bill is associated with a specific apartment.

### User - Apartment (Many-to-Many):

- A user can be associated with multiple apartments, and an apartment can have multiple users (Many-to-Many relationship).
- The "User" entity has a many-to-many relationship with the "Apartment" entity through a junction table named "UserApartments".
- The "UserApartments" table contains the foreign keys "UserId" and "ApartmentId" to link users and apartments.

### User - Bill (One-to-Many):

- A user can have multiple bills (One-to-Many relationship).
- The "Bill" entity has a foreign key "UserId" that references the "User" entity.
- Each bill is associated with a specific user.

### User - Card (One-to-Many):

- A user can have multiple cards (One-to-Many relationship).
- The "Card" entity has a foreign key "UserId" that references the "User" entity.
- Each card is associated with a specific user.

### User - Message (One-to-Many):

- A user can have multiple messages (One-to-Many relationship).
- The "Message" entity has a foreign key "UserId" that references the "User" entity.
- Each message is associated with a specific user as the sender.


## Entities


### User:

- Represents users registered in the ResiPay system.
- Stores user details such as name, surname, identity number, email, password, phone number, and car plate (optional).
- Associated with multiple apartments, bills, messages, and cards.
  
### Apartment:

- Represents apartments in the ResiPay system.
- Stores information about apartment blocks, floors, numbers, types, and occupancy status.
- Associated with multiple users and bills.

### Bill:

- Represents bills to be paid by users for their apartments.
- Contains details such as apartment and user IDs, bill type, amount, due date, and payment status.
- Associated with a specific apartment and user.

### Card:

- A MongoDB entity that stores card details for users who wish to use cards for payments.
- Contains card number, CVC, expiration date, and price.
- Associated with a user.
  
### Message:

- Represents messages exchanged between users in the ResiPay application.
- Stores information about the subject, content, sender, receiver, read status, and deletion status.
- Associated with a user as both sender and receiver.

## Process of Password Hashing 

1. During user registration, the provided password is subjected to the Hasher.GetHash() method.

2. The GetHash() method utilizes **SHA-256** to create a cryptographic hash of the password.

3. The resulting hash is represented as a hexadecimal string, ensuring it remains secure and irreversible.

4. The hashed password is stored in the database for later verification during login.

## Sending Mail

The ResiPay application uses the **"MailJobService"** to send payment reminders to users with outstanding bills. This service utilizes **MailKit** and **MimeKit** libraries for efficient email communication. AutoMapper is also employed to map unpaid bill data to personalized email content. Payment reminders are sent to users' registered email addresses, facilitating timely bill payments and improving overall application efficiency.


## Token Service

The ResiPay application includes a "TokenService" responsible for generating and validating JSON Web Tokens (JWT). However, due to time constraints, this service is currently not actively utilized in the project.

### Functionality:

**GenerateToken:** The "GenerateToken" method generates a JWT for a given user. It includes the user's ID as a claim and sets the token's expiration to 3 days from the current date.

**ValidateToken:** The "ValidateToken" method validates a provided JWT. It checks the token's signature, expiration, and issuer without validating the audience. If the token is valid, it extracts the user's ID from the token's claims.

### Not in Active Use:

*As of the current implementation, the token service is not actively utilized in the ResiPay project. It remains a part of the codebase and can be utilized for authentication and authorization purposes in future enhancements.*

## Fluent Validation

The ResiPay application includes FluentValidation classes to validate various models used in the system. These validation rules ensure that the data provided by users is consistent and valid.

The rules that validate regex expressions, some of which are special methods, are:

- **ApartmentType:** The BeValidApartmentType method is used to validate the ApartmentType field. It checks whether the value matches the pattern of "2+1", "3+0", or is simply "other". The custom method uses a regex expression to perform this validation.

- **BillType:** Must not be empty and should be one of the following valid values: "dues", "electric", "gas", "water", or "other".

- **IdentityNumber:** The BeValidIdentityNumber method checks the correctness of the IdentityNumber using a mathematical algorithm based on its digits. It verifies the check digits of the IdentityNumber to ensure its validity based on Republic of Turkey identification number rules.

- **PhoneNumber:** The regex expression used for PhoneNumber validation checks for various valid Turkish phone number formats. It allows formats like "0555 555 5555", "(0555)-555-5555", "0555-555-5555", and more.

- **CarPlate:** The regex expression used for CarPlate validation ensures that the provided car plate number follows the standard Turkish car plate format with two letters, followed by one to three capital letters, and ending with two to four digits.


## Built With

- ASP.NET Core 6.0 as Web Framework
- PostgreSQL for Database
- MongoDB for Card Service
- Entity Framework Core for Data Access
- AutoMapper for Object-Relational Mapping
- Swagger for API Documentation
- Fluent Validation for Data Validation
- MailKit & MimeLit Libraries for sending mail
- JSON Web Tokens (JWT) for Authentication
- Visual Studio Code for IDE
