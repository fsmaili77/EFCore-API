# EFCore-API
## API calls in Asp.Net Core project with Entity Framework Core and SQL Server

To create a new project using **EF Core** with **SQL Server**, you'll need to follow these steps:

**1.   Create a _new_ ASP.NET Core** project:

You can create a new ASP.NET Core project using the **dotnet new** command or through Visual Studio. Make sure you select the appropriate project template (e.g., ASP.NET Core Web API) based on your requirements.

**2.	Install Entity Framework Core** packages :

You'll need to install **Entity Framework Core** and the **SQL Server** provider packages.

**3.	Create an Entity Framework _DbContext_:**

In your project, create a new class that inherits from **DbContext**. This class will represent your database context and define the **DbSet** for the **Produit** entity:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/8c61647e-da88-4638-9fc5-707ab34f2cb7)



**4.	Configure the Database Connection:**

In the **Startup.cs** or **Program.cs** file, you need to configure the database connection in the **ConfigureServices** method of Startup.cs class or in the Program.cs class as shown in the code below. You'll typically read the connection string from your app's configuration:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/d79c68da-a0a9-4a1e-a4ff-dec9452b3dab)

**5.	Make sure you have a connection string named "DefaultConnection"** defined in your app's configuration (usually in **appsettings.json** or environment-specific JSON files).

Replace __"Server=YourServerName;Database=YourDatabaseName;User=YourUserName;Password=YourPassword;"__ with your actual SQL Server connection string.
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/e2df7a41-8722-4dc7-94c8-397a37b7c91b)


**6.	Configure the application to use the connection string**:
In your **Program.cs** file, you can configure your application to use the connection string from **appsettings.json**. Here's how you can do it:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/b1e4abd9-64b1-4272-b6a6-80638714d72a)

In this code, **builder.Configuration.GetConnectionString("DefaultConnection")** retrieves the connection string named **"DefaultConnection"** from your **appsettings.json** file. 

With these changes, your ASP.NET Core application will now use the connection string specified in the **appsettings.json** file for your **AppDbContext**. Make sure to replace the placeholder connection string with your actual SQL Server connection string.

**7.	Create Database Migrations**:
Entity Framework Core uses migrations to create and update the database schema based on your model. Run the following command in the terminal to create an initial migration:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/639dd4ab-ea9d-4d48-9170-e9376dd55a63)


This command will generate a migration file in your project.
To add a migration using Visual Studio for an Entity Framework Core project, follow these steps:
**•	Open Your Project in Visual Studio:**
Open your Entity Framework Core project in Visual Studio.
**•	Open the Package Manager Console:**
Go to View -> Other Windows -> Package Manager Console in Visual Studio.
**•	Set Default Project:**
In the Package Manager Console, set the default project to your Entity Framework Core project. Use the cd command to navigate to your project directory, and then run the following command:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/2c2773e6-54c7-492c-9d5d-40eef2444cf9)


**8.	Apply Migrations:**
Run the following command to apply the migration and create the database:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/26a9bad9-af59-4bf2-86f1-a99f9d92a52d)


**9.	Create Controller to Use EF Core**:

Create ProduitsController to use EF Core for data access. Here's an example of code:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/d139cd0f-af00-40a1-b698-6b2e6ec3a731)


### Seed data from JSON file in EF Core

**1.	Create a SeedData class**:
First, create a class that will contain your seed data logic. This class should be responsible for reading the JSON file and inserting the data into the database. For example:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/16449808-f908-4fc7-8e99-90fab1ee7255)

 
Replace **YourEntity** with the name of your entity class.

**2.	Call the SeedData.Initialize method**:
In your **Startup.cs** or **Program.cs**file or wherever you configure your database context, call the **SeedData.Initialize** method to seed the data during database initialization. 
You should call the **SeedData.Initialize** method after building your **WebHost** in your **Program.cs** file. Specifically, you should call it after the **builder.Build()** line. Here's how you can modify your **Program.cs** to include the seeding:
![image](https://github.com/fsmaili77/EFCore-API/assets/65200251/26264ca8-ee89-49dc-bb86-326369ed40ac)
 
In this code, we create a scope using app.Services.CreateScope(), which allows us to access services registered in the dependency injection container, including your AppDbContext. Within this scope, we retrieve an instance of AppDbContext, and then we call SeedData.Initialize to seed the database.

**3.	Ensure Data Seed Configuration**:
If you are using data seeding (as mentioned earlier in the conversation), ensure that you are not trying to insert explicit values for the 'Id' column during seeding. The 'Id' column should be generated by the database.

**4.	Generate and Apply Migration**:
After making the necessary changes, generate a new migration using the dotnet ef migrations add command. This will create a migration script that reflects the changes you made to the database schema and DbContext configuration.

**5.	Apply the Migration**:
Apply the generated migration to update the database schema using the dotnet ef database update command.






