namespace Eloi
{
    public static class PathTypeStringToInterface
    {

        public static void GetAbsoluteDirectoryFromPath(in string path, out I_PathTypeAbsoluteDirectoryGet directory, bool asStruct = true)
        {
            if (asStruct)
                directory = new STRUCT_AbsoluteDirectoryPath(path);
            else
                directory = new PathTypeAbsoluteDirectory(path);
        }
        public static void GetRelativeDirectoryFromPath(in string path, out I_PathTypeRelativeDirectoryGet directory, bool asStruct = true)
        {
            if (asStruct)
                directory = new STRUCT_RelativeDirecotryPath (path);
            else
                directory = new PathTypeRelativeDirectory(path);
        }
        public static void GetAbsoluteFileFromPath(in string path, out I_PathTypeAbsoluteFileGet file, bool asStruct = true)
        {
            if (asStruct)
                file = new STRUCT_AbsoluteFilePath(path);
            else
                file = new PathTypeAbsoluteFile(path);
        }
        public static void GetRelativeFileFromPath(in string path, out I_PathTypeRelativeFileGet file, bool asStruct = true)
        {
            if (asStruct)
                file = new STRUCT_RelativeFilePath(path);
            else
                file = new PathTypeRelativeFile(path);
        }

    }
}
