/*UI枚举&路径*/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{
    #region Global enum UI对象枚举

    // 对象当前状态 
    public enum EnumObjectState
    {
        //未知，初始化，加载中，加载完成，禁用，关闭中
        None,
        Initial,
        Loading,
        Ready,
        Disabled,
        Closing
    }

    // UI面板类型
    public enum EnumUIType : int
    {
        None = -1,
        StartUI,
        BattleUI,
    }

    //点击事件类型
    public enum EnumTouchEventType
    {
        OnClick,
        OnDoubleClick,
        OnDown,
        OnUp,
        OnEnter,
        OnExit,
        OnSelect,
        OnUpdateSelect,
        OnDeSelect,
        OnDrag,
        OnDragEnd,
        OnDrop,
        OnScroll,
        OnMove,
    }

    //弹出UI的显示位置（中/左/右……）
    public enum UI_pt_ShowType
    {
        None = 0,
        Normal,
        Left,
        Right,
    }
    #endregion 

    #region SubUI enum 子UI对象枚举（card/inbox）
    //卡片点击效果类型
    public enum EnumCardEventType : int
    {
        None = 0,
        NewGame,
        HomeEvent
    }    //文本台显示类型
    public enum EnumInboxType : int
    {
        None = 0,
        Text,
        Speak
    }

    //文字台的选项按钮类型    
    public enum EnumBtnChoice : int
    {
        Go_on = 0,
        ChoiceOne,
        ChoiceTwo,
        ChoiceThree,
        ChoiceFour
    }

    //Event转播的故事段落类型
    public enum EnumStoryPageType : int
    {
        Unkown = 0,
        Start,
        TextPage,
        SpeakPage,
        CardPage,
        CheckPage,
        BtnsPage,
        EventPage
    }

    #endregion

    #region 控制器按钮枚举
    public enum EnumCtrlerType : int
    {
        None = 0,
        Yes,
        No,//也就是Cancel/No
        Fire3,
        MouseL,
        Up,
        Down,
        Left,
        Right
    }
    #endregion

    #region UI资源路径获取（UIPrefab/UI脚本）
    public static class UIPath
    {
        //已经完工的UI
        public const string UI_FINISHED_PREFAB = "Prefabs/UI/";
        //开始游戏相关UI
        public const string UI_WaitToCheck_PREFAB = "Prefabs/UI/WaitToCheck/";
        // UI预设。
        public const string UI_PREFAB = "Prefabs/UI/";
        //  动态pic路径-DynamicPic路径
        public const string UI_DynamicPic_PATH = "Pic/";

        private static Dictionary<EnumUIType, string> UIPaths = new Dictionary<EnumUIType, string>()
        {
            {EnumUIType.StartUI,  UI_FINISHED_PREFAB + "StartUI"},
            {EnumUIType.BattleUI,  UI_FINISHED_PREFAB + "BattleUI"},
    };
        private static Dictionary<EnumUIType, Type> UIScripts = new Dictionary<EnumUIType, Type>()
        {
            {EnumUIType.StartUI,  typeof(StartUI)},
            {EnumUIType.BattleUI,  typeof(BattleUI)},
        };
        //获取Prefab路径 by UI类型(resource文件夹下)
        public static string GetUIPath(EnumUIType _uiType)
        {
            string _path = UIPaths.objectValue(_uiType);
            return _path;
        }

        //获取UI脚本类型（UI与脚本的对应关系）
        public static System.Type GetUIScript(EnumUIType _uiType)
        {
            System.Type _scriptType = UIScripts.objectValue(_uiType);
            return _scriptType;
        }    
    }
    #endregion
}