namespace Eloi
{
    [System.Serializable]
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