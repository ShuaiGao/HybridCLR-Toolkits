﻿using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

// Config.cs
//
// Author:
//   ldr123 (ldr12@163.com)
//

namespace Assets.Editor.Huatuo
{
    /// <summary>
    /// 这个类存放各种常量信息
    /// </summary>
    public static class Config
    {
        public static string UnityFullVersion = "";

        public static string IL2CPPManifestUrl = "";
        private static string ManifestBaseURL = "https://ldr123.github.io/release";
        public static string HuatuoManifestUrl = ManifestBaseURL + "/huatuo";
        private static readonly string WebSiteBase = "https://github.com/focus-creative-games/huatuo";
        public static readonly string WebSite = WebSiteBase;
        public static readonly string Document = WebSiteBase;
        public static readonly string Changelog = WebSiteBase;
        public static readonly string SupportedVersion = WebSiteBase + "/wiki/support_versions";

        private static readonly string EditorBasePath = EditorApplication.applicationContentsPath;
        public static readonly string HuatuoIL2CPPPath = EditorBasePath + "/il2cpp/libil2cpp";
        public static readonly string HuatuoPath = HuatuoIL2CPPPath + "/huatuo";
        public static readonly string HuatuoIL2CPPBackPath = EditorBasePath + "/il2cpp/libil2cpp_huatuo";
        public static readonly string HuatuoBackPath = HuatuoIL2CPPBackPath + "/huatuo";
        public static readonly string LibIl2cppPath = EditorBasePath + "/il2cpp/libil2cpp";
        public static readonly string LibIl2cppBackPath = EditorBasePath + "/il2cpp/libil2cpp_back";

        public static string DownloadCache = "";

        public static void Init()
        {
            IL2CPPManifestUrl = ManifestBaseURL + "/" + InternalEditorUtility.GetUnityVersionDigits();
            DownloadCache = Application.temporaryCachePath;
            UnityFullVersion = InternalEditorUtility.GetFullUnityVersion();
        }
    }
}
