using Eloi;

public class TypePathMono_IfElse_EditorOrBuildFile : Eloi.A_PathTypeAbsoluteFileMono
{
    public A_PathTypeAbsoluteFileMono m_whenInEditor;
    public A_PathTypeAbsoluteFileMono m_whenInBuild;

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