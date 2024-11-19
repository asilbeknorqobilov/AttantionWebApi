### 1.NET Loyihasini Yaratish
* Visual Studio yoki Visual Studio Code orqali yangi .NET loyihasi yarating. Buning uchun:

```
dotnet new console -o MyApp
cd MyApp
```
* Entity Framework CLI vositasini loyihangizga qo'shish uchun `dotnet-ef` paketini global o'rnatishingiz kerak. Buning uchun terminal yoki buyruqlar qatorida quyidagi buyruqni bajaring:

```
dotnet tool install --global dotnet-ef
```

* Entity Framework Core va PostgreSQL uchun Npgsql.EntityFrameworkCore.PostgreSQL paketini o'rnating:

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

* Agar global o'rnatishda muammo yuzaga kelsa, loyihaga lokal ravishda Microsoft.EntityFrameworkCore.Design paketini qo'shishga harakat qiling:

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

* Yangi model qo'shilganda yoki Modelda o'zgarish bo'lganda `migrations` yordamida o'zgarishni database ga tadbiq qilish mumkin:

```
dotnet ef migrations add YangilanishIzohi

dotnet ef database update
```