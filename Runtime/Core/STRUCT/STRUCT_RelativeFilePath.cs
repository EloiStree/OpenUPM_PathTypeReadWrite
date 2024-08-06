namespace Eloi
{
    [System.Serializable]
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
}