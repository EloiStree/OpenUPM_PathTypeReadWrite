namespace Eloi
{
    [System.Serializable]
    public class PathTypeRelativeFile : UndefinedCompletePath, I_PathTypeRelativeFileGet
    {
        public PathTypeRelativeFile(string path) : base(path)
        {
        }
    }
}