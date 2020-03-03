REM To create the initial migration scripts that will be used by dotnet ef migration
dotnet ef migrations add InitialUpdate
REM to update these migrations to Table
dotnet ef database update