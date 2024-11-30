using Eloi;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class PathTypeMono_OverrideTextFile : MonoBehaviour
{

    [TextArea(2, 4)]
    public string m_textToWrite = "Hello World";
    public A_PathTypeAbsoluteFileMono m_whereToStore;
    public bool m_useAtAwake = true;

    private void Awake()
    {
        if (m_useAtAwake)
            WriteFile();
    }
    [ContextMenu("Write file")]
    public void WriteFile()
    {
        AbsoluteTypePathTool.OverwriteFile(m_whereToStore, m_textToWrite);
    }

}
