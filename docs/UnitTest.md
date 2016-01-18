# UnitTest

![Test](https://raw.githubusercontent.com/SaladbowlCreative/Json.Net.Unity3D/master/docs/UnitTestResult.png)

## What failed

### DateTimeFormat with CultureInfo doesn't cover all locale

##### ReadAsDateTimeOffsetIsoDate

```
Expected: 08/01/2011 21:25:00 +00:00
  But was:  08/01/2011 21:25:00 +09:00
---
at Newtonsoft.Json.Tests.JsonTextReaderTest.ReadAsDateTimeOffsetIsoDate () [0x00085] in .\src\Newtonsoft.Json.Tests\JsonTextReaderTest.cs:2354
```

### DateTimeOffset cannot parse formatted string well

##### SerializeFormattedDateTimeNewZealandCulture

```
Expected string length 40 but was 32. Strings differ at index 1.
  Expected: ""Friday, 15 December 2000 10:11:03 p.m.""
  But was:  ""15 December 2000 10:11:03 p.m.""
  ------------^
---
at Newtonsoft.Json.Tests.Converters.IsoDateTimeConverterTests.SerializeFormattedDateTimeNewZealandCulture () [0x00070] in .\src\Newtonsoft.Json.Tests\Converters\IsoDateTimeConverterTests.cs:143
```

##### DateFormatStringWithDateTimeOffset

```
Newtonsoft.Json.JsonReaderException : Could not convert string to DateTimeOffset: 2000-pie-Dec-Friday-22. Path '', line 1, position 24.
---
at Newtonsoft.Json.JsonReader.ReadDateTimeOffsetString (System.String s) [0x0007d] in .\src\Newtonsoft.Json\JsonReader.cs:875
at Newtonsoft.Json.JsonTextReader.ReadStringValue (ReadType readType) [0x001c7] in .\src\Newtonsoft.Json\JsonTextReader.cs:595
at Newtonsoft.Json.JsonTextReader.ReadAsDateTimeOffset () [0x00000] in .\src\Newtonsoft.Json\JsonTextReader.cs:929
at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.ReadForType (Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Serialization.JsonContract contract, Boolean hasConverter) [0x00089] in .\src\Newtonsoft.Json\Serialization\JsonSerializerInternalReader.cs:2250
at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.Deserialize (Newtonsoft.Json.JsonReader reader, System.Type objectType, Boolean checkAdditionalContent) [0x00021] in .\src\Newtonsoft.Json\Serialization\JsonSerializerInternalReader.cs:149
```
