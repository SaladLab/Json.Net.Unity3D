# UnitTest

![Test](https://raw.githubusercontent.com/SaladbowlCreative/Json.Net.Unity3D/master/docs/UnitTestResult.png)

## What failed

### DateTimeFormat with CultureInfo doesn't cover all locale

##### ReadAsDateTimeOffsetIsoDate

```
Expected: 08/01/2011 21:25:00 +00:00
  But was:  08/01/2011 21:25:00 +09:00
```

### DateTimeOffset cannot parse formatted string well

##### SerializeFormattedDateTimeNewZealandCulture

```
Expected string length 40 but was 32. Strings differ at index 1.
  Expected: ""Friday, 15 December 2000 10:11:03 p.m.""
  But was:  ""15 December 2000 10:11:03 p.m.""
  ------------^
```

##### DateFormatStringWithDateTimeOffset

```
Newtonsoft.Json.JsonReaderException : Could not convert string to DateTimeOffset:
  2000-pie-Dec-Friday-22. Path '', line 1, position 24.
```
