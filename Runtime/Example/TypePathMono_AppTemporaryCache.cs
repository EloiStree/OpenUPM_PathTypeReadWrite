using Eloi;
using System.IO;
using UnityEngine;

public class TypePathMono_AppTemporaryCache : A_PathTypeAbsoluteDirectoryMono
{
    public override string GetPath()
    {
        return Application.temporaryCachePath;
    }
}

public class TypePathMono_GitHubIssueStorage : A_PathTypeAbsoluteDirectoryMono
{
    public A_PathTypeAbsoluteDirectoryMono m_root;
    public string m_repository;
    public string m_user;
    public string m_issue;
    public override string GetPath()
    {
        return Path.Combine(m_root.GetPath(), "Issue", m_user, m_repository, m_issue);
        return Application.temporaryCachePath;
    }
}
