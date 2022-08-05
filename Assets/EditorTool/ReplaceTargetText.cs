#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ReplaceTargetText))]

public class ReplaceTargetText : EditorWindow
{
    private string scenePath = "";
    private string sceneName = "Test";
    private string sourceText = "Plane";
    private string targetText = "default";
    
    // [MenuItem("Tools/批量转换场景gameObjName")]
    public static void PackLuaWindow()
    {
        var go = new GameObject("CCCCCCC");
         go.AddComponent<Animator>();
        
         PrefabUtility.CreatePrefab(Application.dataPath + "/" + go.name + ".prefab", go);
        EditorWindow.GetWindow(typeof(ReplaceTargetText));
    }
    
    private void OnGUI()
    {
        GUILayout.Label("输入scene路径");
        this.scenePath = EditorGUILayout.TextField(this.scenePath);
        
        GUILayout.Label("输入scene名称");
        this.sceneName = EditorGUILayout.TextField(this.sceneName);
        
        GUILayout.Label("输入需要替换的名字");
        this.sourceText = EditorGUILayout.TextField(this.sourceText);
        
        GUILayout.Label("输入目标名字");
        this.targetText = EditorGUILayout.TextField(this.targetText);
        
        if (GUILayout.Button("转换")) {
            Debug.LogError("转换" );
            
            this.convertAction();
        }
    }
    
    void convertAction()
    {
        var pathReader = Application.dataPath + this.scenePath + sceneName + ".unity";
        var pathWrite = Application.dataPath + this.scenePath + sceneName + "1" + ".unity";

        var sr = new StreamReader(pathReader);
        var sw = new StreamWriter(pathWrite);

        var count = 1;
        while (true) {
            var context = sr.ReadLine();
            if (context == null) {
                break;
            }
            
            if (!context.Contains(this.sourceText)) {
                sw.WriteLine(context);
                continue;
            }

            var ss = this.sourceText;
            var sp = context.Split(new[]{this.sourceText}, StringSplitOptions.None);
            ss += sp[1];

            string number = "0";
            foreach (var s in sp[1]) {
                int index = -999;
                if (int.TryParse(s.ToString(), out index)) {
                    number += index.ToString();
                }
            }
            
            var str = context.Replace(ss, this.targetText + "_" + number);
            sw.WriteLine(str);
            count++;
        }
        
        sw.Flush();
        sw.Close();
        sr.Close();
        File.Copy(pathWrite, pathReader, true);
        File.Delete(pathWrite);
    }
}
#endif