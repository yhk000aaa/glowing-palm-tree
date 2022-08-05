//参数csv表数据加载管理器

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;

namespace XHFrameWork
{
    public class ParmLib : Singleton<ParmLib>
    {
        Dictionary<EnumParmCsvType, Dictionary<int, string[]>> dicOpenParmCSVs = null;

        public override void Init()
        {
            dicOpenParmCSVs = new Dictionary<EnumParmCsvType, Dictionary<int, string[]>>();
        }

        public string GetInt(EnumParmCsvType CsvName, int ID, int turn)
        {
            return GetKeyBook(CsvName)[ID][turn];
        }

        //用表名取表内容
        public Dictionary<int, string[]> GetKeyBook(EnumParmCsvType CsvName)
        {
            if ((null != dicOpenParmCSVs) && (dicOpenParmCSVs.ContainsKey(CsvName)))
            {
                return dicOpenParmCSVs[CsvName];
            }
            {
                return OpenCSVAndTakeInDic(CsvName);
            }
        }

        //开表&加字典(int[]含首位key)
        public Dictionary<int, string[]> OpenCSVAndTakeInDic(EnumParmCsvType CsvName)
        {
            Dictionary<int, string[]> newKeybook;
            newKeybook = CsvRead(CsvName);

            if (newKeybook != null)
            {
                dicOpenParmCSVs.Add(CsvName, newKeybook);
            }
            else
            {
                throw new Exception("this Csv Load Failure!(Name is wrong? Csv file is empty? ) CsvName :" + CsvName.ToString());
            }
            return newKeybook;
        }

        //开表（重载1）
        public Dictionary<int, string[]> CsvRead(EnumParmCsvType CsvName)
        {
            string path = CsvPath.GetParmPath(CsvName);
            return CsvRead(CsvName, path);
        }

        //开表（根方法）
        public Dictionary<int, string[]> CsvRead(EnumParmCsvType CsvName, string path)
        {
            Dictionary<int, string[]> dic = new Dictionary<int, string[]>();
            string sr = Resources.Load(path).ToString();
            string[] list = sr.Split(Environment.NewLine.ToCharArray());

            foreach (string line in list)
            {
                if (line.Length>1)//信息条目需排除空行（0字符，安卓为1字符（换行符））
                {
                    string[] sArray = line.Split('\t');

                    //string[] iAy = new string[sArray.Length];
                    for (int a = 0; a < sArray.Length; a++)
                    {
                        int aaa = a;
                        if (sArray[aaa] == null || sArray[aaa].Length == 0)
                        {
                            sArray[aaa] = "0";
                        }
                    }
                    //Debug.Log(sArray[0]);
                    dic.Add(Convert.ToInt32(sArray[0]), sArray);
                }
            }
            return dic;
        }

        //关表&清字典
        public void ReleaseCSVAndTakeInDic(EnumParmCsvType CsvName)
        {
            if (null != dicOpenParmCSVs && dicOpenParmCSVs.ContainsKey(CsvName))
            {
                dicOpenParmCSVs[CsvName] = null;
                dicOpenParmCSVs.Remove(CsvName);
            }
        }

        //清空字典
        public void ReleaseCSVs()
        {
            if (null != dicOpenParmCSVs)
            {
                dicOpenParmCSVs = null;
                dicOpenParmCSVs.Clear();
            }
        }

        //从数据表中取出数据类
        public T GetDataClass<T>(T theClass, EnumParmCsvType _csvType, int _id) where T:BaseDataClass
        {
            if (_id == 0)
            {
                Debug.LogError("数据表取出类时，id不能为0（0为表头）");
                return null;
            }

            theClass.id = _id;
            Dictionary<int, string[]> dataDic = GetKeyBook(_csvType);

            for (int i = 1; i < dataDic[0].Length; i++)
            {
                string headName = dataDic[0][i];

                System.Reflection.FieldInfo fieldInfo =theClass.GetType().GetField(headName);

                if (fieldInfo != null)
                {

                    headName.Replace("\t", "");//去除特殊符号-制表符
                    headName.Replace("\r", "");//去除特殊符号-回车符
                    headName.Replace("\n", "");//去除特殊符号-换行符

                    if (fieldInfo.FieldType == typeof(int))
                        fieldInfo.SetValue(theClass, int.Parse(dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(string))
                        fieldInfo.SetValue(theClass, dataDic[_id][i]);
                    else if (fieldInfo.FieldType == typeof(float))
                        fieldInfo.SetValue(theClass, float.Parse(dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(LanguageType))
                        fieldInfo.SetValue(theClass, (LanguageType)int.Parse(dataDic[_id][i]));
                    else
                    {
                        Debug.LogWarning("fieldInfo.FieldType不存在，需要加枚举？FieldType：" + fieldInfo.FieldType);
                        fieldInfo.SetValue(theClass, dataDic[_id][i]);
                    }
                }
            }

            return theClass;
        }

    }
}