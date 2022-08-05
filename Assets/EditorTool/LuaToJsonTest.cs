using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LuaInterface;
using UnityEditor;
using UnityEngine;

public class LuaToJsonTest : EditorWindow
{
    private string fileName;
    [MenuItem("Tools/LuaToJson")]
    public static void luaToJsonWindow()
    {
        EditorWindow.GetWindow(typeof(LuaToJsonTest));
    }
    
    private void OnGUI()
    {
        GUILayout.Label("需要转换的lua文件");
        this.fileName = EditorGUILayout.TextField(this.fileName);

        if (GUILayout.Button("转换")) {
            this.convertLuaToJson();
        }
    }

    void convertLuaToJson()
    {
        Lua fileLua = new Lua();
        fileLua.DoFile(fileName + ".lua");
        var o = fileLua.GetTable("config");
        
        Lua convertLua = new Lua();
        convertLua.DoFile("lua2json.lua");
        LuaFunction convert = convertLua.GetFunction("convert");
        var obj = convert.Call(o);
    }
}
