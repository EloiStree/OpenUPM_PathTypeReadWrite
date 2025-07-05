using Eloi;
using System.IO;

public class TypePathMono_RootToSubDirectory : A_PathTypeAbsoluteDirectoryMono
{



    public A_PathTypeAbsoluteDirectoryMono m_whereToStore;
    public PathTypeSubDirectories m_subDirectories;

    public override string GetPath()
    {
       string path =string.Join("/",  m_subDirectories.GetAsString());
        return Path.Combine(m_whereToStore.GetPath(), path);
    }


}
