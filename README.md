# Newtonsoft Json.NET for Unity3D

[Newtonsoft Json.NET](http://www.newtonsoft.com/json) is a de facto standard JSON library in .NET ecosystem.
But it doesn't support Unity3D, so it's a little bit hard to use JSON.NET just after getting [Json.NET package](https://www.nuget.org/packages/Newtonsoft.Json/).
This package is for Unity3D programmers that need to use latest Json.NET in Unity3D.

## Where can I get it?

Visit [Release](https://github.com/SaladbowlCreative/Json.Net.Unity3D/releases)
page to get latest Json.NET unity-package.

## What's the deal?

Unity3D has old-fashioned and bizarre .NET Framework like these :)
 - Basically based on .NET Framework 3.5 ([forked Mono 2.6](https://github.com/Unity-Technologies/mono/commits/unity-staging))
 - Runtime lacks some types in .NET Framework 3.5 (like System.ComponentModel.AddingNewEventHandler)
 - For iOS, dynamic code emission is forbidden by Apple AppStore.

Because Newtonsoft Json.NET doesn't handle these limitations, errors will welcome you
when you use official Json.NET dll targetting .NET 3.5 Framework.

## What's done?

Following works are done to make Json.NET support Unity3D.

 - Based on Newtonsoft Json.NET 7.0.1.
 - Disable IL generation to work well under AOT environment like iOS.
 - Remove code related with System.ComponentModel.
 - Remove System.Data and EntityKey support.
 - Remove XML support.
 - Remove JPath class to reduce size of DLL.
 - Remove DiagnosticsTraceWriter support.
