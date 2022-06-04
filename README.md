# GradeBook

This repository is for learning C# syntax and dotnet core runtime

## .NET

```mermaid
graph TD
大內[.NET]-->Framework[.NET Framework]
大內[.NET]-->Core[.NET Core]
Framework-->|可運行|M$[Windows]
Core-->|可運行|M$[Windows]
Core-->|可運行|Linux[Linux]
Core-->|可運行|Mac[Mac]
```

## 開發所需要安裝

1. .NET sdk
2. .NET runtime

## 架構

.NET 執行環境

CLR(Common Language Runtime)
FCL(Framework Core Library)

https://app.pluralsight.com/library/courses/csharp-fundamentals-dev/table-of-contents

## dotnet run 所執行的內容

1. 透過 dotnet restore 透過 nuget 下載該專案所需的 library

2. 執行 dotnet build 建立專案執行的 binary 到 bin 會產生 dll file

3. 透過 dotnet runtime 去執行 dll 


## 專案 class Diagram

```mermaid
classDiagram
Program ..> Book: Dependency
class Program {
  Main(List<string> args)$
}
class Book {
  -List~double~grades
  -string name
  +Book(string name)
  +AddGrade(double grade)
  +ShowStatistics()
}
```
## 新增 UnitTest

### 1 建構 Test folder

```sh
cd test
mkdir GradeBook.Test
```

### 2 初始化 XUnit Project with dotnet cli

```sh
cd GradeBook.Test
dotnet new xunit
```

### 3 把要測試的專案 .csproj file 加入 reference

```sh
dotnet add reference $reference_csproj_path
```

### 4 撰寫 Test code

```csharp
using Xunit;
namespace GradeBook.Tests;

public class BookTests
{
  [Fact]
  public void TestStatistics()
  {
    // arrange
    var book = new Book("");
    book.AddGrade(89.1);
    book.AddGrade(90.5);
    book.AddGrade(77.3);
    // act
    var result = book.GetStatistics();
    // assert
    Assert.Equal(85.6, result.Average, 1);
    Assert.Equal(90.5, result.High, 1);
    Assert.Equal(77.3, result.Low, 1);
  }
}
```

## 建立 solution 檔案來管理多個專案檔

原本的案例中 

每次要執行對應的檔案必須跑到該檔案對應的資料夾才能執行 dotnet cli 指令

不是很方便的作法

而 .NET 專案一個管理多個專案的一個作法就是透過 solution 檔案來做這件事情

### 1. 建立 sln 檔案

```shell=
dotnet new sln
```

### 2. 加入 sln 所要管理的 .csproj 檔案

```shell=
dotnet sln add $csproj_path
```

for example

```shell=
dotnet sln add src/GradeBook/GradeBook.csproj
dotnet sln add test/GradeBook.Tests/GradeBook.Tests.csproj
```

現在就可以直接在 gradebook 資料夾下 dotnet cli 指令了