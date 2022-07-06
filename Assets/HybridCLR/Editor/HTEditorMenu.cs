using HybridCLR.Editor.BuildPipeline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace HybridCLR.Editor
{
    internal class HTEditorMenu
    {
        [MenuItem("HybridCLR/Manager...", false, 3)]
        public static void ShowManager()
        {
            var win = HTEditorManger.GetWindow<HTEditorManger>(true);
            win.titleContent = new GUIContent("HybridCLR Manager");
            win.ShowUtility();
        }
        [MenuItem("HybridCLR/Manager...", true)]
        public static bool CheckHybridCLR()
        {
            Menu.SetChecked("HybridCLR/Enable HybridCLR", HtBuildSettings.Instance.Enable);
            return true;
        }

        [MenuItem("HybridCLR/Enable HybridCLR", false, 5)]
        public static void EnableHybridCLR()
        {
            HtBuildSettings.ReverseEnable();
            HTEditorInstaller.Instance.DeleteCache();
        }

/*        [MenuItem("HybridCLR/卸载 0.1.x HybridCLR安装版本", false, 5)]
        public static void RemoveOldHybridCLR()
        {
            var HybridCLROldVersion = Path.Combine(Path.GetDirectoryName(EditorApplication.applicationPath), ".HybridCLR");
            if(File.Exists(HybridCLROldVersion))
            {
                File.Delete(HybridCLROldVersion);
            }

            if (Directory.Exists(HTEditorConfig.Libil2cppOritinalPath))
            {
                if (Directory.Exists(HTEditorConfig.Libil2cppPath))
                {
                    Directory.Delete(HTEditorConfig.Libil2cppPath, true);
                }
                HTEditorUtility.Mv(HTEditorConfig.Libil2cppOritinalPath, HTEditorConfig.Libil2cppPath);
            }
            else
            {
                EditorUtility.DisplayDialog("提示", "未找到使用HybridCLR tookit安装的备份文件", "ok");
                return;
            }

            EditorUtility.DisplayDialog("提示", "卸载完成！", "ok");
        }*/
    }
}
