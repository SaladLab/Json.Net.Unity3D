using UnityEditor;

public static class PackageBuilder
{
    [MenuItem("Assets/Build UnityPackage")]
    public static void BuildPackage()
    {
        var assetPaths = new string[]
        {
            "Assets/Middleware/JsonNet",
            "Assets/Middleware/JsonNetSample",
        };

        var packagePath = "Json-Net-Unity3D.unitypackage";
        var options = ExportPackageOptions.Recurse;
        AssetDatabase.ExportPackage(assetPaths, packagePath, options);
    }
}
