namespace Eloi
{
    public interface I_PathTypeSubDirectoriesGet
    {
        public string[] GetAsArray();
        public string GetAsString();
        public void GetAsArray(out string[] subDirectionArray);
        public void GetAsString(out string subDirectionString);

    }
}