using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacheObjectIndex
{
    public const int None = 0;
    public const int CardProto = 1;
    public const int SkillProto = 2;
    public const int MainCardProto = 3;
}

public class CacheManager : SingletonData<CacheManager>
{
    private Dictionary<int, Stack<object>> objStack;
    private GameObject cacheObject;
    enum ResourceType
    {
        Prefab,Animator
    }
    
    static Dictionary<int, ResourceType> ResourceTypes = new Dictionary<int, ResourceType>()
    {
        {CacheObjectIndex.CardProto, ResourceType.Prefab},
        {CacheObjectIndex.SkillProto, ResourceType.Prefab},
        {CacheObjectIndex.MainCardProto, ResourceType.Prefab},
    };
    
    static Dictionary<int, string> prafabPath = new Dictionary<int, string>()
    {
        {CacheObjectIndex.CardProto,  "Prefabs/UI/Parts/CardProto"},
        {CacheObjectIndex.SkillProto, "Prefabs/UI/Parts/SkillNameText"},
        {CacheObjectIndex.MainCardProto, "Prefabs/UI/Parts/MainCardProto"},
    };
    
    protected override void OnInit()
    {
        this.cacheObject = new GameObject("cacheObject");
        GameObject.DontDestroyOnLoad(this.cacheObject);
        this.cacheObject.SetActive(false);
        
        this.objStack = new Dictionary<int, Stack<object>>();

    }

    public void start()
    {
    }

    public void stop()
    {
        foreach (var kvp in this.objStack) {
            foreach (var o in kvp.Value) {
                if (o is GameObject gObj) {
                    GameObject.DestroyImmediate(gObj);
                }
            }
        }
        this.objStack.Clear();
    }

    private object popObject(int index)
    {
        var objs = this.objStack.objectValue(index);
        if (objs == null) {
            objs = new Stack<object>();
            this.objStack[index] = objs;
        }

        if (objs.Count == 0) {
            //根据类型，创建Obj
            var type = ResourceTypes.objectValue(index);
            if (type == ResourceType.Prefab) {
                var cardProto = (GameObject) Resources.Load(prafabPath.objectValue(index));
                var o = UnityEngine.Object.Instantiate(cardProto);
                return o;
            }
            
            Debug.LogError("CacheManager没有设置对应类型:" + index);
            return new object();
        }

        return objs.Pop();
    }

    private void pushObject(int index, object obj)
    {
        var objs = this.objStack.objectValue(index);
        if (objs == null) {
            objs = new Stack<object>();
            this.objStack[index] = objs;
        }
        objs.Push(obj);
    }

    public GameObject popCardProto(Transform transform)
    {
        var obj = this.popObject(CacheObjectIndex.CardProto) as GameObject;
        if (obj == null) {
            return null;
        }
        obj.transform.SetParent(transform);
        obj.transform.setScale(transform.localScale);
        obj.transform.localPosition = new Vector3(0, -obj.GetComponent<RectTransform>().sizeDelta.y * 0.5f,0);
        obj.transform.localScale = Vector3.one;

        var canvasGroup = obj.GetComponent<CanvasGroup>();
        if (canvasGroup != null) {
            canvasGroup.alpha = 1;
        }
        
        var audio = obj.GetComponent<AudioSource>();
        if (audio != null) {
            GameObject.Destroy(audio);
        }
        
        obj.SetActive(true);
        obj.stopAllActions();
        return obj;
    }

    public void pushCardProto(GameObject obj)
    {
        obj.stopAllActions();
        obj.SetActive(false);
        obj.transform.SetParent(this.cacheObject.transform);
        obj.transform.localRotation = new Quaternion(0, 0, 0, 0);
        this.pushObject(CacheObjectIndex.CardProto, obj);
    }
    
    public GameObject popSkillProto(Transform transform)
    {
        var obj = this.popObject(CacheObjectIndex.SkillProto) as GameObject;
        obj.transform.SetParent(transform);
        obj.transform.setScale(transform.localScale);
        obj.transform.localPosition = Vector3.zero;
        obj.SetActive(true);
        obj.stopAllActions();
        return obj;
    }

    public void pushSkillProto(GameObject obj)
    {
        obj.stopAllActions();
        obj.SetActive(false);
        obj.transform.SetParent(this.cacheObject.transform);
        obj.transform.localRotation = new Quaternion(0, 0, 0, 0);
        this.pushObject(CacheObjectIndex.SkillProto, obj);
    }
    
    public GameObject popMainCardProto(Transform transform)
    {
        var obj = this.popObject(CacheObjectIndex.MainCardProto) as GameObject;
        obj.transform.SetParent(transform);
        obj.transform.setScale(transform.localScale);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;

        var canvasGroup = obj.GetComponent<CanvasGroup>();
        if (canvasGroup != null) {
            canvasGroup.alpha = 1;
        }
        
        var audio = obj.GetComponent<AudioSource>();
        if (audio != null) {
            GameObject.Destroy(audio);
        }
        
        obj.SetActive(true);
        obj.stopAllActions();
        return obj;
    }

    public void pushMainCardProto(GameObject obj)
    {
        obj.stopAllActions();
        obj.SetActive(false);
        obj.transform.SetParent(this.cacheObject.transform);
        obj.transform.localRotation = new Quaternion(0, 0, 0, 0);
        this.pushObject(CacheObjectIndex.MainCardProto, obj);
    }
}
