using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;
using XHFrameWork;

public class DataBaseManager : SingletonData<DataBaseManager>
{
    public Dictionary<string, IDataHandler> dataHandlers;
    public Dictionary<string, IConfigHandler> configHandlers;
    public IDatabaseAccess databaseAccess;
    
    protected override void OnInit()
    {
        this.databaseAccess = new PlayerPrefAccess();
        this.dataHandlers = new Dictionary<string, IDataHandler>();
        this.configHandlers = new Dictionary<string, IConfigHandler>();
        
        //加载配置
        foreach (var moduleName in DataModule.ConfigModuleNameList) {
            var className = DataModule.DataHandlerClassNames.objectValue(moduleName);
            if (string.IsNullOrEmpty(className)) {
                continue;
            }
            var type = Type.GetType(className);
            var configHandler = type.getStaticProperty<IConfigHandler>("Instance");
            configHandler.LoadConfig();
            this.configHandlers[moduleName] = configHandler;
        }
        
        //加载数据
        foreach (var moduleName in DataModule.DataModuleNameList) {
            this.databaseAccess.addKey(moduleName);
        }

        foreach (var moduleName in DataModule.DataModuleNameList) {
            var className = DataModule.DataHandlerClassNames.objectValue(moduleName);
            if (string.IsNullOrEmpty(className)) {
                Debug.LogError("找不到目标配置的className");
                continue;
            }
            var type = Type.GetType(className);
            var dataHandler = type.getStaticProperty<IDataHandler>("Instance");
            var str = this.getValue(moduleName);
            if (string.IsNullOrEmpty(str)) {
                dataHandler.reloadData(null);
            }
            else {
                var dic = Json.Deserialize(str) as Dictionary<string, object>;
                dataHandler.reloadData(dic);
            }
            
            this.dataHandlers[moduleName] = dataHandler;
        }
    }

    public void start()
    {
    }

    public void update(float dt)
    {
        foreach (var dataHandler in this.dataHandlers) {
            if (dataHandler.Value.saveByUpdate) {
                var dic = dataHandler.Value.getCache();
                var str  = Json.Serialize(dic);
                this.databaseAccess.setValue(dataHandler.Key, str);
            }
        }
        
        this.databaseAccess.update(dt);
    }

    public void stop()
    {
        
    }

    public string getValue(string key)
    {
        return this.databaseAccess.getValue(key);
    }
}
