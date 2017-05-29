[![Build Status](https://www.myget.org/BuildSource/Badge/ribbles?identifier=5ce5511b-c4a4-4be0-b4e9-910d7e3df36b)](https://www.myget.org/feed/ribbles/package/nuget/RecurringInterval)

# RecurringInterval
C# Library for representing and managing recurring intervals, suitable for calendaring functions.

## Supported Intervals

* Daily (+days)
* Weekly (+dayOfWeek)
* BiWeekly / Fortnightly
* BiMonthly (+dayOfMonth)
* Monthly (+dayOfMonth)
* Quarterly (+dayOfQuarter)
* Annual - TODO
* [FourFourFour](https://en.wikipedia.org/wiki/4%E2%80%934%E2%80%935_calendar) - TODO
* [FourFourFive](https://en.wikipedia.org/wiki/4%E2%80%934%E2%80%935_calendar) - TODO

## Installation

### NuGet Package Manager Console

Run the following command in the NuGet Package Manager console to install the library:

````
PM> Install-Package RecurringInterval
````

## Usage

```csharp
var interval = Interval.Create(<Period>, <Date>, integer);
var nextInterval = interval.Next();
```

## Daily 

The date argument is always the start date. The interger is how many days in the interval.

```csharp
var interval = Interval.Create(Period.Daily, new DateTime(2017,1,1), 2); //Interval has 2 days
Assert.AreEqual(1, interval.StartDate.Day);
Assert.AreEqual(2, interval.EndDate.Day);
Assert.AreEqual(2, interval.TotalDays);

var next = interval.Next();
Assert.AreEqual(3, next.StartDate.Day);
Assert.AreEqual(4, next.EndDate.Day);
Assert.AreEqual(2, next.TotalDays);
```

## Weekly 

The interger is the end day of the week, can can be cast from the `System.DayOfWeek` enum. The date argument is *any* date between the end date and the start date. 

```csharp
var interval = Interval.Create(Period.Daily, new DateTime(2017, 5, 2), (int)DayOfWeek.Monday /* 2 */);
Assert.AreEqual(new DateTime(2017, 5, 2) interval.StartDate);
Assert.AreEqual(new DateTime(2017, 5, 8), interval.EndDate);
Assert.AreEqual(7, interval.TotalDays);

var next = interval.Next();
Assert.AreEqual(new DateTime(2017, 5, 9) next.StartDate);
Assert.AreEqual(new DateTime(2017, 5, 15), next.EndDate);
Assert.AreEqual(7, next.TotalDays);
```
