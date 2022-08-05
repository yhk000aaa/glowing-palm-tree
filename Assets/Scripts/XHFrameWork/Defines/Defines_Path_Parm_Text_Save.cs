/*设置*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{
    public enum EnumStoryFlagType { start, main, head, ing, end, fight }//文本段类型枚举
    public enum EnumConditionType//判断条件类枚举
    {
        none,fight, flag1, flag2, flag3, hpMax, hnMax, hp, hn, partCore, part1, part2, part3, part4, part5, part6, part7, part8, partEye, str, dex, per, wil, life, tishu, jiashu, wushu, fashu, qianshu, mishu, jiangxue, qixue, zongheng, yinyang, kanxue, yixue, shuofu, jiaoji, xiepo, yanshi
    }
    public enum EnumCompareType { none,@is, great_is ,great, less_is, less, not_is }//判断符号枚举

    public enum EnumEffectCondition
    {
        none, end, flag1, flag2, flag3, unlockplace, showStoryPic, fight, hpMax, hnMax, hp, hn, partCore, part1, part2, part3, part4, part5, part6, part7, part8, partEye, str, dex, per, wil, life, tishu, jiashu, wushu, fashu, qianshu, mishu, jiangxue, qixue, zongheng, yinyang, kanxue, yixue, shuofu, jiaoji, xiepo, yanshi, giveitem
    }


    public enum EnumArithmeticType { none, @is, plus, minus }//运算符号枚举

    #region 各个CSV枚举
    //文本表格类型枚举
    public enum EnumStrCsvType
    {
        UIText = 0,   
    }

    //参数表格类型枚举
    public enum EnumParmCsvType
    {
        ConfigInit = 0,
    }

    //存档位枚举
    public enum SaveID
    {
        AutoSave= 0,
        Save1,
        Save2,
        Save3,
        BookSave,
        Config,
    }

    #endregion

    //表格资源路径获取
    public static class CsvPath
    {
        //存档路径
        public const string UI_SAVE_PATH = "/";
        //文本数据路径
        public const string UI_TEXT_PATH = "Data/Text/";
        //表格数据路径
        public const string UI_PARM_PATH = "Data/Parm/";

        //获取存档文件夹路径(persistentDataPath路径)
        public static string GetSaveFolderPath()
        {
            //string _pathstart = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string _pathstart = Application.persistentDataPath;
            return _pathstart + UI_SAVE_PATH;
        }

        //获取存档csv路径 by 文件名(persistentDataPath路径)
        public static string GetSavePath(SaveID saveid)
        {
            string _path = string.Empty;
            switch (saveid)
            {
                case SaveID.AutoSave:
                    _path = "AutoSave";
                    break;
                case SaveID.Save1:
                    _path = "Save1";
                    break;
                case SaveID.Save2:
                    _path = "Save2";
                    break;
                case SaveID.Save3:
                    _path = "Save3";
                    break;
                case SaveID.BookSave:
                    _path = "BookSave";
                    break;
                case SaveID.Config:
                    _path = "Config";
                    break;
                default:
                    Debug.Log("Not Find EnumUIType! type: " + saveid.ToString());
                    break;
            }
            _path = GetSaveFolderPath() + _path;
            return _path;
        }

        //获取文本csv路径 by 文件名(resource文件夹下)
        public static string GetStrPath(EnumStrCsvType filename)
        {
            string _path = string.Empty;
            switch (filename)
            {
                case EnumStrCsvType.UIText:_path = "UIText";break;

                default:
                    Debug.Log("Not Find EnumUIType! type: " + filename.ToString());
                    break;
            }
            _path = /*PathDecide.StreamingAssetsPath() + */UI_TEXT_PATH + Language.GetLanguagePath(MainData.Instance.configData.language) + _path  /*+ PATH_END*/;

            return _path;
        }

        //获取参数csv路径 by 文件名(resource文件夹下)
        public static string GetParmPath(EnumParmCsvType filename)
        {
            string _path = string.Empty;
            switch (filename)
            {                
                case EnumParmCsvType.ConfigInit:
                    _path = "ConfigInit";
                    break;

                default:
                    Debug.Log("Not Find EnumUIType! type: " + filename.ToString());
                    break;
            }
            _path = /*PathDecide.StreamingAssetsPath() + */UI_PARM_PATH + _path /*+ PATH_END*/;
            return _path;
        }
    }
}
