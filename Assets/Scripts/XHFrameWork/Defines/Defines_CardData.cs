/*卡牌和卡组基础类*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{
    //枚举：槽名
    public enum SlotName
    {
        none = 0,//移入本槽视为销毁
        
        room1 = 10,
        room2 = 20,
        room3 = 30,
        room11 = 11,
        room21 = 21,
        room31 = 31,
        
        handL_empty = 1,
        handR_empty = 2,
        handL = 3,
        heart = 4,
        handR = 5,
        eyeL = 6,
        eyeR = 7,
        mouth = 8,
    }

    //枚举：卡牌类型
    public enum CardType
    {
        Enyone = -1,//任何
        Player = 0,//心脏
        Monster = 1,//危险
        Weapon_F = 2,//远程武器-原剑
        Chest = 3,//近战武器-原盾
        Drug = 4,
        Eye = 5,
        Mouth = 6,
        NPC = 7,//思维，回忆
        EmptyHand = 8,
    }

    //枚举：交互事件类型
    public enum CardEventType
    {
        None=0,
        Catch = 1,//裸手抓取
        SkillEvent=2,//技能事件
        Atk = 3,//攻击威胁
        BeAtked=4,//被攻击（手摸时……）
        Heal = 5,//使目标回复
        Destory = 6,//消灭目标
        NPC = 7,//与思维交互
        ChangeWeapon = 8,//增强目标
        EquipMouth = 9,//口装备替换
        EquipEyes = 10,//眼装备替换
    }

    //枚举：卡牌技能-条件类型
    public enum SkillConditionType
    {
        None=0,//C00-无触发条件 无

        Drag_instead=1,//C01-拖到特定目标时(取代原效果)  特定目标
        Drag_add = 2,//C02-拖到特定目标后(附带效果)   特定目标
        ByDeal=3,//C03-此卡上场时 无
        AnyDeal = 4,//C04-任何卡发牌时 新发的卡
        AnyBeKilled = 5,//C05-任何卡被消灭时 被消灭的卡
        AnyByEat = 6,//C6-有卡被吃掉时

        DoAtk = 11,//C11-此卡进行攻击时 特定目标
        DoHurt = 12,//C12-此卡造成伤害时（主动才生效） 特定目标
        DoKill = 13,//C13-此卡消灭目标时 特定目标
        ByAtk = 14,//C14-此卡被攻击时（扣点前）	攻击自己的卡
        ByHurt = 15,//C15-此卡受到伤害时（扣点后，主被动都生效）	伤害自己的卡
        BeforeByKill = 16,//C16-此卡被消灭前（变卡用） 消灭自己的卡
        ByKill = 17,//C17-此卡被消灭时 消灭自己的卡

        HeartBeAtked = 21,//C21-心脏被攻击时 心脏卡
        HeartChange = 22,//C22-心脏血量变化时 心脏卡
        /*wait*/GetPrice = 23,//C23-进入代价强化状态时 无
        AnyCardHurt = 24, //任何卡收到伤害
        AnyAction = 99//C99-发生任何行为时 无
    }

    //枚举：效果目标类型
    public enum EffectTarget
    {
        None=0,//无
        Self,//自己
        Interactor,//交互者
        InHand,//手持物
        Heart,//心脏
        Near,//相邻位
    }

    //枚举：支付条件类型
    public enum CostType
    {
        None = 0,
        LoseLife = 1,//支付卡牌耐久/次数
        LoseSkill = 2,//失去该卡效
    }

    //枚举：卡组事件类型
    public enum DeskEventType
    {
        Deal = 0,//发牌
        BlackMaskText = 1,//黑屏出字
        BlackMaskHide = 2,//黑屏淡入
        BlackMaskShow = 3,//黑屏淡出
        Talk = 4,//对话事件
        WarningText = 5,//悬屏文本
        TableType = 6,//更换桌布
        EndGameVedio=7,//结局视频
        DealEyeOrMouth = 8,//发双手

        DealDefaultFace = 101,//发脸-主脸镜头
        DealDefaultHeart = 102,//发心脏
        DealDefaultHands = 103,//发双手
    }
}