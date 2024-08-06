using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Eloi
{

    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {
      
    }

#endregion
#region SOME UTILITY
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {

        public static void GetRelativePathFrom(
            in I_PathTypeAbsoluteDirectoryGet root,
            in I_PathTypeAbsoluteFileGet selection,
            out I_PathTypeRelativeFileGet relativePath)
        {
            string relative = PathTypeStringUtility.SubstractRootPath(root.GetPath(), selection.GetPath());
            relativePath = new STRUCT_RelativeFilePath(relative);
        }
        public static void GetRelativePathFrom(
            in I_PathTypeAbsoluteDirectoryGet root,
            in I_PathTypeAbsoluteDirectoryGet selection,
            out I_PathTypeRelativeDirectoryGet relativePath)
        {

            string relative = PathTypeStringUtility.SubstractRootPath(root.GetPath(), selection.GetPath());
            relativePath = new STRUCT_RelativeDirecotryPath(relative);
        }
    }
    #endregion
    #region LABEL OF WHAT IT DOES
    public static partial class AbsoluteTypePathTool
    {


        

        public static bool IsNotLock(in I_PathTypeAbsoluteFileGet m_destinationImage)
        {
            if (m_destinationImage == null)
                return false;
            m_destinationImage.GetPath(out string p);
            if (!File.Exists(p))
                return false;

            FileInfo fi = new FileInfo(p);
            return !IsFileLocked(fi);
        }
        public static bool IsLock(in I_PathTypeAbsoluteFileGet m_destinationImage)
        {
            if (m_destinationImage == null)
                return false;
            m_destinationImage.GetPath(out string p);
            if (!File.Exists(p))
                return false;

            FileInfo fi = new FileInfo(p);
            return IsFileLocked(fi);
        }
        private static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
    #region CREATE IMPORT GENERIC DATA
    public static partial class AbsoluteTypePathTool
    {




        public delegate void AccessTextDefaultIfNeeded(out string textToUse);
        public static void OverwriteOrCreateThenImportText(
            in I_PathTypeAbsoluteFileGet fileTarget,
            out string imported,
            AccessTextDefaultIfNeeded defaultTextToStore)
        {
            if (Exists(fileTarget))
            {
                ImportFileAsText(fileTarget, out imported);
            }
            else
            {
                string textToUse="";
                if(defaultTextToStore != null)
                    defaultTextToStore(out textToUse);
                CreateDirectoryIfNotThere(fileTarget);
                OverwriteFile(fileTarget, textToUse);
                imported = textToUse;
            }
        }
        public static void OverwriteOrCreateThenImportIn<T>(
            in I_PathTypeAbsoluteFileGet fileTarget,
            ref T jsonableTarget
            )
        {
            if (Exists(fileTarget) )
            {
                ImportFileAsText(fileTarget, out string imported);
                jsonableTarget = JsonUtility.FromJson<T>(imported);
            }
            else
            {
                string textToExport = JsonUtility.ToJson(jsonableTarget);
                OverwriteFile(fileTarget, textToExport);
            }
        }


        public static void GetPathArrayFromPathTypeFiles(
           in I_PathTypeAbsoluteFileGet[] files,
           out string[] filePaths)
        {
            filePaths = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i] != null)
                    filePaths[i] = "";
                else 
                    files[i].GetPath(out filePaths[i]);
            }
        }

        public static void OverwriteOrCreateThenImportIn<T>(
            in I_PathTypeAbsoluteFileGet fileTarget,
            ref T jsonableTarget,
            bool overwriteIfExisting = true)
        {
            string textToExport = JsonUtility.ToJson(jsonableTarget);
            if (!Exists(fileTarget) || (Exists(fileTarget) && overwriteIfExisting))
            {
                OverwriteFile(fileTarget, textToExport);
            }
            OverwriteOrCreateThenImportIn(fileTarget, ref jsonableTarget);
        }


    }

