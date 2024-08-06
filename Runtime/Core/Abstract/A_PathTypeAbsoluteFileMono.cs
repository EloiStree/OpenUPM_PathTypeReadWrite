using System.IO;
using UnityEngine;

namespace Eloi
{
    /// <summary>
    /// I am a class  that containt a path to a file and it is in absolute path format.
    /// </summary>
    public abstract class A_PathTypeAbsoluteFileMono : AbstractUndefinedPathMono, I_PathTypeAbsoluteFileGet
    {
        [ContextMenu("Create Empty File")]
        public void CreateAnEmptyFileOfThePath()
        {
            File.WriteAllText(GetPath(), "") ;
        }
        [ContextMenu("Delete File")]
        public void DeleteTheFileAtPathLocation()
        {

            if (File.Exists(GetPath()))
                File.Delete(GetPath());
        }
        [ContextMenu("Open File with Unity3D")]
        public void OpenFileWithUnity3D()
        {
            Application.OpenURL(GetPath());
        }
        [ContextMenu("Open directory with Unity3D")]
        public void OpenDirectoryWithUnity3D()
        {
            Application.OpenURL(Path.GetDirectoryName(GetPath()));
        }
    }
}