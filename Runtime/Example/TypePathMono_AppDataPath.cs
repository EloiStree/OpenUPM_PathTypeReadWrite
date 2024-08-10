using Eloi;
using UnityEngine;

public class TypePathMono_AppDataPath : A_PathTypeAbsoluteDirectoryMono
{
    public override string GetPath()
    {
        return Application.dataPath;
    }
}
