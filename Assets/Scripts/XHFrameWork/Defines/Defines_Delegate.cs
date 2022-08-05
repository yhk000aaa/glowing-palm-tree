/*Global delegate 委托（信息事件）*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{
    //声明事件的委托类型-UI对象状态改变的事件
    public delegate void StateChangedEvent(object sender, EnumObjectState newState, EnumObjectState oldState);

    //委托-消息事件（暂空，实际运用时会压入对应方法）
    public delegate void MessageEvent(Message message);

    //委托-点击事件
    public delegate void OnTouchEventHandle(GameObject _listener, object _args, params object[] _params);

    //委托-常规事件
    public delegate void EventHandler();
}
