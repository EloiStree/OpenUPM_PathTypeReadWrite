namespace Eloi
{
    public interface I_PathTypeFileNameWithExtensionGet
    {
        void GetExtensionWithoutDot(out string extension);
        void GetExtensionWithDot(out string extension);
        void GetFileNameWithoutExtension(out string fileName);
        void GetFileNameWithExtension(out string fileName);
    }
}