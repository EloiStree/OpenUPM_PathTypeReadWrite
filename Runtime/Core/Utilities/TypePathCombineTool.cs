using System.Linq;

namespace Eloi
{
    public static class TypePathCombineTool
    {
        


        public static I_PathTypeAbsoluteDirectoryGet Combine(in I_PathTypeAbsoluteDirectoryGet root, in I_PathTypeRelativeDirectoryGet subfolders)
        {
            PathTypeStringUtility.MeltPathTogether(out string pathfolder, root.GetPath(), subfolders.GetPath());
            return new PathTypeAbsoluteDirectory(pathfolder);
        }

        public static I_PathTypeAbsoluteFileGet Combine(in I_PathTypeAbsoluteDirectoryGet root, in I_PathTypeRelativeDirectoryGet subfolders, in I_PathTypeFileNameWithExtensionGet file)
        {
            PathTypeStringUtility.MeltPathTogether(out string pathfolder, root.GetPath(), subfolders.GetPath());
            file.GetFileNameWithExtension(out string fileNameWExt);
            PathTypeStringUtility.MeltPathTogether(out string path, pathfolder, fileNameWExt);
            return new PathTypeAbsoluteFile(path);
        }
        public static string[] emptyStringArray = new string[0];
        public static I_PathTypeRelativeDirectoryGet[] emptyDirectoryStringArray = new I_PathTypeRelativeDirectoryGet[0];

        public static I_PathTypeAbsoluteFileGet Combine(in I_PathTypeAbsoluteDirectoryGet root, in I_PathTypeRelativeDirectoryGet[] subfolders, in I_PathTypeFileNameWithExtensionGet file)
        {
            string[] paths = subfolders.Select(k => k.GetPath()).ToArray();
            PathTypeStringUtility.MeltPathTogether(out string pathfolder, root.GetPath(), paths);
            file.GetFileNameWithExtension(out string fileNameWExt);
            PathTypeStringUtility.MeltPathTogether(out string path, pathfolder, fileNameWExt);
            return new PathTypeAbsoluteFile(path);
        }
        public static I_PathTypeAbsoluteDirectoryGet Combine(in I_PathTypeAbsoluteDirectoryGet root, params I_PathTypeRelativeDirectoryGet[] subfolders)
        {
            string[] paths = subfolders.Select(k => k.GetPath()).ToArray();
            PathTypeStringUtility.MeltPathTogether(out string path, root.GetPath(), paths);
            return new PathTypeAbsoluteDirectory(path);
        }
        public static I_PathTypeAbsoluteFileGet Combine(in I_PathTypeAbsoluteDirectoryGet root, in I_PathTypeFileNameWithExtensionGet fileName)
        {
            fileName.GetFileNameWithExtension(out string fileExt);
            PathTypeStringUtility.MeltPathTogether(out string path, root.GetPath(), fileExt);
            return new STRUCT_AbsoluteFilePath(path);
        }
        public static I_PathTypeAbsoluteFileGet Combine(in I_PathTypeAbsoluteDirectoryGet root, in I_PathTypeFileNameWithoutExtensionGet fileName)
        {
            fileName.GetName(out string fileNameAsString);
            PathTypeStringUtility.MeltPathTogether(out string path, root.GetPath(), fileNameAsString);
            return new PathTypeAbsoluteFile(path);
        }

    }
}