using UnityEngine;

namespace Eloi
{
    [System.Serializable]
    public class UndefinedCompletePath : I_PathTypeCompletePathSet, I_PathTypeCompletePathGet
    {
        [SerializeField] string m_path = "";
        public void GetPath(out string path) => path = m_path;
        public void SetPath(string path) => m_path = path;
        public string GetPath()
        {
            return m_path;
        }
        public UndefinedCompletePath()
        {
        }

        public UndefinedCompletePath(string path)
        {
            this.m_path = path;
        }
    }
}