using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTypeMono_OverrideTextFile : MonoBehaviour
{

    [Header("Abstract value container")]
    public A_PathTypeAbsoluteFileMono m_filePath;
    public A_PathTypeAbsoluteDirectoryMono m_directoryPath;
    public A_PathTypeRelativeDirectoryMono m_relativeDirectoryPath;
    public A_PathTypeRelativeFileMono m_relativePathPath;

    [Header("Store value")]
    public PathTypeAbsoluteFile m_absoluteFilePathValue;
    public PathTypeAbsoluteDirectory m_absoluteDirectoryPathValue;
    public PathTypeRelativeDirectory m_relativeDirectoryPathValue;   
    public PathTypeRelativeFile m_relativePathPathValue;
    
}
