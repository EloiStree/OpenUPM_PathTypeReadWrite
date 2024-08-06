using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TypePathMono_EditorProjectAssets : Eloi.A_PathTypeAbsoluteDirectoryMono
{
    public override string GetPath()
    {
        Eloi.PathTypeToolbox.IsInUnityEditor(out bool isInUnityEditor);
        if (isInUnityEditor)
            return  Application.dataPath;
        else throw new System.Exception("Should not be used in build, only in editor.");
    }
}
