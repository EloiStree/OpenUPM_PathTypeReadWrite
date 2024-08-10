using Eloi;
using UnityEngine;

public class TypePathMono_AppPersistentDataPath : A_PathTypeAbsoluteDirectoryMono
{
    public override string GetPath()
    {
        return Application.persistentDataPath;
    }
}
