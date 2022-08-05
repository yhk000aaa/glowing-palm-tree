#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DeleteCacheData))]
public class DeleteCacheData : EditorWindow
{
    [MenuItem("Tools/清空缓存数据")]
    public static void ClearCacheData()
    {
        PlayerPrefs.DeleteAll();
    }
}

#endif