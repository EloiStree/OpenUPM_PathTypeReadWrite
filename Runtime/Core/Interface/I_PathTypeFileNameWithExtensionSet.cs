namespace Eloi
{
    public interface I_PathTypeFileNameWithExtensionSet
    {
        void SetExtensionWithoutDot(string fileExtension);
        void SetFileNameWithoutDot(string fileNameWithoutDot);
        void SetFileNameWithExtensionAndDot(string filenameWithExtension);
    }
}