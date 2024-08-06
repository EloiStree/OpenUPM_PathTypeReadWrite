using System;

namespace Eloi
{
    [System.Serializable]
    public struct STRUCT_AbsoluteDirectoryPath : I_PathTypeAbsoluteDirectoryGet, I_PathTypeAbsoluteDirectorySet
    {

        public STRUCT_AbsoluteDirectoryPath(string absolutePath = "")
        {
            m_absolutePathOfDirectory = absolutePath;
        }


        [UnityEngine.SerializeField] string m_absolutePathOfDirectory;
        public string GetPath() => m_absolutePathOfDirectory;
        public void GetPath(out string absolutePath)
        {
            absolutePath = m_absolutePathOfDirectory;
        }

        public void SetPath(string absolutePath)
        {
            m_absolutePathOfDirectory = absolutePath;
        }
    }
}