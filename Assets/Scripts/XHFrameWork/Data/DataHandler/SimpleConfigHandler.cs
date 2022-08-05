using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;


public interface IConfigHandler
{
    void LoadConfig();
}

public abstract class ConfigHandler<T> : IConfigHandler where T : new()
{
    //配置相对路径
    protected string _configRelativeURL;
    protected virtual string rootPath => "Config/";
    //实例
    private static T _instance = new T();

    public static T Instance {get {return _instance;}}

    protected Dictionary<string,object> _config;

    //初始化抽象方法 需要子类去实现这个方法
    protected abstract void OnInit();
    /// <summary>
    /// Initializes a new instance of the <see cref="DataHandler"/> class.
    /// </summary>
    protected ConfigHandler()
    {
        OnInit();
    }

    /// <summary>
    /// Loads the config.
    /// </summary>
    public void LoadConfig()
    {
        UnityEngine.Debug.Log("init " + typeof(T));
        LoadConfig(_configRelativeURL);
    }

    /// <summary>
    /// Loads the config.
    /// </summary>
    /// <returns>The config.</returns>
    /// <param name="configRelativeURL">Config relative UR.</param>
    /// <typeparam name="A">The 1st type parameter.</typeparam>
    protected void LoadConfig(string configRelativeURL)
    {
        if (configRelativeURL == null)
        {
            return;
        }

        var text = Resources.Load<TextAsset>(this._configRelativeURL);
        
        this.OnLoadConfig(text);
    }
  
    /// <summary>
    /// Raises the load config event.
    /// </summary>
    protected virtual void OnLoadConfig(TextAsset textAsset)
    {
        _config = (Dictionary<string, object>) Json.Deserialize(textAsset.text) ;
    }
}

public class SimpleConfigHandler<A, C> : ConfigHandler<C> where A : NSConfigObject, new() where C : SimpleConfigHandler<A, C>, new()
{
    public A configRoot { get; private set; }

    public virtual string module => String.Empty;

    protected override void OnInit()
    {
        _configRelativeURL = rootPath + this.module;
    }

    protected override void OnLoadConfig(TextAsset textAsset)
    {
        base.OnLoadConfig(textAsset);

        this.configRoot = new A();
        this.configRoot.initialize(_config);
    }
}