# Workaround for UWP (Universal Windows Platform)

Latest windows store uses UWP for building an app.
Unlike regular Unity apps, app for UWP uses dedicated .NET framework which is
not compatible with Unity3D-Mono framework.

## What's the problem?

When you try to build app using Json.NET.Unity3D for Windows Store,
you will get following errors:

```
UnityException: Failed to run serialization weaver with command ...
(stripped)

Mono.Cecil.ResolutionException:
  Failed to resolve System.Runtime.Serialization.Formatters.FormatterAssemblyStyle
(stripped)
```

UAP doesn't have enum `FormatterAssemblyStyle` in its assembly and
it should be added to run on windows store.

## How to fix?

It's simple. Use original [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)
which contains a DLL for UWP.

  1. Import [Json.Net.Unity3D](https://github.com/SaladLab/Json.Net.Unity3D/releases/download/8.0.3/JsonNet.8.0.3.unitypackage)
     unity package.
  1. Create `Assets/UnityPackages/JsonNet/Portable` directory in unity project.
  1. Download [Newtonsoft.Json](https://www.nuget.org/api/v2/package/Newtonsoft.Json/8.0.3)
     nuget package and extract it as a zip file.
  1. Copy `./lib/portable-net45%2Bwp80%2Bwin8%2Bwpa81%2Bdnxcore50/Newtonsoft.Json.dll`
     in the nuget package to `Assets/UnityPackages/JsonNet/Portable` directory.
  1. Watch `Assets/UnityPackages/JsonNet/Newtonsoft.Json.dll` with an inspector,
     uncheck `Any Platform` at Select platforms for plugin
     and Set all platforms checked except `WSAPlayer`.
  1. Watch `Assets/UnityPackages/JsonNet/Portable/Newtonsoft.Json.dll` with an inspector,
     uncheck `Any Platform` at Select platforms for plugin
     and set only `WSAPlayer` checked.

If you feel complicated, just download
[this ](https://github.com/SaladLab/Json.Net.Unity3D/releases/download/8.0.3/JsonNet-UwpWorkaround.8.0.3.zip) and extract it to `Assets/UnityPackages/JsonNet` directory in your project.
