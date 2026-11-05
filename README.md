# Skills International Student Registration

A Windows Forms application for registering students, searching by registration number and maintaining student records.

Built as the final project for the Diploma in Information Technology, the application connects C# forms to SQL Server through ADO.NET and a typed DataSet. The registration workflow includes duplicate-number checks, record editing and deletion confirmation.

**Technologies**  
C# · Windows Forms · ADO.NET · SQL Server

## Run locally

On Windows, open `Skills International DiIT.sln` in Visual Studio with the .NET desktop workload and .NET Framework 4.7.2 targeting pack. Run `database/setup.sql` on a local SQL Server Express instance to create the reconstructed schema. The application defaults to `localhost\SQLEXPRESS` with Windows authentication. If needed, update the connection in the forms, application configuration and typed DataSet settings. Create a throwaway login in `dbo.Logins`, then build and run with fictional student records.

## Author

Maleesha Dewmina Perera
