#I @"packages/FAKE/tools"
#I @"packages/FAKE.BuildLib/lib/net451"
#r "FakeLib.dll"
#r "BuildLib.dll"

open Fake
open Fake.FileHelper
open BuildLib
open System.IO

let solution = 
    initSolution
        "./Json.Net.Unity3D.sln" "Release" []

Target "Clean" <| fun _ -> cleanBin

Target "Restore" <| fun _ -> restoreNugetPackages solution

Target "Build" <| fun _ ->
    // Regular
    buildSolution solution
    // Lite
    !!solution.SolutionFile
    |> MSBuild "" "Rebuild" [ "Configuration", solution.Configuration + "Lite" ]
    |> Log "Build-Output: "


Target "Test" <| fun _ -> 
    let nunitRunnerDir = lazy ((getNugetPackage "NUnit.Runners" "2.6.4") @@ "tools")
    ensureDirectory testDir
    !! ("./src/**/bin/" + solution.Configuration + "/*.Tests.dll")
    |> NUnit (fun p -> 
        {p with ToolPath = nunitRunnerDir.Force()
                DisableShadowCopy = true;
                OutputFile = testDir @@ "test.xml" })

Target "PackUnity" <| fun _ ->
    packUnityPackage "./src/UnityPackage/JsonNet.unitypackage.json"
    packUnityPackage "./src/UnityPackage/JsonNet-Lite.unitypackage.json"

Target "Pack" <| fun _ -> ()

Target "CI" <| fun _ -> ()

Target "Help" <| fun _ ->
    showUsage solution (fun _ -> None)

"Clean"
  ==> "Restore"
  ==> "Build"
  ==> "Test"

"Build" ==> "PackUnity"
"PackUnity" ==> "Pack"

"Test" ==> "CI"
"Pack" ==> "CI"

RunTargetOrDefault "Help"
