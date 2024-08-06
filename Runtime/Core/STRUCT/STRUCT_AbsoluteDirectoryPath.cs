using System;

namespace Eloi
{

    public struct STRUCT_RelativeDirecotryPath : I_PathTypeRelativeDirectoryGet, I_PathTypeRelativeDirectorySet
    {
        public string m_relativePathOfDirectory;

        public STRUCT_RelativeDirecotryPath(string relativePath = "")
        {
            m_relativePathOfDirectory = relativePath;
        }

        public void GetPath(out string path)
        {
            path = m_relativePathOfDirectory;
        }

        public string GetPath()
        {
            return m_relativePathOfDirectory;
        }

        public void SetPath(string path)
        {
            m_relativePathOfDirectory = path;
        }
    }
    public struct STRUCT_RelativeFilePath : I_PathTypeRelativeFileGet, I_PathTypeRelativeFileSet
    {
        public string m_relativePathOfFile;

        public STRUCT_RelativeFilePath(string relativePath = "")
        {
            m_relativePathOfFile = relativePath;
        }

        public void GetPath(out string path)
        {
            path = m_relativePathOfFile;    
        }

        public string GetPath()
        {
            return m_relativePathOfFile;
        }

        public void SetPath(string path)
        {
            m_relativePathOfFile = path;
        }
    }

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

    public struct STRUCT_AbsoluteFilePath : I_PathTypeAbsoluteFileGet, I_PathTypeAbsoluteFileSet
    {

        public STRUCT_AbsoluteFilePath(string absolutePath = "")
        {
            m_absolutePathOfFile = absolutePath;
        }


        [UnityEngine.SerializeField] string m_absolutePathOfFile;
        public string GetPath() => m_absolutePathOfFile;
        public void GetPath(out string absolutePath)
        {
            absolutePath = m_absolutePathOfFile;
        }

        public void SetPath(string absolutePath)
        {
            m_absolutePathOfFile = absolutePath;
        }
    }
}