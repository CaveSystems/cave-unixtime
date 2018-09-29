# cave-unixtime

Cave.UnixTime is a .NET DateTime compatible implementation of the unix time_t32 and time_t64 structures and can be used within marshaled structs for interop.

## Package

A package is available at [**nuget.org**](https://www.nuget.org/packages/Cave.UnixTime)

## Master

The primary repo for the project is on [GitHub](https://github.com/Dingsd4/cave-unixtime) and this is where the [wiki](https://github.com/Dingsd4/cave-unixtime/wiki) and [issues](https://github.com/Dingsd4/cave-unixtime/issues) are managed from.

## Licence

All original software is licensed under the [LGPL-3 Licence](https://github.com/Dingsd4/cave-unixtime/blob/master/LICENSE). This does not apply to any other 3rd party tools, utilities or code which may be used to develop this application.

If anyone is aware of any licence violations that this code may be making please inform the developers so that the issue can be investigated and rectified.

## Building

You will need:

1. Visual Studio VS2017 (Community Edition) or later
2. Target Framework packs:
    * netstandard1.0
    * netstandard1.3
    * netstandard2.0
    * netcoreapp1.0
    * netcoreapp2.0
    * net20
    * net35
    * net40
    * net45
    * net46
    * net47

## First use

You can use ``UnixTime32`` at most places you are currently using DateTime and can convert one to another.
``UnixTime64`` implements the same properties, operators and functions ``UnixTime32`` does.

```csharp
var unixTime32 = UnixTime32.Now;
DateTime dateTime = unixTime32.DateTime;
//29. Sept. 2018 - 16:35
unixTime32 = 1538231700;
//add 10 seconds
unixTime32 += 10;
//add a timespan
unixTime32 += TimeSpan.FromSeconds(10);
```

To use in an interop struct simply define the field. It will be marshaled as ```uint``` (``UnixTime32``) or ```long``` (``UnixTime64``).
