/*基础设置-路径对版本适配*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{

    #region config设置
    //语言类型
    public enum LanguageType
    {
        none=-1,
        CH=0,
        EN=1,
        //CHT=2,
        //JP =3,
    }
    public static class Language
    {
        //获取语言字段 by 枚举
        public static string GetLanguagePath(LanguageType _Type)
        {
            string _path = string.Empty;
            switch (_Type)
            {
                case LanguageType.CH:
                    _path = "ch/";
                    break;
                case LanguageType.EN:
                    _path = "en/";
                    break;
                default:
                    Debug.Log("Not Find LanguageType! _Type: " + _Type.ToString());
                    break;
            }
            return _path;
        }

        //获取语言名称 by 枚举
        public static string GetLanguageName(LanguageType _Type)
        {
            string _path = string.Empty;
            switch (_Type)
            {
                case LanguageType.CH:
                    _path = TextLib.Instance.GetString(44);
                    break;
                case LanguageType.EN:
                    _path = TextLib.Instance.GetString(45);
                    break;
                default:
                    Debug.Log("Not Find LanguageType! _Type: " + _Type.ToString());
                    break;
            }
            return _path;
        }
    }
    #endregion

    
    //路径对版本适配
    public static class PathDecide
    {
        public static string StreamingAssetsPath()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                //return Application.dataPath + "!/assets/";
                return Application.streamingAssetsPath+"/";
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return Application.dataPath + "/Raw/";
            }
            else
            {
                return "file:///"+Application.dataPath + "/StreamingAssets/";
            }
        }
    }
    
    public class Defines : MonoBehaviour
    {
        void Start()
        {
        }

        void Update()
        {
        }
    }
    
}
