//文本csv表数据管理器
//只支持一键一值加载法

using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XHFrameWork
{
    public class TextLib : Singleton<TextLib>
    {
        Dictionary<EnumStrCsvType, Dictionary<int, string>> dicOpenStrCSVs = null;

        public override void Init()
        {
            dicOpenStrCSVs = new Dictionary<EnumStrCsvType, Dictionary<int, string>>();
        }

        //索引器必须是实例的，而本类是单例模式，所以所以这里用了报红（貌似是这个原因）
        #region 索引器红bug
        ////索引器：索引器对象为类本身（this），和属性类似使用set/get，但索引器可以传入参数
        //public object this[EnumStrCsvType key]
        //{
        //    //读取时，使用key在 数据字典集 中检索和返回对象，找不到则为空
        //    get
        //    {
        //        if (null == dicOpenStrCSVs || !dicOpenStrCSVs.ContainsKey(key))
        //            return GetKeyBook(key);
        //        return dicOpenStrCSVs[key];
        //    }
        //}
        #endregion

        #region 文本表的相关方法
        //取单个键值
        public string GetString(int ID)
        {
            if (GetKeyBook(EnumStrCsvType.UIText).ContainsKey(ID))
                return GetKeyBook(EnumStrCsvType.UIText)[ID];
            else
            {
                Debug.LogWarning("问题文本"+ID.ToString());
                return "问题文本"+ID.ToString();
            }
        }

        public string GetString(EnumStrCsvType CsvName, int ID)
        {
            return GetKeyBook(CsvName)[ID];
        }
        
        //用任务文本名拿取任务书
        public SortedList<int, string> GetStoryBook(EnumStrCsvType CsvName)
        {
            SortedList<int, string> a = new SortedList<int, string>();
            Dictionary<int, string> b=GetKeyBook(CsvName);
            foreach(KeyValuePair<int,string> i in b)
            {
            a.Add(i.Key,i.Value);
            }
            return a;
        }
        
        //用表名取表内容
        public Dictionary<int, string> GetKeyBook(EnumStrCsvType CsvName)
        {
            if ((null != dicOpenStrCSVs) && (dicOpenStrCSVs.ContainsKey(CsvName)))
            {
                return dicOpenStrCSVs[CsvName];
            }
            {
                return OpenCSVAndTakeInDic(CsvName);
            }
        }

        //开表&加字典
        private Dictionary<int, string> OpenCSVAndTakeInDic(EnumStrCsvType CsvName)
        {
            Dictionary<int, string> newKeybook/* = new Dictionary<int, string>()*/;
            newKeybook = null;
            newKeybook = CsvRead(CsvName);

            if (newKeybook != null)
            {
                dicOpenStrCSVs.Add(CsvName, newKeybook);
            }
            else
            {
                throw new Exception("this Csv Load Failure!(Name is wrong? Csv file is empty? ) CsvName :" + CsvName.ToString());
            }
            return newKeybook;
        }

        //开表（重载1）
        private Dictionary<int, string> CsvRead(EnumStrCsvType CsvName)
        {
            string path = CsvPath.GetStrPath(CsvName);
            return CsvRead(CsvName, path);
        }

        //开表（根方法）
        private Dictionary<int, string> CsvRead(EnumStrCsvType CsvName, string path)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            string sr = Resources.Load(path).ToString();
            string[] list = sr.Split(Environment.NewLine.ToCharArray());

            if (sr.Length == 0) { Debug.LogError("文件为空或编码不是UTF-8，未读出正常数据，需处理。Resource文件夹下:" + path); }

            foreach (string line in list)
            {
                string[] sArray = line.Split('\t');
                //读到的行不是空行时写入
                if (sArray.Length>=2)
                {
                    string thisText = "";
                    //把除id以外的其他文本合并成原本的一整条
                    for(int i=1;i<sArray.Length;i++)
                    {
                        if (i == 1)
                        { thisText += sArray[i]; }
                        else
                        { thisText += "	" + sArray[i]; }
                    }

                    dic.Add(int.Parse(sArray[0]), thisText);
                }
            }
            return dic;
        }

        //关表&清字典
        public void ReleaseCSVAndTakeInDic(EnumStrCsvType CsvName)
        {
            if (null != dicOpenStrCSVs && dicOpenStrCSVs.ContainsKey(CsvName))
            {
                dicOpenStrCSVs[CsvName] = null;
                dicOpenStrCSVs.Remove(CsvName);
            }
        }

        //清空字典
        public void ReleaseCSVs()
        {
            if (null != dicOpenStrCSVs)
            {
                //dicOpenStrCSVs = null;
                dicOpenStrCSVs.Clear();
            }
        }

        #endregion

        #region 替换关键词的相关方法
        //主方法
        public string CheckSpecalWord(string _line)
        {
            if (_line.Contains("$"))
            {
                string[] sArray = _line.Split('$');
                _line=null;
                foreach (string a in sArray)
                {
                    _line = _line +TryChange(a);
                }
            }
            return _line;
        }
        //小子方法：替换对应的文本
        private string TryChange(string _a)
        {
            switch (_a)
            {
                //case "p1.1":
                //    _a = (string)MainData._Instance.nowData.GetProperty(EnumPropertyType.B1_Name).Content;
                //        break;
                case "n":
                        _a = "\n";
                        break;
                case "-n":
                        _a = " ——————\n";
                        break;
                //    //当前模式获取
                //case "mode":
                //        _a = MainData._Instance.nowData.GetProperty(EnumPropertyType.B7_Mode).Content.ToString();
                //    break;
            }
            return _a;
        }

        //小方法：将A字符串中的B字符串替换为C字符串
        public string ReplaceStringBToStringCInStringA(string _a, string _b,string _c)
        {
            return _a.Replace(_b, _c);
        }
        //小方法：将A字符串中的B字符串去除掉
        public string DeleteStringBFromStringA(string _a, string _b)
        {
            return _a.Replace(_b, "");
        }
        #endregion
        
        //方法：添加删除线
        public void CreateDeleteLink(Text _text)
        {
            if (_text == null)
                return;

            //克隆Text，获得相同的属性  
            Text deleteline = GameObject.Instantiate(_text) as Text;
            deleteline.name = "Deleteline";

            deleteline.transform.SetParent(_text.transform);
            RectTransform rt = deleteline.rectTransform;

            //设置线坐标和位置  
            rt.anchoredPosition3D = Vector3.zero;
            rt.offsetMax = Vector2.zero;
            rt.offsetMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.anchorMin = Vector2.zero;
            rt.localScale = Vector3.one;

            deleteline.text = "—";
            float perlineWidth = deleteline.preferredWidth;      //单个下划线宽度  
            float width = _text.preferredWidth;
            int lineCount = (int)Mathf.Round(width / perlineWidth);
            for (int i = 1; i < lineCount; i++)
            {
                deleteline.text += "—";
            }
        }

    }
}