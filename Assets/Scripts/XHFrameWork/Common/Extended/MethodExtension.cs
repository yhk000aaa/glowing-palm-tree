// MethodExtension方法扩展，此处有一些新增的公共方法可用，一般为旧有默认方法的扩展

using System;
using UnityEngine;


namespace XHFrameWork
{
	static public class MethodExtension
	{
		//获取T类型的脚本，如果获取不到，就给对象加一个该类型的脚本；最终返回该脚本
		static public T GetOrAddComponent<T>(this GameObject go) where T : Component
		{
			T ret = go.GetComponent<T>();
			if (null == ret)
				ret = go.AddComponent<T>();
			return ret;
		}

	}
}

