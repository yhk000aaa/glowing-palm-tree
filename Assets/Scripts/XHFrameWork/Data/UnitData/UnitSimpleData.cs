using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSimpleData <T> where T : new()
{
    public T config { get; private set; }
    public int id { get; private set; }
    public Dictionary<string, object> cacheData;

    public UnitSimpleData()
    {
        this.initialize();
    }

    public virtual void initialize()
    {
        this.cacheData = new Dictionary<string, object>();
    }

    public void reloadData(Dictionary<string, object> parameters, T config)
    {
        if (parameters == null) {
            this.reloadDataByConfig(config);
        }
        else {
            this.reloadDataByData(parameters, config);
        }
    }

    public virtual void reloadDataByConfig(T config)
    {
        this.config = config;
        if (this.config is NSConfigObject configObject) {
            this.id = configObject.id;
        }
    }

    public virtual void reloadDataByData(Dictionary<string, object> parameters, T config)
    {
        this.config = config;
        this.id = parameters.intValue("id");
    }

    public virtual Dictionary<string, object> toCache()
    {
        this.cacheData["id"] = this.id;
        return this.cacheData;
    }
    
    protected void loadUserDataByList<A, B>(Dictionary<string, object> parameters, string key, Dictionary<int, B> cds, IDictionary<int, A> ccs) where A : new() where B : UnitSimpleData<A>, new()
    {
        //解析已有的用户数据
        var list = parameters.listValue(key);
        if (list != null) {
            foreach (var c in list) {
                var cd = c.toDictionary();
                var cid = cd.intValue("id");
                A mcon = default(A);
                if (!ccs.TryGetValue(cid, out mcon)) {
                    continue;
                }
                var con = new B();
                con.reloadData(cd, mcon);
                cds[con.id] = con;
            }
        }

        //根据配置添加用户数据
        foreach (var kvp in ccs) {
            B con = null;
            if (cds.TryGetValue(kvp.Key, out con)) {
                continue;
            }
            con = new B();
            con.reloadData(null, kvp.Value);
            cds[con.id] = con;
        }

        //更新缓存
        this.cacheUserDataByList<A, B>(key, cds);
    }
    
    protected void loadUserDataByDict<A, B>(Dictionary<string, object> parameters, string key, Dictionary<int, B> cds, IDictionary<int, A> ccs) where A : new() where B : UnitSimpleData<A>, new()
    {
        //解析已有的用户数据
        var dict = parameters.dictionaryValue(key);
        if (dict != null) {
            foreach (var kvp in dict) {
                var cd = kvp.Value.toDictionary();
                var cid = kvp.Key.toInt();
                A mcon = default(A);
                if (!ccs.TryGetValue(cid, out mcon)) {
                    continue;
                }
                var con = new B();
                con.reloadData(cd, mcon);
                cds[con.id] = con;
            }
        }

        //根据配置添加用户数据
        foreach (var kvp in ccs) {
            B con = null;
            if (cds.TryGetValue(kvp.Key, out con)) {
                continue;
            }
            con = new B();
            con.reloadData(null, kvp.Value);
            cds[con.id] = con;
        }

        //更新缓存
        this.cacheUserDataByDict<A, B>(key, cds);
    }

    public void cacheUserDataByList<A, B>(string key, Dictionary<int, B> cds) where A : new() where B : UnitSimpleData<A>, new()
    {
        var list = new List<object>();
        foreach (var kvp in cds) {
            list.Add(kvp.Value.toCache());
        }
        this.cacheData[key] = list;
        this.toCache();
    }
    
    public void cacheUserDataByDict<A, B>(string key, Dictionary<int, B> cds) where A : new() where B : UnitSimpleData<A>, new()
    {
        var dict = new Dictionary<string, object>();
        foreach (var kvp in cds) {
            dict[kvp.Key.ToString()] = kvp.Value.toCache();
        }
        this.cacheData[key] = dict;

        this.toCache();
    }
}
