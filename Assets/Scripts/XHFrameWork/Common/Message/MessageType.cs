// MessageType信息类型
//1.接收方在 信息中心 注册信息类型和对应的事件；
//2.发送方发送同类型名的信息给 信息中心；
//3.信息中心找到对应的接收方事件，并运行它。
//详细:
//1.信息接收方在OnAwake里增加监听，将监听信息注册到信息中心的字典集内，参数为 需要在消息中心注册的信息类型  和 信息处理方法
//				MessageCenter.Instance.AddListener(MessageType.Net_MessageTestOne, UpdateGold);
//（需配套在OnRelease里移除监听）
//				MessageCenter.Instance.AddListener(MessageType.Net_MessageTestOne, UpdateGold);

//2.信息发送方 创造信息内容，并通过指定正确的信息类型MessageType来确定要触发的事件
//例：Message message = new Message(MessageType.Net_MessageTestOne.ToString(), this);
//3.信息发送方 调用信息中心的发送信息来发送
//例：MessageCenter.Instance.SendMessage(message);

//4.信息中心获得信息发送方的MessageType和信息体，在字典集中找到对应的事件，并以信息体为参数，运行信息接收方的信息处理方法


using System;
namespace XHFrameWork
{
    public class MessageType
    {               
        //弹窗返回消息
        public static string PopupUIBack = "PopupUIBack";
        //刷新卡牌可交互情况的显示状态 to CardProto from CardProto
        public static string CardActStateCheck = "CardActStateCheck";
        //切换后处理效果 to PostProcess
        public static string PostProcessEvent = "PostProcessEvent";
        //Tip文本显示事件 to FightUI
        public static string ShowTipText = "ShowTipText";
        //退出战斗，退回开始界面 to FightUI
        public static string QuitFight = "QuitFight";
        //卡槽内卡变化，通知 to FightUI
        public static string SlotCardChanged = "SlotCardChanged";
        //锁定操作 to CardProto
        public static string LockOrUnlockAction = "LockOrUnlockAction";

        //测试消息Test
        public static string TestAdd = "TestAdd";
        public static string TestRemove = "TestRemove";



        //对话返回消息
        public static string TalkingUIBack = "TalkingUIBack";
        //指挥ALTStart移动镜头看向目标对象
        public static string MoveCamara = "MoveCamara";
        //摄像机震动
        public static string CamaraShake = "CamaraShake";
        //摄像机尺寸改变
        public static string CamaraSizeChange = "CamaraSizeChange";
        
        //键鼠/手柄显示切换消息
        public static string IsKeyboardOrGamePad = "IsKeyboardOrGamePad";

        //成就检查消息
        public static string AchievementCheck = "AchievementCheck";

    }
}

