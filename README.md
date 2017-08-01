[![Build Status](https://www.myget.org/BuildSource/Badge/ribbles?identifier=5ce5511b-c4a4-4be0-b4e9-910d7e3df36b)](https://www.myget.org/feed/ribbles/package/nuget/RecurringInterval)

# RecurringInterval
C# Library for representing and managing recurring intervals, suitable for calendaring functions.

## Supported Intervals

* [Daily](#daily) (+days)
* [Weekly](#weekly) (+dayOfWeek)
* [BiWeekly / Fortnightly](#bi-weekly--fortnighly)
* [BiMonthly](#bi-monthly) (+dayOfMonth)
* [Monthly](#monthly) (+dayOfMonth)
* [Quarterly](#quarterly) (+dayOfQuarter)
* [Annually](#annually) (+dayOfYear)
* [FourFourFour] (#four-four-four) (+dayOfPeriod)
* [FourFourFive](#four-four-five) (+dayOfPeriod)

## Installation

### NuGet Package Manager Console

Run the following command in the NuGet Package Manager console to install the library:

````
PM> Install-Package RecurringInterval
````

For more information, visit the [Nuget RecurringInterval repository](https://www.nuget.org/packages/RecurringInterval/)

## Usage

```csharp
var interval = Interval.Create(<Period>, <Date>, <Integer End Day>);
var nextInterval = interval.Next();
```

## Daily 

```csharp
Interval.Create(Period.Daily, <start date>, <days>);
```

The date argument is always the start date. The interger argument is how many days in the interval.

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

```csharp
Interval.Create(Period.Weekly, <start date>, <day of week to end on>);
```

The interger is the day of the week to end on, can can be cast from the `System.DayOfWeek` enum. The date argument is *any* date between the end date and the start date. 

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

## Bi-Weekly / Fortnighly

```csharp
Interval.Create(Period.Daily, <start date>, <ignored>);
```

The date argument is always the start date. The interger argument is ignored.

## Bi-Monthly

```csharp
Interval.Create(Period.BiMonthly, <start date>, <end day of month>);
```

This is the most complex, and follows the following conventions for the integer argument end date:

For periods ending on:
* 1st and 16th of each month: use 1 or 16
* 2nd and 17th of month: use 2 or 17
* 3rd and 18th of month: use 3 or 18
* 4th and 19th of month: use 4 or 19
* 5th and 20th of month: use 5 or 20
* 6th and 21st of month: use 6 or 21
* 7th and 22nd of month: use 7 or 22
* 8th and 23rd of month: use 8 or 23
* 9th and 34th of month: use 9 or 24
* 10th and 25th of month: use 10 or 25
* 11th and 26th of month: use 11 or 26
* 12th and 27th of month: use 12 or 27
* 13th and last day of month: use 13
* 14th and last day of month: use 14
* 15th and last day of month: use -1, 15 or 28+

## Monthly

```csharp
Interval.Create(Period.Monthly, <start date>, <day of month to end on>);
```

## Quarterly

```csharp
Interval.Create(Period.Quarterly, <start date>, <day of quarter to end on>);
```

## Annually

```csharp
Interval.Create(Period.Annual, <start date>, <day of year to end on>);


## Four-Four-Four
See https://en.wikipedia.org/wiki/4%E2%80%934%E2%80%935_calendar for a definition.

```csharp
Interval.Create(Period.FourFourFour, <start date>, <ignored>);


## Four-Four-Five
See https://en.wikipedia.org/wiki/4%E2%80%934%E2%80%935_calendar for a definition.

```csharp
Interval.Create(Period.FourFourFive, <start date>, <ignored>);
