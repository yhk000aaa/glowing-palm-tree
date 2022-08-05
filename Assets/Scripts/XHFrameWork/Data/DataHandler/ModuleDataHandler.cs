using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;

public class DataModule
{
    public const string None = "none";
    public const string Card = "card";
    public const string Boat = "boat";

    //配置加载顺序
    public static List<string> ConfigModuleNameList = new List<string>()
    {
        Card, Boat
    };

    //数据加载顺序
    public static List<string> DataModuleNameList = new List<string>()
    {
    };
    
    public static Dictionary<string, string> DataHandlerClassNames = new Dictionary<string, string>()
    {
        {Card, "CardDataHandler"},
        {Boat, "BoatDataHandler"},
    };
}

public interface IDataHandler
{
    string module { get;}
    bool saveByUpdate { get;set; }
    void reloadData(Dictionary<string, object> parameters);
    void reloadDataByConfig();
    void reloadDataByData(Dictionary<string, object> parameters);
    Dictionary<string, object> toCache();
    Dictionary<string, object> getCache();
    void saveAction();
    void dropAction();
}