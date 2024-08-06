using Eloi;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TypePathMono_RootToFileSubDirectory : A_PathTypeAbsoluteFileMono
{
    


    public A_PathTypeAbsoluteDirectoryMono m_whereToStore;
    public PathTypeSubDirectories m_subDirectories;
    public FileNameWithExtension m_fileNameWithExtension;

    public override string GetPath()
    {
        m_fileNameWithExtension.GetFileNameWithExtension(out string file);
        return Path.Combine(m_whereToStore.GetPath(), m_subDirectories.GetAsString(), file);
    }


}
