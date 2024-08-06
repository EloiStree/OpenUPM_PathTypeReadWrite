using UnityEngine;

namespace Eloi
{
    [System.Serializable]
    public class PathTypeFileExtension
    {
        [SerializeField] string m_extensionNameWithoutDot = "";

        public PathTypeFileExtension(string extensionNameWithoutDot)
        {
            this.m_extensionNameWithoutDot = extensionNameWithoutDot;
        }

        public void SetExtension(in string fileExtensionWithoutDot)
        {
            m_extensionNameWithoutDot = fileExtensionWithoutDot;
        }
        public void GetExtensionWithoutDot(out string extension) => extension = m_extensionNameWithoutDot;
        public void GetExtensionWithDot(out string extension) => extension = "." + m_extensionNameWithoutDot;
    }
}