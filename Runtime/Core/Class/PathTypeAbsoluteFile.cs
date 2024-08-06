namespace Eloi
{
    [System.Serializable]
    public class PathTypeAbsoluteFile : UndefinedCompletePath, I_PathTypeAbsoluteFileGet
    {
        public PathTypeAbsoluteFile(string path) : base(path)
        {
        }
    }
}