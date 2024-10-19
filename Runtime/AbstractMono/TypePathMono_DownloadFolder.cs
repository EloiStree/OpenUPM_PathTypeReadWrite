using System;
using System.IO;

public class TypePathMono_DownloadFolder: Eloi.A_PathTypeAbsoluteDirectoryMono
{
    public override string GetPath()
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

#if UNITY_ANDROID && !UNITY_EDITOR
    // List of possible Android storage paths
    string[] androidPaths = new string[]
    {
        "/storage/emulated/0/Download/",
        "/storage/emulated/0/",
        "/storage/sdcard/Download/",
        "/storage/sdcard0/Download/",
        "/storage/sdcard1/Download/",
        "/storage/sdcard/",
        "/storage/sdcard0/",
        "/storage/sdcard1/",
        "/mnt/sdcard/Download/",
        "/mnt/sdcard/",
        "/storage/USBstorage1/Download/"
    };

    // Loop through the paths and pick the first that exists
    foreach (var p in androidPaths)
    {
        if (Directory.Exists(p))
        {
            path = p;
            break;
        }
    }
#endif

        return path;
    }

}