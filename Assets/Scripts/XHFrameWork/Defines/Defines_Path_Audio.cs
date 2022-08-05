/*音频*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{
    #region Audio enum 声音类型枚举
    public enum EnumMusicType
    {
        None = 0,
        Place_Happiness = 1,
        Place_Memory = 2,
        Place_Relieved = 3,
        Place_Secret = 4,
        Place_Strange = 5,
        Event_Memory = 6,
        Event_Relieved = 7,
        Event_Sad = 8,
        Fight_Normal = 9,
        Fight_Hard = 10,
        Fight_Running = 11,
        Fight_Strange = 12,
        Fight_FateEnjoy = 13,

        StartView = 21,
        Think = 22,
        Fight = 23,

    }


    public class EnemSoundPara
    {
        public static Dictionary<string, EnumSoundType> SoundTypes = new Dictionary<string, EnumSoundType>()
        {
            {"UI_paper", EnumSoundType.UI_paper},
        };
    }

    public enum EnumSoundType
    {
        None = 0,

        //0UI
        UI_Open,
        UI_pause,
        UI_paper,
        UI_touch,

        //1-关卡流程相关音效
        A_level_completed,//关卡完成
        A_level_game_over,//关卡失败

        //2-事件音效
        B_Cry=2001,//惨叫
        B_Hurt=2002,//心脏受伤
        B_Heal,
        B_Eat,
        B_heart_beating,

        B_deal_card,
        B_check_card,//TODO：鼠标移入时候
        B_get_drag,//TODO
        B_get_item,
        B_hit_table,
        B_yell,
        B_keyboard_click,
        B_mind_logic,
        B_mind_secret,
        B_mind_action,
        B_whisper,

        //3-战斗音效
        F_block_metal_heavy,//TODO：
        F_kill,//受伤
        F_hurt_spear_stab,//TODO：

        //4-天气音效        
        W_forest_sound = 4001,//森林//TODO
        W_rain_indoor_sound,//雨-室内//TODO
        W_rain_outdoor_sound,//雨-室外//TODO
        W_sea_wind,//海风//TODO

        //5-其他音效
        B_tired_breath,//劳累状态的喘息声//TODO
    }
    #endregion

    //音频资源路径获取(resource文件夹下)
    public static class AudioPath
    {
        //音乐路径
        public const string Music_PATH = "Audio/Music/";
        //音效路径
        public const string Sound_PATH = "Audio/Sound/";

        //获取音乐路径 by 文件名
        public static string GetMusicPath(EnumMusicType filename)
        {
            string _path = string.Empty;
            switch (filename)
            {
                case EnumMusicType.None: _path = ""; break;

                ////////出自《Dexter》第一季OST
                ////case EnumMusicType.Place_Happiness: _path = "NewLegs"; break;
                ////case EnumMusicType.Place_Memory: _path = "House"; break;
                ////case EnumMusicType.Place_Relieved: _path = "Photos"; break;
                ////case EnumMusicType.Place_Secret: _path = "Match"; break;
                ////case EnumMusicType.Place_Strange: _path = "Wink"; break;
                ////case EnumMusicType.Event_Memory: _path = "NeedTime"; break;
                ////case EnumMusicType.Event_Relieved: _path = "Party"; break;
                ////case EnumMusicType.Event_Sad: _path = "DebCries"; break;
                ////case EnumMusicType.Fight_Normal: _path = "Ending"; break;
                ////case EnumMusicType.Fight_Hard: _path = "Fight"; break;
                ////case EnumMusicType.Fight_Running: _path = "Shipyard"; break;
                ////case EnumMusicType.Fight_Strange: _path = "Opening"; break;
                ////case EnumMusicType.Fight_FateEnjoy: _path = "Hidden"; break;


                //曲名：Warm of Mechanical Heart
                //作者：Kai Engel
                //---
                //曲名：Ancient Heavy Tech Donjon
                //作者：Komiku
                //---
                //类型：CC协议(可商用, 署名)
                //使用情况：未修改原始作品
                //来源：http://www.aigei.com/
                case EnumMusicType.StartView: _path = "Main(Warm of Mechanical Heart) by Kai Engel"; break;
                case EnumMusicType.Fight: _path = "Fight(Ancient Heavy Tech Donjon) by Komiku"; break;

                default:
                    Debug.Log("Not Find EnumMusic! type: " + filename.ToString());
                    break;
            }
            _path = Music_PATH + _path;
            return _path;
        }

        //获取音效路径 by 文件名
        public static string GetSoundPath(EnumSoundType filename)
        {
            string _path = string.Empty;
            switch (filename)
            {
                case EnumSoundType.None: _path = ""; break;

                //0UI
                case EnumSoundType.UI_Open: _path = "ui_base/collection_manager_book_page_flip_forward_1"; break;
                case EnumSoundType.UI_pause: _path = "ui_base/pause"; break;

                case EnumSoundType.UI_paper:
                    {
                        int i = Random.Range(1, 9);//返回一个随机整数，在min(包含)和max(不包含)之间
                        if (i <= 4)
                            _path = "ui_base/collection_manager_book_page_flip_back_" + i.ToString();
                        else
                            _path = "ui_base/collection_manager_book_page_flip_forward_" + (i - 4).ToString();
                    }
                    break;
                case EnumSoundType.UI_touch: _path = "ui_base/board_common_dirt_poke_" + Random.Range(1, 6).ToString(); break;

                //1关卡流程
                case EnumSoundType.A_level_completed: _path = "new_sounds/level_completed"; break;
                case EnumSoundType.A_level_game_over: _path = "new_sounds/level_game_over"; break;

                    
                //2事件音效                    
                case EnumSoundType.B_Cry: _path = "new_sounds/cry"; break;
                case EnumSoundType.B_Hurt: _path = "new_sounds/action_hurt"; break;
                case EnumSoundType.B_Heal: _path = "new_sounds/action_drink"; break;
                case EnumSoundType.B_Eat: _path = "new_sounds/action_eat"; break;
                case EnumSoundType.B_heart_beating: _path = "new_sounds/heart_beating"; break;
                case EnumSoundType.B_deal_card:_path = "new_sounds/deal_card"; break; 
                case EnumSoundType.B_check_card: _path = "new_sounds/card_move_in"; break; 
                case EnumSoundType.B_get_drag: _path = "new_sounds/get_drag"; break;
                case EnumSoundType.B_get_item:_path = "new_sounds/get_item" + Random.Range(1, 6).ToString() ;break;
                case EnumSoundType.B_hit_table: _path = "new_sounds/hit_table"; break;
                case EnumSoundType.B_yell: _path = "new_sounds/yell"; break;
                case EnumSoundType.B_keyboard_click: _path = "new_sounds/keyboard_click" + Random.Range(1, 5).ToString(); break;
                case EnumSoundType.B_mind_logic: _path = "new_sounds/mind_logic"; break;
                case EnumSoundType.B_mind_secret: _path = "new_sounds/mind_secret"; break;
                case EnumSoundType.B_mind_action:_path = "new_sounds/mind_action"; break;
                case EnumSoundType.B_whisper: _path = "new_sounds/mind_secret"; break;
                    

                //3战斗
                case EnumSoundType.F_block_metal_heavy: _path = "block_metal_heavy"; break;

                case EnumSoundType.F_kill:
                    switch (Random.Range(1, 3))
                    {
                        case 1: _path = "kill_heavy"; break;
                        case 2: _path = "kill_mid"; break;
                        default: _path = "kill_mid"; break;
                    }
                    break;
                case EnumSoundType.F_hurt_spear_stab: _path = "hurt_spear_stab" + Random.Range(1, 6).ToString(); break;

                //4天气
                case EnumSoundType.W_forest_sound: _path = "forest_sound"; break;
                case EnumSoundType.W_rain_indoor_sound: _path = "rain_indoor_sound"; break;
                case EnumSoundType.W_rain_outdoor_sound: _path = "rain_outdoor_sound"; break;
                case EnumSoundType.W_sea_wind: _path = "sea_wind"; break;

                //5其他
                case EnumSoundType.B_tired_breath: _path = "tired_breath"; break;

                default:
                    Debug.Log("Not Find EnumSound! type: " + filename.ToString());
                    break;
            }
            _path = Sound_PATH + _path;
            return _path;
        }
    }

}
