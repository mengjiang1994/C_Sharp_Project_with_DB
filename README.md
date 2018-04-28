git push origin master
# .NET framework (Web API & Database)

## 1.Create a new project, the type is ASP.NET Core Web API


## 2. import library: go to Dependecies -> NuGet -> Right Click: Add Packages
	add: MySql.Data      &     MySql.Data.EntityFrameworkCore

## 3. Create a new folder : Model

## 4. in the "Model" folder, create 2 empty files: student.cs and course.cs
	The structure of Course.cs and Student.cs is very similarity
	Please remember the sturcture should like that
		public int Id { get; set; }
        public string Name { get; set; }

## 5. In the model folder create new empty file called LMSDbContext.cs
//Ths file basic create the link between API with database
	using Microsoft.EntityFrameworkCore;
	public class LMSDbContext: DbContext
	DbContext is a class from Microsoft.EntityFrameworkCore

	please create a new db at MySQL before creating the OnConfiguring funciton

## 6. In the Model folder, create a new empty file called ILMSDataStore.cs
// It is the interface of LMSDataStore, we will create it later.

## 7. In the Model folder, create LMSDataSotre.cs, import Linq and EntityFrameworkCore
//in this file , import its interface which we create at step 6 and right click the interface name
//to quick fix the interface

## 8. in LMSDataStore.cs， implement all methods.

## 9. Go to startup.cs
	using EFDemo1.Model;

	in the ConfigureServices, input those 2 lines after AddMvc();
	services.AddDbContext<LMSDbContext>();
	services.AddScoped<ILMSDataStore, LMSDataStore>();

## 10. go to the Controllers folder, delete the original file ,createa new file called StudentControllers.cs
//Or you can change the file name of original file directly.
change the Ruote to [Route("api/student")]
create the ILMSDataStore private variable _dbstore;
also, create CourseController.cs then do the Put, Post, Get, delete

//Properties -> launchSetting.json可能需要我改一下？

## 11. run below thing in MySQL to create EFMigrationsHistory.
```sql
 CREATE TABLE `__EFMigrationsHistory` ( `MigrationId` nvarchar(150) NOT NULL, `ProductVersion` nvarchar(32) NOT NULL, PRIMARY KEY (`MigrationId`) );
```

## 12. Build and  it
 terminal, go to the project directory (The folder which holding *.csproj )
### step1. run
```bash
dotnet ef -h
```

if error, Don't forget put below xml line into *.csproj
//you can add it via vscode or other text editor
```xml
<ItemGroup>
	<DoNetCliTooReferece Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
</ItemGroup>
```

### step2. run
```bash
dotnet restore
```

### step3. run 
```bash
dotnet ef -h
```

you will see dotnet ef [command] --help     if everything is ok

### step4. run:
```bash
dotnet ef migrations add Init
```

The it will shows Done

### step5. Run
```bash
dotnet ef database -h
```

### step6. run
```bash
dotnet ef database update
```
//After built successfully ,you can modify it with postman










