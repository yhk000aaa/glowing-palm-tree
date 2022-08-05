#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

[CustomEditor(typeof(ReplaceTargetText))]

public class ConvertAnimationToAnimator : EditorWindow
{
    private static string sourcePath = "Assets/Resources/Card/card_anima";
    private static string targetPath = "Assets/Resources/Card/card_animator";

    // [MenuItem("Tools/Animation转Animator")]
    public static void PackLuaWindow()
    {
        if (Directory.Exists(sourcePath)) {
            DirectoryInfo directoryInfo=new DirectoryInfo(sourcePath);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*",SearchOption.AllDirectories);

            foreach (var info in fileInfos) {
                var name = info.Name;
                if (!name.EndsWith(".anim")) {
                    continue;
                }
                
                var n = name.Replace(".anim", string.Empty);

                if (n.Contains("t")) {
                    continue;
                }
                
                var ani = Resources.Load( "Card/card_anima/" + n) as AnimationClip;
                var aniCtrl = AnimatorController.CreateAnimatorControllerAtPathWithClip(targetPath + "/" + n + ".controller", ani);
            }
        }

        // var ani = Resources.Load("Res/C201ByTop") as AnimationClip;
        // var aniCtrl = AnimatorController.CreateAnimatorControllerAtPathWithClip("Assets/TestByTop/CCCC.controller", ani);
    }
}
#endif