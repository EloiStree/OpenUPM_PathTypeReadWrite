namespace Eloi
{

    public static partial class PathTypeToolbox
    {
        public static void IsInUnityEditor(out bool isInUnityEditor)
        {
            isInUnityEditor = false;
            #if UNITY_EDITOR
                        isInUnityEditor = true;
            #endif
        }
        public static bool IsInUnityEditor()
        {
            #if UNITY_EDITOR
                        return true;
            #else 
                        return false;
            #endif
        }
    }
}