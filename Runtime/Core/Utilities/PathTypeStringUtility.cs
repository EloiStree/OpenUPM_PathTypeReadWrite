using System;
using System.Collections.Generic;

namespace Eloi
{
    public static class PathTypeStringUtility
    {


        public static void MeltPathTogether(out string metlPath, in string rootFolderPath, params string[] subFolders)
        {
            List<string> cleanPart = new List<string>();
            TrimAtEndSlashAndBackSlashIfThereAre(in rootFolderPath, out string rootPathTrimmed);
            cleanPart.Add(rootPathTrimmed);
            for (int i = 0; i < subFolders.Length; i++)
            {
                TrimSlashAndBackSlashIfThereAre(in subFolders[i], out string trimmed);
                cleanPart.Add(trimmed);

            }
            metlPath = string.Join("/", cleanPart);
            //Eloi.E_CodeTag.QualityAssurance.RequestTestingInTheFuture();
        }

        public static void TrimSlashAndBackSlashIfThereAre(in string rootPath, out string triRootPath)
        {
            TrimAtStartSlashAndBackSlashIfThereAre(in rootPath, out string trimmedAtStart);
            TrimAtEndSlashAndBackSlashIfThereAre(in trimmedAtStart, out triRootPath);
        }

        public static string RemoveFileExtension(string path)
        {
            int dotIndex = path.LastIndexOf('.');
            if (dotIndex < 0)
                return path;
            int slashIndex = path.Replace("\\", "/").LastIndexOf('/');
            if (dotIndex <= slashIndex)
                return path;
            PathTypeStringUtility.SplitInTwo(in path, dotIndex, out string left, out string right);
            return left;
        }

        public static void TrimAtEndSlashAndBackSlashIfThereAre(in string rootPath, out string trimRootPath)
        {
            trimRootPath = rootPath;
            if (rootPath == null || rootPath.Length <= 0)
            {
                return;
            }

            char c = rootPath[rootPath.Length - 1];
            if (c == '/' || c == '\\')
            {
                trimRootPath = rootPath.Substring(0, rootPath.Length - 1);
            }
        }

        public static void TrimAtStartSlashAndBackSlashIfThereAre(in string rootPath, out string trimRootPath)
        {
            trimRootPath = rootPath;
            if (rootPath == null || rootPath.Length <= 0)
            {
                return;
            }
            if (rootPath[0] == '/' || rootPath[0] == '\\')
                trimRootPath = rootPath.Substring(1);
        }



        public static void ReplaceAllSlashByBackslash(in string source, out string result)
        {
            result = source.Replace("/", "\\");

        }
        public static void ReplaceAllBackslashToSlash(in string source, out string result)
        {
            result = source.Replace("\\", "/");
        }

        public static bool AreNotEquals(in string a, in string b, in bool ignoreCase, in bool useTrim)
        {
            return !AreEquals(in a, in b, in ignoreCase, in useTrim);
        }
        private static bool m_true = true;
        public static bool AreEquals(in string a, in string b)
        {
            return AreEquals(in a, in b, in m_true, in m_true);
        }
        public static bool AreEquals(in string a, in string b, in bool ignoreCase, in bool useTrim)
        {

            if (a == null && b == null)
                return true;
            if ((a != null && b == null)
                || (a == null && b != null))
                return false;

            string ta = a.ToString(), tb = b.ToString();
            //if (!ignoreCase && !useTrim)
            //{
            //    return (a.Length == b.Length && a.IndexOf(b) == 0);
            //}
            //else {
            if (ignoreCase)
            {
                ta = ta.ToLower();
                tb = tb.ToLower();
            }
            if (useTrim)
            {
                ta = ta.Trim();
                tb = tb.Trim();
            }
            return (ta.Length == tb.Length && ta == tb);
            // return (ta.Length == tb.Length && ta .IndexOf( tb)==0);
            //}

            //return false;
        }

        public static bool IsFilled(in string text)
        {
            if (text == null)
                return false;
            if (text.Length <= 0)
                return false;
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            return true;
        }

        public static void SplitInTwo(in string text, in int charIndex, out string leftPart, out string rightPart)
        {
            if (!IsFilled(text) || text.Length < 1)
                throw new Exception("Text can't be null, empty or too short");
            if (charIndex < 0)
                throw new Exception("You need to give a index to split the text with");
            leftPart = text.Substring(0, charIndex);
            rightPart = text.Substring(charIndex + 1);
        }

        public static string SubstractRootPath(string root, string selection)
        {
            ReplaceAllBackslashToSlash(root, out root);
            ReplaceAllBackslashToSlash(selection, out selection);
            //Debug.Log("root:" + root + "\nselect:" + selection);
            string relative = selection.Replace(root, "");
            if (relative.Length > 0 && (relative[0] == '\\' || relative[0] == '/'))
                relative = relative.Substring(1);
            return relative;
        }
    }
}