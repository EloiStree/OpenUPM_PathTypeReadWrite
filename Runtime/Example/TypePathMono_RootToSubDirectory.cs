using Eloi;
using System.IO;

public class TypePathMono_RootToSubDirectory : A_PathTypeAbsoluteDirectoryMono
{



    public A_PathTypeAbsoluteDirectoryMono m_whereToStore;
    public PathTypeSubDirectories m_subDirectories;

    public override string GetPath()
    {
      
        return Path.Combine(m_whereToStore.GetPath(), m_subDirectories.GetAsString());
    }


}
