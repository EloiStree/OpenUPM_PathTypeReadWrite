using Eloi;
using UnityEngine;

public class PathTypeExampleMono_ValueAndAbstractRef : MonoBehaviour
{

    [Header("Abstract value container")]
    public A_PathTypeAbsoluteFileMono m_filePath;
    public A_PathTypeAbsoluteDirectoryMono m_directoryPath;
    public A_PathTypeRelativeFileMono m_relativePathPath;
    public A_PathTypeRelativeDirectoryMono m_relativeDirectoryPath;

    [Header("Class  value")]
    public PathTypeAbsoluteFile m_absoluteFilePathValue;
    public PathTypeAbsoluteDirectory m_absoluteDirectoryPathValue;
    public PathTypeRelativeDirectory m_relativeDirectoryPathValue;
    public PathTypeRelativeFile m_relativePathPathValue;
    public PathTypeSubDirectories m_subDirectoriesValue;

    [Header("Struct  value")]
    public STRUCT_AbsoluteFilePath m_absoluteFilePathStructValue;
    public STRUCT_AbsoluteDirectoryPath m_absoluteDirectoryPathStructValue;
    public STRUCT_RelativeFilePath m_relativePathPathStructValue;
    public STRUCT_RelativeDirecotryPath m_relativeDirectoryPathStructValue;
    public STRUCT_SubDirectories m_subDirectoriesStructValue;

}