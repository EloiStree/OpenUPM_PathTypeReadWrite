using Eloi;
using System.IO;



public class TypePathMono_IfElse_EditorOrBuildDirectory : Eloi.A_PathTypeAbsoluteDirectoryMono
{
    public A_PathTypeAbsoluteDirectoryMono m_whenInEditor;
    public A_PathTypeAbsoluteDirectoryMono m_whenInBuild;

    public override string GetPath()
    {
        string path = "";
        if (Eloi.PathTypeToolbox.IsInUnityEditor())
            m_whenInEditor.GetPath(out path);
        else
            m_whenInBuild.GetPath(out path);
        return path;
    }
}
