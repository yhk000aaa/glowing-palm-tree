//文本csv表数据管理器
//只支持一键一值加载法

using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Scripting;
using System.Reflection;

namespace XHFrameWork
{
    //总数据，用于存储需要存档的数据内容
    public class MainData : Singleton<MainData>
    {
        //三组用于存储的数据类
        public ConfigData configData;
        //一系列即时数据
        //public Dictionary<int, Place> places;//地点
        //……

        //一系列固定数据

        //……

        public bool isKeyboardOrGamePad = true;//当前显示的是键鼠还是手柄


        #region 一系列初始化方法Init
        //主初始化方法
        public override void Init()
        {
            //初始化存档数据
            configData = new ConfigData();
            base.Init();

            //初始化即时数据
            ////InitPlaces();
            //……

            //初始化固定数据
            InitCardDatas();
        }


        //////子方法：初始化即时数据-地点
        ////public void InitPlaces()
        ////{
        ////    places = new Dictionary<int, Place>();
        ////    foreach (int key in ParmLib.Instance.GetKeyBook(EnumParmCsvType.PlaceParm).Keys)
        ////    {
        ////        if (key != 0)//key不能等于0（0为表头）
        ////        {
        ////            int iii = key;
        ////            places.Add(iii, new Place(iii));//逐个初始化地点数据
        ////            places[iii].saver = nowData.placesavers[iii];//地点的存档字典数据，此时覆盖到这边来
        ////        }
        ////    }
        ////}


        //……


        //子方法：初始化固定数据-卡牌原型数据
        public void InitCardDatas()
        {
            // cardProtoDatas = new Dictionary<int, CardData>();
            // foreach (int key in ParmLib.Instance.GetKeyBook(EnumParmCsvType.CardParm).Keys)
            // {
            //     if (key != 0)//key不能等于0（0为表头）
            //     {
            //         int iii = key;
            //         //逐个初始化对应的数据，并加入字典
            //         CardData thisData = new CardData(iii);
            //         cardProtoDatas.Add(iii, thisData);
            //     }
            // }
        }        
 
        //……
        #endregion

        #region 存档载入MainData的方法
        //重置方法：加载初始数据进主数据库（复用已有的Init）
        public void LoadInitDataIntoMainData()
        {
            Init();
            LoadSaverIntoMainData(SaveID.Config);//设置数据无需重置
            configData.save_level = 1;//强制手写关卡存档为1
            Debug.Log("强制手写关卡存档为1");
        }
        //读档方法：加载存档数据进主数据库
        public void LoadSaverIntoMainData(SaveID _saveID)
        {
            //将表读出来写入MainData

        }
        #endregion

        #region MainData存入存档的方法
        //MainData存入存档（含设置一起存）
        public void SaveMainDataIntoSaver()
        {
            SaveHandle.Instance.saveSaver(SaveID.AutoSave);
            SaveHandle.Instance.saveSaver(SaveID.BookSave);
            SaveHandle.Instance.saveSaver(SaveID.Config);
        }
        #endregion
    }

    //数据基础类（所有数据类都要继承它）
    public class BaseDataClass
    {
        public int id;

        //从数据表中初始化数据类
        public void GetClassByParm<T>(T thisClass,EnumParmCsvType _csvType, int _id) where T : BaseDataClass
        {
            if (_id == 0)
            {
                //id=0时是表头，读之会报错，因此提前中断
                return;
            }

            id = _id;
            Dictionary<int, string[]> dataDic =ParmLib.Instance.GetKeyBook(_csvType);

            for (int i = 1; i < dataDic[0].Length; i++)
            {
                string headName = dataDic[0][i];

                FieldInfo fieldInfo = this.GetType().GetField(headName);

                if (fieldInfo != null)
                {

                    headName.Replace("\t", "");//去除特殊符号-制表符
                    headName.Replace("\r", "");//去除特殊符号-回车符
                    headName.Replace("\n", "");//去除特殊符号-换行符

                    //Debug.Log(_csvType+"|"+ _id+"|"+i);

                    if (fieldInfo.FieldType == typeof(int))
                        fieldInfo.SetValue(this, int.Parse(dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(string)) {
                        fieldInfo.SetValue(this, dataDic[_id][i]); 
                    }
                    else if (fieldInfo.FieldType == typeof(float))
                        fieldInfo.SetValue(this, float.Parse(dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(bool))
                        fieldInfo.SetValue(this, int.Parse(dataDic[_id][i])==1);
                    else if (fieldInfo.FieldType == typeof(LanguageType))
                        fieldInfo.SetValue(this, (LanguageType)int.Parse(dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(CardType))
                        fieldInfo.SetValue(this, (CardType)int.Parse(dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(DeskEventType))
                        fieldInfo.SetValue(this, (DeskEventType)int.Parse(dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(SkillConditionType))
                        fieldInfo.SetValue(this, (SkillConditionType)int.Parse(dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(EffectTarget))
                        fieldInfo.SetValue(this, (EffectTarget)Enum.Parse(typeof(EffectTarget), dataDic[_id][i]));
                    else if (fieldInfo.FieldType == typeof(CostType))
                        fieldInfo.SetValue(this, (CostType)Enum.Parse(typeof(CostType), dataDic[_id][i]));
                    
                    else
                    {
                        Debug.LogWarning("fieldInfo.FieldType不存在，需要加枚举？FieldType：" + fieldInfo.FieldType);
                        fieldInfo.SetValue(this, dataDic[_id][i]);
                    }
                }
            }
        }

        public virtual T copy<T>() where T : BaseDataClass
        {
            var o = this.MemberwiseClone() as T;
            return o;
        }
    }

    //设置数据类
    public class ConfigData : BaseDataClass
    {
        public int musicValue;
        public int soundValue;
        public LanguageType language;
        public int save_level;

        //构造函数
        public ConfigData()
        {
            ParmLib.Instance.GetDataClass(this, EnumParmCsvType.ConfigInit, 1);
        }
    }
}