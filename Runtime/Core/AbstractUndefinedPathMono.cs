using System.IO;
using UnityEngine;

namespace Eloi
{
    /// <summary>
    /// I am a class that contain a path but without knowing what is containted in it.
    /// </summary>
    public abstract class AbstractUndefinedPathMono : MonoBehaviour
    {

        public void GetPath(out string path) {
            path = GetPath();
        }
        public abstract string GetPath();

        [ContextMenu("Open Target")]
        public void OpenFileWithUnity() { Application.OpenURL(GetPath()); }
        [ContextMenu("Open Directory")]
        public void OpenDirectoryWithUnity()
        {

            STRUCT_AbsoluteFilePath dirPath = new STRUCT_AbsoluteFilePath(GetPath());
            AbsoluteTypePathTool.GetDirectoryFrom(dirPath, out I_PathTypeAbsoluteDirectoryGet dir);
            Application.OpenURL(dir.GetPath());
        }

       

        public void CreateDirectory() {
            Directory.CreateDirectory(GetPath());
        }

        
    }
}