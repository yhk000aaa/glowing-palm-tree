/*特效*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{
    //特效枚举
    public enum EfxType
    {
        LittleBlood,
        MIdBlood,
        StabBlood1,
        StabBlood2,
        StabBlood5s,

        BlockText,
        BlockBackHurtText,
        HurtText,
        DeadText,
        MyHurtText,
        MyDeadText,
        BreakBlockText,

        BlockText_chf,
        BlockBackHurtText_chf,
        HurtText_chf,
        DeadText_chf,
        MyHurtText_chf,
        MyDeadText_chf,

        BlockText_en,
        BlockBackHurtText_en,
        HurtText_en,
        DeadText_en,
        MyHurtText_en,
        MyDeadText_en,

        ChainLightning,//闪电链
    }

    //攻击流血类型的枚举-伤害特效用
    public enum AtkLookType
    {
        NoAtk = 0,
        Wave = 1,
        Stab = 2,
        Kick = 3,//盾击
    }

    public static class EfxPath
    {
        //特效文件夹路径
        public const string GameObject_EFX_PREFAB = "Prefabs/EFX/";

        //地面血迹资源文件夹路径
        public const string GameObject_FLOOR_BLOOD_PREFAB = "Prefabs/EFX/BloodFloor/";

        //文本飘字特效资源文件夹路径
        public const string GameObject_Efx_Text_PREFAB = "Prefabs/EFX/TextEfx/";

        //获取特效Prefab路径 by 枚举(resource文件夹下)
        public static string GetEfxPath(EfxType _efxType)
        {
            string _path = string.Empty;
            switch (_efxType)
            {
                case EfxType.LittleBlood: _path = GameObject_EFX_PREFAB + "LittleBlood"; break;
                case EfxType.MIdBlood: _path = GameObject_EFX_PREFAB + "MIdBlood"; break;
                case EfxType.StabBlood1: _path = GameObject_EFX_PREFAB + "StabBlood1"; break;
                case EfxType.StabBlood2: _path = GameObject_EFX_PREFAB + "StabBlood2"; break;
                case EfxType.StabBlood5s: _path = GameObject_EFX_PREFAB + "StabBlood5s"; break;

                case EfxType.BlockText: _path = GameObject_Efx_Text_PREFAB + "BlockText"; break;
                case EfxType.BlockBackHurtText:_path = GameObject_Efx_Text_PREFAB + "BlockBackHurtText"; break;                    
                case EfxType.HurtText: _path = GameObject_Efx_Text_PREFAB + "HurtText"; break;
                case EfxType.DeadText: _path = GameObject_Efx_Text_PREFAB + "DeadText"; break;
                case EfxType.MyHurtText: _path = GameObject_Efx_Text_PREFAB + "MyHurtText"; break;
                case EfxType.MyDeadText: _path = GameObject_Efx_Text_PREFAB + "MyDeadText"; break;
                case EfxType.BreakBlockText: _path = GameObject_Efx_Text_PREFAB + "BreakBlockText"; break;
                    
                case EfxType.BlockText_chf: _path = GameObject_Efx_Text_PREFAB + "BlockText_chf"; break;
                case EfxType.BlockBackHurtText_chf: _path = GameObject_Efx_Text_PREFAB + "BlockBackHurtText_chf"; break;
                case EfxType.HurtText_chf: _path = GameObject_Efx_Text_PREFAB + "HurtText_chf"; break;
                case EfxType.DeadText_chf: _path = GameObject_Efx_Text_PREFAB + "DeadText_chf"; break;
                case EfxType.MyHurtText_chf: _path = GameObject_Efx_Text_PREFAB + "MyHurtText_chf"; break;
                case EfxType.MyDeadText_chf:_path = GameObject_Efx_Text_PREFAB + "MyDeadText_chf"; break;
                    
                case EfxType.BlockText_en: _path = GameObject_Efx_Text_PREFAB + "BlockText_en"; break;
                case EfxType.BlockBackHurtText_en: _path = GameObject_Efx_Text_PREFAB + "BlockBackHurtText_en"; break;
                case EfxType.HurtText_en: _path = GameObject_Efx_Text_PREFAB + "HurtText_en"; break;
                case EfxType.DeadText_en: _path = GameObject_Efx_Text_PREFAB + "DeadText_en"; break;
                case EfxType.MyHurtText_en: _path = GameObject_Efx_Text_PREFAB + "MyHurtText_en"; break;
                case EfxType.MyDeadText_en: _path = GameObject_Efx_Text_PREFAB + "MyDeadText_en"; break;
                                       

                case EfxType.ChainLightning: _path = GameObject_EFX_PREFAB + "ChainLightning"; break;

                default:
                    Debug.Log("Not Find _efxType! _efxType: " + _efxType.ToString());
                    break;
            }
            return _path;
        }

        //随机获取地面血迹Prefab路径 by 枚举(resource文件夹下)
        public static string GetFloorEfxPath(bool _isBig)
        {
            string _path = string.Empty;
            int min = 1;
            int max = 8;
            if (_isBig)
            {
                _path = GameObject_FLOOR_BLOOD_PREFAB + "b" + (Random.Range(min, max)).ToString();
            }
            else
            {
                _path = GameObject_FLOOR_BLOOD_PREFAB + "s" + (Random.Range(min, max)).ToString();
            }
            return _path;
        }

        //随机获取面部血迹Prefab路径 by 枚举(resource文件夹下)
        public static string GetFaceEfxPath(bool _isBig)
        {
            string _path = string.Empty;
            int min = 1;
            int max = 5;
            if (_isBig)
            {
                _path = GameObject_FLOOR_BLOOD_PREFAB + "face_blood" + (Random.Range(min, max)).ToString();
            }
            else
            {
                _path = GameObject_FLOOR_BLOOD_PREFAB + "face_blood" + (Random.Range(min, max)).ToString();
            }
            return _path;
        }
    }
}
