using Eloi;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class PathTypeMono_CreateOrReadTextFile : MonoBehaviour
{

    public A_PathTypeAbsoluteFileMono m_whereToStore;
    public TextAsset m_textToWrite;
    public bool m_executeAtAwake = true;

    public UnityEvent<string> m_onTextRead;
    public UnityEvent<string> m_onLineRead;

    private void Awake()
    {
        if (m_executeAtAwake)
            CreateOrReadFile();
    }
    public void CreateOrReadFile()
    {
        if (m_whereToStore != null)
        {
            string path = m_whereToStore.GetPath();
            if (!File.Exists(path))
            {
                string text = " ";
                if (m_textToWrite != null)
                    text = m_textToWrite.text;
                File.WriteAllText(path, text);
            }

            string readText = File.ReadAllText(path);
            try
            {
                m_onTextRead.Invoke(readText);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }

            string[] lines = readText.Split('\n');
            foreach (var item in lines)
            {
                try
                {
                    m_onLineRead.Invoke(item.Trim());
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }
}
