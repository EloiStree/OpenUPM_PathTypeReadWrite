namespace Eloi
{
    [System.Serializable]
    public class PathTypeRelativeDirectory : UndefinedCompletePath, I_PathTypeRelativeDirectoryGet
    {
        public PathTypeRelativeDirectory(string path) : base(path)
        {
        }
    }
}