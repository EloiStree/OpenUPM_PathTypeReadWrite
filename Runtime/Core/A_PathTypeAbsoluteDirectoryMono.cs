using System.IO;
using UnityEngine;

namespace Eloi
{
    /// <summary>
    ///  I am a class  that containt a path to a directory and it is in absolute path format.
    /// </summary>
    public abstract class A_PathTypeAbsoluteDirectoryMono : AbstractUndefinedPathMono, I_PathTypeAbsoluteDirectoryGet
    {
        [ContextMenu("Create Empty Directory")]
        public void CreateEmptyDirectory()
        {
            AbsoluteTypePathTool.CreateDirectoryIfNotThere(this);
        }
        [ContextMenu("Delete Directory")]
        public void DeleteTheDirectoryAtPathLocation()
        {
            if (Directory.Exists(GetPath()))
                Directory.Delete(GetPath());
        }

        [ContextMenu("Open directory with Unity3D")]
        public void OpenDirectoryWithUnity3D()
        {
            Application.OpenURL(GetPath());
        }
    }
}