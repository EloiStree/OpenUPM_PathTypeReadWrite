namespace Eloi
{
    public interface I_PathTypeFileNameWithoutExtensionGet
    {
        void GetName(out string fileName);
    }
    public interface I_PathTypeFileNameWithoutExtensionSet
    {
        void SetName(string fileName);
    }
    public interface I_PathTypeFileNameWithoutExtensionGetSet: I_PathTypeFileNameWithoutExtensionGet, I_PathTypeFileNameWithoutExtensionSet
    {
    }
}