using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TypePathMono_RootToFileSubDirectory : A_PathTypeAbsoluteFileMono
{
    
    public A_PathTypeAbsoluteDirectoryMono m_whereToStore;
    public PathTypeSubDirectories m_subDirectories;
    public FileNameWithExtension m_fileNameWithExtension;
    public bool m_withDate = false;

    public override string GetPath()
    {
        m_fileNameWithExtension.GetFileNameWithoutExtension(out string fileName);
        m_fileNameWithExtension.GetExtensionWithoutDot(out string fileExtension);

        string file = fileName + "." + fileExtension;
        if (m_withDate)
            file = $"{fileName}_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.{fileExtension}";
        return Path.Combine(m_whereToStore.GetPath(), m_subDirectories.GetAsString(), file);
    }
}
