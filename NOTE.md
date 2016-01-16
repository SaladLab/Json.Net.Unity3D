# Note

## Assembly Size

Newtonsoft Json.NET 8.0.2
- NET45: Json.NET for .NET45
- NET35: Json.NET for .NET35
- Unity = NET35 with Unity support
- UnityLite = Unity - Json.Linq - Bson

|            | NET45   | NET35   | Unity   | UnityLite |
| :--------- | ------: | ------: | ------: | --------: |
| String     |  66,256 |  58,372 |  44,528 |    35,448 |
| Blob       |  44,116 |  34,628 |  25,268 |    19,668 |
| UserString |  52,736 |  47,168 |  37,632 |    28,580 |
| Guid       |      16 |      16 |      16 |        16 |
| Table      | 153,708 | 117,064 |  87,212 |    61,576 |
| Method     | 169,310 | 154,787 | 119,086 |    89,958 |
| Etc        |  35,074 |  31,357 |  21,106 |    14,098 |
| Total      | 521,216 | 443,392 | 334,848 |   249,344 |
| Relative   |    100% |     85% |     64% |       47% |
