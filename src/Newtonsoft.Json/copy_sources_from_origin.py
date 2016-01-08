import os
import shutil
import xml.etree.ElementTree as ET

def copy_sources_from_proj(root_path, csproj_name):
    csproj_path = os.path.join(root_path, csproj_name)
    tree = ET.parse(csproj_path)
    for e in tree.getroot().iter("{http://schemas.microsoft.com/developer/msbuild/2003}Compile"):
        if 'Include' in e.attrib:
            file = e.attrib['Include']
            print file
            file_parts = os.path.split(file)
            if len(file_parts[0]) > 0:
                try:
                    os.makedirs(file_parts[0])
                except:
                    pass
            try:
                shutil.copy(os.path.join(root_path, file), file)
            except Exception as e:
                print "!!!", e

copy_sources_from_proj(
    r'..\..\..\Newtonsoft.Json\Src\Newtonsoft.Json',
    r'Newtonsoft.Json.Unity3D.csproj')