#endregion


    #region DELETE AND MOVE
    public static partial class AbsoluteTypePathTool
    {


        public static void Move(in I_PathTypeAbsoluteFileGet file, in I_PathTypeAbsoluteDirectoryGet directory)
        {
            if (Exists(file))
            {
                GetFileWithExtensionFrom(file, out I_PathTypeFileNameWithExtensionGet fileName);
                I_PathTypeAbsoluteFileGet newFile = TypePathCombineTool.Combine(in directory, in fileName);
                CreateDirectoryIfNotThere(newFile);
                File.Move(file.GetPath(), newFile.GetPath());
            }
        }


        public static void Move(in I_PathTypeAbsoluteFileGet file, I_PathTypeAbsoluteFileGet destination)
        {
            CreateDirectoryIfNotThere(destination);
            File.Move(file.GetPath(), destination.GetPath());
        }
        public static void Move(in I_PathTypeAbsoluteDirectoryGet directory, in I_PathTypeAbsoluteDirectoryGet destination)
        {
            CreateDirectoryIfNotThere(destination);
            Directory.Move(directory.GetPath(), destination.GetPath());
        }
        public static void Delete(in I_PathTypeAbsoluteDirectoryGet directory)
        {
            string path = directory.GetPath();
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }
        public static void Delete(in I_PathTypeAbsoluteFileGet file)
        {
            string path = file.GetPath();
            if (File.Exists(path))
                File.Delete(path);
        }

        public static void OverwriteMove(in I_PathTypeAbsoluteFileGet from, in I_PathTypeAbsoluteFileGet to, out bool succedTransfert)
        {
            succedTransfert = false;

            if (AbsoluteTypePathTool.Exists(to))
            {
                try
                {
                    AbsoluteTypePathTool.Delete(to);
                }
                catch { }
            }

            if (AbsoluteTypePathTool.Exists(from))
            {
                try
                {
                    AbsoluteTypePathTool.Move(from, to);
                    succedTransfert = true;
                }
                catch { }
            }

        }


    }
    #endregion
    #region CREATE IF NOT THERE
    public static partial class AbsoluteTypePathTool
    {
        public static void CreateFileIfNotThere(in I_PathTypeAbsoluteFileGet path, in string text)
        {
            if (!Exists(path))
            {
                OverwriteFile(path, text);
            }
        }
        public static void CreateFileIfNotThere(in I_PathTypeAbsoluteFileGet path, in byte[]  bytes)
        {
            if (!Exists(path))
            {
                OverwriteFile(path, bytes);
            }
        }
        
    }


    #endregion
    #region IS EXISTING PATH
    public static partial class AbsoluteTypePathTool
    {

        public static bool Exists(in I_PathTypeAbsoluteFileGet path)
        {
            return File.Exists(path.GetPath());
        }
        public static bool Exists(in I_PathTypeAbsoluteDirectoryGet path)
        {
            return Directory.Exists(path.GetPath());
        }
        public static bool DontExists(in I_PathTypeAbsoluteFileGet path)
        {
            return !File.Exists(path.GetPath());
        }
        public static bool DontExists(in I_PathTypeAbsoluteDirectoryGet path)
        {
            return !Directory.Exists(path.GetPath());
        }
    }
    #endregion

    #endregion
   

    #region OVERWRITE FILE BASIC TYPE
    public static partial class AbsoluteTypePathTool
    {
        public static void OverwriteFile(in I_PathTypeAbsoluteFileGet file, in string text)
        {
            if(text == null)
                return;
            CreateDirectoryIfNotThere(file);
            File.WriteAllText(file.GetPath(), text);
        }
        public static void OverwriteFile(in I_PathTypeAbsoluteFileGet file, in byte[] bytes)
        {
            if (bytes == null)
                return;
            CreateDirectoryIfNotThere(file);
            File.WriteAllBytes(file.GetPath(), bytes);
        }
    }
    #endregion

    #region OVERWRITE APPEND
    public static partial class AbsoluteTypePathTool
    {
        public static void AppendStartOfFile(in I_PathTypeAbsoluteFileGet file, in string text)
        {
            CreateDirectoryIfNotThere(file);
            if (File.Exists(file.GetPath()))
            {
                string content = File.ReadAllText(file.GetPath());
                File.WriteAllText(file.GetPath(), text + content);
            }
            else
            {
                File.WriteAllText(file.GetPath(), text);
            }
        }
        public static void AppendEndOfFile(in I_PathTypeAbsoluteFileGet file, in string text)
        {
            CreateDirectoryIfNotThere(file);
            if (File.Exists(file.GetPath()))
            {
                string content = File.ReadAllText(file.GetPath());
                File.WriteAllText(file.GetPath(), content + text);
            }
            else
            {
                File.WriteAllText(file.GetPath(), text);
            }
        }
        public static void AppendEndOfFile(in I_PathTypeAbsoluteFileGet file, in byte[] bytes)
        {
            E_CodeTag.QualityAssurance.TestedState(E_CodeTag.QualityAssurance.TestedStateType.NotAtAllButShould);
            CreateDirectoryIfNotThere(file);
            File.WriteAllBytes(file.GetPath(), bytes);
            if (File.Exists(file.GetPath()))
                {
                byte[] fileContent = File.ReadAllBytes(file.GetPath());
                byte[] newContent = new byte[fileContent.Length + bytes.Length];
                fileContent.CopyTo(newContent, 0);
                bytes.CopyTo(newContent, fileContent.Length);
                File.WriteAllBytes(file.GetPath(), newContent);
            }
            else
            {
                File.WriteAllBytes(file.GetPath(), bytes);
            }
        }
        public static void AppendStartOfFile(in I_PathTypeAbsoluteFileGet file, in byte[] bytes)
        {
            E_CodeTag.QualityAssurance.TestedState(E_CodeTag.QualityAssurance.TestedStateType.NotAtAllButShould);
            CreateDirectoryIfNotThere(file);
            File.WriteAllBytes(file.GetPath(), bytes);
            if (File.Exists(file.GetPath()))
            {
                byte[] content = File.ReadAllBytes(file.GetPath());
                byte[] newContent = new byte[content.Length + bytes.Length];
                bytes.CopyTo(newContent, 0);
                content.CopyTo(newContent, bytes.Length);
                File.WriteAllBytes(file.GetPath(), newContent);
            }
            else
            {
                File.WriteAllBytes(file.GetPath(), bytes);
            }
        }
    }
    #endregion



    public static partial class AbsoluteTypePathTool {


        public static void ImportFileAsText(in I_PathTypeAbsoluteFileGet file, out string text)
        {
            if (Exists(file))
                text = File.ReadAllText(file.GetPath());
            else
                text = "";
        }
        public static void ImportFileAsBytes(in I_PathTypeAbsoluteFileGet file, out byte[] bytes)
        {
            if (Exists(file))
                bytes = File.ReadAllBytes(file.GetPath());
            else
                bytes = new byte[0];
        }

        public static void IsContentAreNotEquals(in I_PathTypeAbsoluteFileGet a, in I_PathTypeAbsoluteFileGet b, out bool areNotEqual, bool ignoreCase = false, bool useTrim = true)
        {
            IsContentAreEquals(a, b, out bool areEqualsValue, ignoreCase, useTrim);
            areNotEqual = !areEqualsValue;
        }
        public static void IsContentAreEquals(I_PathTypeAbsoluteFileGet a, I_PathTypeAbsoluteFileGet b, out bool areEquals, bool ignoreCase = false, bool useTrim = true)
        {
            if (a == null || b == null || AbsoluteTypePathTool.DontExists(a) || AbsoluteTypePathTool.DontExists(b))
            {
                areEquals = false;
                return;
            }
            ImportFileAsText(a, out string textA);
            ImportFileAsText(b, out string textB);
            areEquals = PathTypeStringUtility.AreEquals(textA, textB, ignoreCase, useTrim);
        }

        public static void IsContentByteAreNotEquals(in I_PathTypeAbsoluteFileGet a, in I_PathTypeAbsoluteFileGet b, out bool areNotEqual)
        {
            IsContentByteAreEquals(a, b, out bool areEqualsValue);
            areNotEqual = !areEqualsValue;
        }
        public static void IsContentByteAreEquals(in I_PathTypeAbsoluteFileGet a, in I_PathTypeAbsoluteFileGet b, out bool areEquals)
        {
            if (a == null || b == null || AbsoluteTypePathTool.DontExists(a) || AbsoluteTypePathTool.DontExists(b))
            {
                areEquals = false;
                return;
            }
            ImportFileAsBytes(a, out byte[] bytesA);
            ImportFileAsBytes(b, out byte[] bytesB);
            Hash128 hashA = Hash128.Compute(bytesA);
            Hash128 hashB = Hash128.Compute(bytesB);
            areEquals = hashA == hashB;
        }

        public static void SplitInfo(in I_PathTypeAbsoluteFileGet file, out I_PathTypeAbsoluteDirectoryGet directoryFound, out I_PathTypeFileNameWithExtensionGet fileFound)
        {
            GetDirectoryFrom(in file, out directoryFound);
            GetFileWithExtensionFrom(in file, out fileFound);
        }

        public static void SplitInfoAsString(in I_PathTypeAbsoluteFileGet file, out string directoryPathOfFile, out string fileName, out string fileExtension)
        {
            if (file == null)
            {
                directoryPathOfFile = "";
                fileName = "";
                fileExtension = "";
                return;
            }
            GetDirectoryFrom(in file, out I_PathTypeAbsoluteDirectoryGet directoryFound);
            GetFileWithExtensionFrom(in file, out I_PathTypeFileNameWithExtensionGet fileFound);

            directoryFound.GetPath(out directoryPathOfFile);
            fileFound.GetFileNameWithoutExtension(out fileName);
            fileFound.GetExtensionWithoutDot(out fileExtension);


        }
        public static void GetDirectoryFrom(in I_PathTypeAbsoluteFileGet file,
            out I_PathTypeAbsoluteDirectoryGet directory)
        {
            directory = new PathTypeAbsoluteDirectory(Path.GetDirectoryName(file.GetPath()));
        }

        
        public static void GetFileWithExtensionFrom(
            in I_PathTypeAbsoluteFileGet filePath,
           out I_PathTypeFileNameWithExtensionGet fileName)
        {
            fileName = new FileNameWithExtension(Path.GetFileName(filePath.GetPath()));
        }
        public static IEnumerator LoadFileWithCoroutine(I_PathTypeAbsoluteFileGet file, Action<string> downloadedText)
        {

            string path = file.GetPath();
            if (File.Exists(path))
            {

                using (var www = new UnityWebRequest("file:///" + path))
                {
                    www.downloadHandler = new DownloadHandlerBuffer();
                    yield return www.SendWebRequest();
                    downloadedText.Invoke(www.downloadHandler.text);
                }
            }
        }

        public static void FilterWithSize(in I_PathTypeAbsoluteFileGet[] filesToFilter,
            out List<I_PathTypeAbsoluteFileGet> filesFound,
            in long minimumFileSize,
            in long maxFileSize)
        {
            filesFound = new List<I_PathTypeAbsoluteFileGet>();
            if (filesToFilter == null)
            {
                return;
            }
            for (int i = 0; i < filesToFilter.Length; i++)
            {
                if (AbsoluteTypePathTool.Exists(filesToFilter[i]))
                {
                    AbsoluteTypePathTool.GetFileSizeInBytes(filesToFilter[i], out long size);

                    if (size >= minimumFileSize && size <= maxFileSize)
                    {
                        filesFound.Add(filesToFilter[i]);
                    }
                }
            }
        }
        public static void GetFileSizeInBytes(in I_PathTypeAbsoluteFileGet file, out long size)
        {
            if(Exists(file))
                size = new FileInfo(file.GetPath()).Length;
            else 
                size = 0;
        }

        public static void GetAllfilesInDirectoryAndExploreChildrens(in I_PathTypeAbsoluteDirectoryGet m_targetDirectory, out I_PathTypeAbsoluteFileGet[] files)
        {

            GetAllfilesInDirectory(m_targetDirectory, out files, SearchOption.AllDirectories);
        }

        public static void GetAllfilesInDirectoryWithoutExploringChildrens(in I_PathTypeAbsoluteDirectoryGet m_targetDirectory, out I_PathTypeAbsoluteFileGet[] files)
        {
            GetAllfilesInDirectory(m_targetDirectory, out files, SearchOption.TopDirectoryOnly);
        }
        public static void GetAllfilesInDirectory(in I_PathTypeAbsoluteDirectoryGet m_targetDirectory, out I_PathTypeAbsoluteFileGet[] files, SearchOption search)
        {
            string directoryPath = m_targetDirectory.GetPath();
            if (Directory.Exists(directoryPath))
                files = Directory.GetFiles(directoryPath, "*", search).Select(k => (I_PathTypeAbsoluteFileGet)new STRUCT_AbsoluteFilePath(k)).ToArray();
            else files = new I_PathTypeAbsoluteFileGet[0];
        }

    }


    #region OVERWRITE TEXTURE 2D
    public static partial class AbsoluteTypePathTool
    {



        public static void OverwriteTexture2D(in I_PathTypeAbsoluteFileGet filePath, Texture2D texture)
        {
            SplitInfoAsString(
                in filePath,
                out string directory,
                out string fileName, 
                out string fileExtension);
            fileExtension = fileExtension.Trim().ToLower();
            if (fileExtension == "png")
                OverwriteFileAsPNG(in filePath, texture );
            if (fileExtension == "tga")
                OverwriteFileAsTGA(in filePath, texture);
            if (fileExtension == "jpg" ||
                fileExtension == "jpeg")
                OverwriteFileAsJPEG(in filePath, texture);
        }

        public static void OverwriteFileAsPNG(in I_PathTypeAbsoluteFileGet file, in RenderTexture texture, bool mipChain, bool linear)
        {
            CopyRenderTextureToTexture2D(texture, out Texture2D texture2D, mipChain, linear);
            OverwriteFileAsPNG(file, texture2D);
            GameObject.DestroyImmediate(texture2D,true);
        }


        private static void CopyRenderTextureToTexture2D(RenderTexture renderTexture,out  Texture2D texture2D, bool mipChain, bool linear)
        {
            
            texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, mipChain,linear);
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();
            RenderTexture.active = null;

        }




        public static void OverwriteFileAsPNG(in I_PathTypeAbsoluteFileGet path, in Texture2D texture)
        {
           
                AbsoluteTypePathTool.OverwriteFile(path, texture.EncodeToPNG());
          
        }

        public static void OverwriteFileAsJPEG(in I_PathTypeAbsoluteFileGet path, in Texture2D texture)
        {
            
                AbsoluteTypePathTool.OverwriteFile(path, texture.EncodeToJPG());
             
        }
        public static void OverwriteFileAsTGA(in I_PathTypeAbsoluteFileGet path, in Texture2D texture)
        {
           
                AbsoluteTypePathTool.OverwriteFile(path, texture.EncodeToTGA());
             
        }


        public static void ImportTextureFromPNG(in I_PathTypeAbsoluteFileGet path, out Texture2D texture)
        {
           ImportTexture(path, out texture);
        }
        public static void ImportTextureFromJPEG(in I_PathTypeAbsoluteFileGet path, out Texture2D texture)
        {
            ImportTexture(path, out texture);
        }
        public static void ImportTextureFromTGA(in I_PathTypeAbsoluteFileGet path, out Texture2D texture)
        {
            ImportTexture(path, out texture);
        }
        public static void ImportTexture(in I_PathTypeAbsoluteFileGet filePath, out Texture2D texture)
        {
            filePath.GetPath(out string path);
            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
                texture.LoadImage(bytes);
            }
            else texture = null;
        }
    }
    #endregion


    public static partial class AbsoluteTypePathTool {
        static string m_emptyString = "";

        public static void CreateEmptyFile(in I_PathTypeAbsoluteFileGet file)
        {
            CreateDirectoryIfNotThere(file);
            File.WriteAllText(file.GetPath(), m_emptyString);
        }
        

        private static void GetDirectoryTypePathOf(in I_PathTypeAbsoluteFileGet file, out I_PathTypeAbsoluteDirectoryGet directory)
        {
            STRUCT_AbsoluteDirectoryPath structTempDirectoryPath = new STRUCT_AbsoluteDirectoryPath();
            structTempDirectoryPath.SetPath(Path.GetDirectoryName(file.GetPath()));
            directory = structTempDirectoryPath;
        }

        public static void CreateDirectoryIfNotThere(in I_PathTypeAbsoluteFileGet file)
        {
            GetDirectoryTypePathOf(file, out I_PathTypeAbsoluteDirectoryGet directory);
            CreateDirectoryIfNotThere(directory);
        }
        public static void CreateDirectoryIfNotThere(in I_PathTypeAbsoluteDirectoryGet directory)
        {
            string dir =directory.GetPath();
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
        public static void DeleteFile(in I_PathTypeAbsoluteFileGet file)
        {
            if (File.Exists(file.GetPath()))
                File.Delete(file.GetPath());
        }
        public static void CreateEmptyDirectory(in I_PathTypeAbsoluteDirectoryGet directory)
        {
            Directory.CreateDirectory(directory.GetPath());
        }

        
    }
}