migration important command
1) add migration 
dotnet ef migrations add InitialMigration --project "DLL" --startup-project "API"
2) update database command 
dotnet ef database update --project "DLL" --startup-project "API"

my project analysis link :
https://docs.google.com/presentation/d/1Cy_JnwOzgyoUs9y2FaulXkwL-Erw8Dkl9NbHLa87xcs/edit#slide=id.g6bd60703db_0_346