using System;
using System.Collections.Generic;
using UnityEngine;

public partial class DataUtils
{
    Dictionary<string, NSObject> _objects;
    private Dictionary<string, RuntimeAnimatorController> _animators;
    private Dictionary<string, GameObject> tableBackObjects;
    void OnInitObject()
    {
        _objects = new Dictionary<string, NSObject>();
        _animators = new Dictionary<string, RuntimeAnimatorController>();
        tableBackObjects = new Dictionary<string, GameObject>();
    }

    public T getObject<T>(string name) where T : NSObject
    {
        UnityEngine.Debug.Log("DataUtils.getObject:" + name);
        NSObject o;
        if (!_objects.TryGetValue(name, out o)) {
            o = this.getActivator<T>(name);
            _objects[name] = o;
        }
        return o.shallowCopy() as T;
    }

    void objectClear()
    {
        UnityEngine.Debug.Log("objectClear.objects" + _objects.Count);
        _objects.Clear();
        _animators.Clear();
    }

    public RuntimeAnimatorController getAnimator(string aniName)
    {
        RuntimeAnimatorController o;
        if (!_animators.TryGetValue(aniName, out o)) {
            o = Resources.Load("Card/card_animator/" + aniName) as RuntimeAnimatorController;
            _animators[aniName] = o;
        }
        return o;
    }

    public GameObject getTableBackObject(string backName)
    {
        GameObject o;
        if (!tableBackObjects.TryGetValue(backName, out o)) {
            o = Resources.Load("Prefabs/SceneBack/" + backName) as GameObject;
            tableBackObjects[backName] = o;
        }
        return o;
    }
}
