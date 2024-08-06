using System.IO;

namespace Eloi
{
    public class DirectOrRelativeDirectoryPathMono : Eloi.A_PathTypeAbsoluteDirectoryMono
    {
        public Eloi.A_PathTypeAbsoluteDirectoryMono m_directoryPath;
        public Eloi.A_PathTypeAbsoluteDirectoryMono m_relativeToProjectPath;

        public override string GetPath()
        {
            if (m_directoryPath != null)
            {
                m_directoryPath.GetPath(out string directPath);
                if (directPath.Trim().Length > 0)
                {
                    return directPath;
                }
            }
            if( m_relativeToProjectPath != null)
            {
                m_relativeToProjectPath.GetPath(out string relativePath);
                if (relativePath.Trim().Length > 0)
                {
                    return relativePath;
                }
            }
            return ""; 
        }
    }
}