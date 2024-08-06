namespace Eloi
{
    /// <summary>
    ///  I am an interface that contain a gettable path but without knowing what is containted in it.
    ///  By Full path I am path a relative or absolute path that is not a piece of a path.
    /// </summary>
    public interface I_PathTypeCompletePathGet
    {
        void GetPath(out string path);
        string GetPath();
    }
}