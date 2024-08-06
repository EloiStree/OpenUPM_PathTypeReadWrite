namespace Eloi
{
    public interface I_PathTypeFileExtensionGet
    {
        void GetExtensionWithDot(out string fileExtensionWithDot);
        void GetExtensionWithoutDot(out string fileExtensionWithoutDot);
    }
}