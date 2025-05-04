### Getting start

```sh
dotnet new console -o MyProj

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install --global dotnet-ef

dotnet ef migrations add INIT

dotnet ef database update
```

https://www.infoworld.com/article/2336631/avoid-using-enums-in-the-domain-layer-in-c-sharp.html
