using System;
using System.Collections;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

namespace Eloi
{

    

    public class PathTypeTextureUtility
    {
      

        public static void LoadTexture2DFromFile(in I_PathTypeAbsoluteFileGet path, out Texture2D texture, bool mipmap = true, bool linear = false)
        {
            if (path == null)
            {
                texture = null;
                return;
            }
            path.GetPath(out string p);
            LoadTexture2DFromFile(p, out texture);
        }

        public static void LoadTexture2DFromFile(in string path, out Texture2D texture, bool mipmap = true, bool linear = false)
        {
           
            if (File.Exists(path))
            {
                byte[] buffer = File.ReadAllBytes(path);
                texture = new Texture2D(1, 1, TextureFormat.RGBA32, mipmap, linear);
                texture.LoadImage(buffer);
                texture.Apply();
            }
            else texture = null;

        }
    }

    public class E_FileAndFolderUtilityObsolete
    {
        
        
       


        public static void GetFilesPathsIn(out string[] paths, I_PathTypeFileNameWithExtensionGet fileOverwatch, I_PathTypeAbsoluteDirectoryGet directory, bool lookInChildren=true)
        {
            string dPath = directory.GetPath();
            if (PathTypeStringUtility.IsFilled(in dPath) && Directory.Exists(dPath))
            {
                fileOverwatch.GetExtensionWithDot(out string fileExt);
                paths = Directory.GetFiles(dPath, "*" + fileExt, lookInChildren ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            else {
                paths = new string[0];
            }
        }

      

        public static void GetFileWithExtension(in I_PathTypeAbsoluteFileGet filePath, out I_PathTypeFileNameWithExtensionGet fileName)
        {
            string path = filePath.GetPath();
            string name=Path.GetFileNameWithoutExtension(path),
                extension = Path.GetExtension(path);
            if (PathTypeStringUtility.IsFilled(extension) && extension[0] == '.')
                extension = extension.Substring(1);
            fileName = new FileNameWithExtension(name, extension);
        }

        public static I_PathTypeAbsoluteDirectoryGet GetParent(in I_PathTypeAbsoluteDirectoryGet path)
        {
            string p = System.IO.Directory.GetParent(path.GetPath()).FullName;
            return new PathTypeAbsoluteDirectory(p);
        }


      


       


        



       
       

        

    }
}
