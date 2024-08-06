using UnityEngine;

namespace Eloi
{
    [System.Serializable]
    public class FileNameWithoutExtension : I_PathTypeFileNameWithoutExtensionGetSet
    {
        [SerializeField] string m_fileName = "";

        public FileNameWithoutExtension()
        {
        }

        public FileNameWithoutExtension(string fileName)
        {
            this.m_fileName = fileName;
        }

        public void GetName(out string fileName) 
            => fileName = m_fileName;

        public void SetName(string fileName)
            => m_fileName = fileName;
        

    }
}