using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTypeExampleMono_OverrideTextureFile : MonoBehaviour
{

    public Texture2D m_textureToWrite ;
    public A_PathTypeAbsoluteDirectoryMono m_whereToStore;
    public FileNameWithExtension m_fileNameWithExtension;
    public string m_whereToStoreFileLast;
    public bool m_succeed;
    [ContextMenu("Write file")]
    public void WriteFile()
    {

        SaveTexture("png");
        SaveTexture("jpeg");
        SaveTexture("tga");
    }

    private void SaveTexture(string extension)
    {
        I_PathTypeAbsoluteFileGet whereToStoreFile = null;
        m_fileNameWithExtension.SetExtensionWithoutDot(extension);
        whereToStoreFile = TypePathCombineTool.Combine(
            m_whereToStore,
            m_fileNameWithExtension);
        m_whereToStoreFileLast = whereToStoreFile.GetPath();
        AbsoluteTypePathTool.OverwriteTexture2D(whereToStoreFile, m_textureToWrite);
    }
}
