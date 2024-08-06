using UnityEngine;

namespace Eloi
{
    [System.Serializable]
    public class FileNameWithExtension : I_PathTypeFileNameWithExtensionGet
    {
        [SerializeField] string m_fileName = "";
        [SerializeField] string m_extensionNameWithoutDot = "";

        public FileNameWithExtension(string fileName, string extensionNameWithoutDot)
        {
            this.m_fileName = fileName;
            this.m_extensionNameWithoutDot = extensionNameWithoutDot;
        }
        public FileNameWithExtension(string textToSplitWithDot)
        {
            SetFileFromStringSplitAtLastDot(textToSplitWithDot);
        }
        public void SetFileFromStringSplitAtLastDot(in string text)
        {
            int indexLastDot = text.LastIndexOf(".");
            if (indexLastDot < 0)
            {
                m_fileName = text;
                m_extensionNameWithoutDot = "";
            }
            else {
                PathTypeStringUtility.SplitInTwo(in text, in indexLastDot, out m_fileName,out m_extensionNameWithoutDot);
            }
        }
        public void SetFileName(in string fileName, in string fileExtensionWithoutDot) {
            m_fileName = fileName;
            m_extensionNameWithoutDot = fileExtensionWithoutDot;
        }
        public void GetExtensionWithoutDot(out string extension) => extension = m_extensionNameWithoutDot;
        public void GetExtensionWithDot(out string extension) => extension = "." + m_extensionNameWithoutDot;
        public void GetFileNameWithoutExtension(out string fileName) { fileName = m_fileName; }
        public void GetFileNameWithExtension(out string fileName) { fileName = m_fileName + "." + m_extensionNameWithoutDot; }

        public bool IsEmpty()
        {
            return m_fileName.Trim().Length <= 0 && m_extensionNameWithoutDot.Trim().Length <= 0;
        }
    }
}