using System.IO;
using UnityEngine;

namespace Eloi
{
    public static class PlatformDirectoryTool {

        public static class Window { 
            public static void GetExecutableOrProjectRoot(out string rootpath)
            {


                rootpath = Application.dataPath;

    #if PLATFORM_STANDALONE_WIN
                //The folder next the executable is the data path
                rootpath = Path.Combine(Application.dataPath, "../");
    #endif
    #if UNITY_EDITOR
                // Assets is the data path in the editor
                rootpath = Path.Combine(Application.dataPath, "../");
    #endif
            }
        }

    }
}
