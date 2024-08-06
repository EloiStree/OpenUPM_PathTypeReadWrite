using System.IO;

namespace Eloi
{
    [System.Serializable]
    public class PathTypeSubDirectories : I_PathTypeSubDirectoriesGet, I_PathTypeSubDirectoriesSet
    {

        public string[] m_subDirectories;

        public string[] GetAsArray()
        {
            return m_subDirectories;
        }

        public void GetAsArray(out string[] subDirectionArray)
        {
            subDirectionArray = m_subDirectories;
        }

        public string GetAsString()
        {
            return string.Join(Path.PathSeparator, m_subDirectories);
        }

        public void GetAsString(out string subDirectionString)
        {
            subDirectionString = GetAsString();
        }

        public void SetFromArray(string[] subDirectionArray)
        {
            m_subDirectories = subDirectionArray;
        }

        public void SetFromString(string subDirectionString)
        {
            m_subDirectories = subDirectionString.Split(split);
        }
        static readonly char[] split = new char[] { '\\', '/' };
    }
}