/*角色基本属性枚举*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{
    //角色属性类型枚举
    public enum EnumPropertyType : int
    {
        //存档内容
        B1_Level = 1,//等级
        
        //设置属性
        C1_musicValue = 10001,
        C2_soundValue=10002,
        C3_Language=10003,
    }
    
    //角色数据类型枚举
    public enum EnumActorDataType
    {
        None = 0,
        NowData,
        ForeverData,
        ConfigData
    }
}
