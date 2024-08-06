namespace Eloi
{
    [System.Serializable]
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
}