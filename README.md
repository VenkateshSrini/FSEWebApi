# Web Api for POPS system
  **Technology used**
  1) Asp.NEt core web API 3.1
  2) EF core
  3) Postgressql 12.x
  4) Swagger Open API using SwashBuckle.
  
  **Execuction instruction**
  1) Navigate to the directory that contains the *.csproj* file which will typically be the src diretcory.
  2) Switch on the postgresssql and update the connection string in appSetting.json
  3) run dotnet ef database update. The same command is available verbatin in the command file in the solution.
  4) from the SQL file create the 3 sequences in the end of command file in Postgressql.
  5) Launch the application and navigate to */swagger* end point in any browser other than IE.
  
