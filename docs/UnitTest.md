# UnitTest

![Test](https://raw.githubusercontent.com/SaladbowlCreative/Json.Net.Unity3D/master/docs/UnitTestResult.png)

## Failed tests

- Newtonsoft.Json.Tests.Converters.IsoDateTimeConverterTests
  - SerializeFormattedDateTimeNewZealandCulture
- Newtonsoft.Json.Tests.JsonConvertTest
  - WriteDateTime
- Newtonsoft.Json.Tests.JsonTextReaderTest
  - ReadAsDateTimeOffsetIsoDate
- Newtonsoft.Json.Tests.Linq.JTokenReaderTest
  - ReadAsDateTimeOffset_String
  - ReadAsDateTimeOffsetString
- Newtonsoft.Json.Tests.Serialization.JsonSerializerTest
  - DateFormatStringWithDateTimeOffset
  - DateFormatStringWithDictionaryKey_DateTimeOffset
  - DateFormatStringWithDictionaryKey_DateTimeOffset_ReadAhead
  - DateTimeDictionaryKey_DateTime_Iso
  - DateTimeDictionaryKey_DateTime_Iso_Local
  - DateTimeDictionaryKey_DateTimeOffset_Iso
- Newtonsoft.Json.Tests.Utilities.DateTimeUtilsTests
  - NewDateTimeOffsetParse
  - NewDateTimeParse

## Why did tests fail?

Most of them failed because DateTime and DateTimeOffset in Unity3D-Mono
cannot handle UTC formatted string well. (postfix Z or +09:00, fraction part of ISO time.)

For example, ReadAsDateTimeOffsetIsoDate failed with this message because
DateTimeOffset didn't get UTC timezone in parsing "2011-08-01T21:25Z".

```
Expected: 08/01/2011 21:25:00 +00:00
  But was:  08/01/2011 21:25:00 +09:00
```

SerializeFormattedDateTimeNewZealandCulture failed because DateTime in Unity3D-Mono
generated different date-time string from .NET one.

```
Expected string length 40 but was 32. Strings differ at index 1.
  Expected: ""Friday, 15 December 2000 10:11:03 p.m.""
  But was:  ""15 December 2000 10:11:03 p.m.""
  ------------^
```

DateFormatStringWithDateTimeOffset failed because DateTimeOffset in Unity3D-Mono
cannot parse user-defined time format well such as "yyyy'-pie-'MMM'-'dddd'-'dd".

```
Newtonsoft.Json.JsonReaderException : Could not convert string to DateTimeOffset:
  2000-pie-Dec-Friday-22. Path '', line 1, position 24.
```
