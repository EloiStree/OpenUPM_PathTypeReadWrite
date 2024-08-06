namespace Eloi
{
    [System.Serializable]
    public class PathTypeAbsoluteDirectory : UndefinedCompletePath, I_PathTypeAbsoluteDirectoryGet
    {
        public PathTypeAbsoluteDirectory(string path) : base(path)
        {
        }
    }
}