# Skills International — Student Registration System

A C# Windows Forms application developed by **Maleesha Dewmina Perera** as the final project for the Diploma in Information Technology.

## Overview

The application manages student registration records through a desktop interface backed by Microsoft SQL Server. It demonstrates event-driven programming, Windows Forms controls, database access with ADO.NET, and CRUD operations.

## Implemented features

- Login form with show/hide password and clear controls.
- Student registration with duplicate registration-number checking.
- Retrieval and editing of existing registration records.
- Record deletion with confirmation.
- A table view of students and search by registration number.
- Student details including name, date of birth, gender and contact information, plus parent/guardian details.
- Navigation between login, registration and record-view forms.

## Technology

| Component | Technology |
| --- | --- |
| Language | C# |
| Desktop UI | Windows Forms |
| Framework | .NET Framework 4.7.2 |
| Database | Microsoft SQL Server / SQL Server Express |
| Database access | ADO.NET, SqlClient and a typed DataSet/TableAdapter |
| IDE | Microsoft Visual Studio |

## Run locally

1. On Windows, install Visual Studio with the **.NET desktop development** workload and the .NET Framework 4.7.2 targeting pack.
2. Install SQL Server or SQL Server Express and SQL Server Management Studio.
3. Run `database/setup.sql` in SSMS. It creates the database and empty tables if they do not already exist. The script reconstructs the registration schema from the supplied XSD and infers the login table from the source; it is not an original database backup.
4. The repository defaults to `localhost\SQLEXPRESS` with Windows authentication. If your server differs, update the connection strings in `Login.cs`, `Registration.cs`, `View.cs`, `App.config`, `Properties/Settings.settings`, and the generated settings default in `Properties/Settings.Designer.cs`. The DataSet XSD also carries design-time connection metadata.
5. Add a throwaway login account to `dbo.Logins` using SSMS. No account or real student data is included. Use only fictitious student records for demonstration.
6. Open `Skills International DiIT.sln`, build the solution, and run it.

## Project organisation

- `Skills International DiIT.sln` — Visual Studio solution.
- `Skills International DiIT/` — application, forms, resources, settings and typed DataSet.
- `database/setup.sql` — reconstructed empty database setup.

## Academic scope and limitations

This repository preserves an early academic implementation. The login compares plaintext passwords, and some queries concatenate input. Phone numbers are stored as integers, and some validation and connection-cleanup paths need improvement. It should be treated as a local learning demonstration, not a production student-information system.

Future improvements include password hashing, consistently parameterised SQL, shared configuration, reliable connection disposal, stronger validation, and storing telephone numbers as text.

## Repository preparation

Visual Studio caches and compiled output were excluded. Machine-specific SQL Server names were replaced with a local SQL Express default. Documentation and the reconstructed setup script were added; application features were not rewritten.

## Validation

Project references and XML files were inspected statically. The application and SQL setup have not been run in the preparation environment; a Windows/SQL Server smoke test remains necessary.
