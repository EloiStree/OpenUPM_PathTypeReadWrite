using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathTypeMono_DebugAbstractFile : A_PathTypeAbsoluteFileMono
{
   

    public Eloi.A_PathTypeAbsoluteFileMono m_pathTypeMono;
    public string m_directoryPath;

    public bool m_refreshAtStart = true;
    public UnityEvent<string> m_onPathFetch;

    public void Start()
    {
        if (m_refreshAtStart)
            Refresh();
    }
    [ContextMenu("Refresh")]
    public void Refresh()
    {

        if (m_pathTypeMono != null)
            m_pathTypeMono.GetPath(out m_directoryPath);
        else m_directoryPath = "";
        m_onPathFetch.Invoke(m_directoryPath);
    }

    public override string GetPath()
    {
        string path = "";
        if(m_pathTypeMono != null)
            m_pathTypeMono.GetPath(out path);
        m_directoryPath = path;
        m_onPathFetch.Invoke(path);
        return path;
    }
}