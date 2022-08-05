local config =  {
    category = {
        ["0"] = { config = "AbilityEffectConfig", },
        ["1"] = { config = "AbilityCritConfig", data = "AbilityCritObject", },
        ["2"] = { config = "AbilityCountConfig", data = "AbilityDotObject", },
        ["3"] = { config = "AbilityContinuousConfig", data = "AbilityContinuousObject", },
        ["4"] = { config = "AbilityConstantConfig", data = "AbilityConstantObject", },
        ["5"] = { config = "AbilitySputterConfig", data = "AbilitySputterObject", },
        ["6"] = { config = "AbilityCountConfig", data = "AbilityBounceObject", },
        ["7"] = { config = "AbilityCounterConfig", data = "AbilityCounterObject", },
        --加攻击力
        ["9"] = { data = "AbilityChangeAttackObject", },
        ["10"] = { data = "AbilityChangeHealthObject", },
        ["11"] = { config = "AbilityCountConfig", data = "AbilityWallBounceObject", },
        ["12"] = { config = "AbilitySpecialTrackConfig", data = "AbilitySpecialTrackObject", },
        ["13"] = { data = "AbilitySecondaryObject", },
        ["14"] = { config = "AbilityTimeConfig", data = "AbilitySlowObject", },
        ["15"] = { config = "AbilityInvincibleConfig", data = "AbilityInvincibleObject", },
        ["16"] = { data = "AbilityReduceDamageObject", },
        ["17"] = { data = "AbilityShieldObject", },
        ["18"] = { config = "AbilityHomingConfig", data = "AbilityHomingObject", },
        ["19"] = { config = "AbilitySecondaryConfig", data = "AbilitySecondary1Object", },
        ["20"] = { config = "AbilitySecondaryConfig", data = "AbilitySecondary2Object", },
        ["21"] = { config = "AbilityCountConfig", data = "AbilityHurtSecondaryObject", },
        ["22"] = { data = "AbilityUltraSecondaryObject", },
        ["23"] = { config = "AbilityHitSecondaryConfig", data = "AbilityHitSecondaryObject", },
        ["24"] = { config = "AbilityHeadSecondaryConfig", data = "AbilityHeadSecondaryObject", },
        ["25"] = { config = "AbilityAttackConfig", data = "AbilityHitAttackObject", },
        --天山爆头
        ["26"] = { config = "AbilityDizzyConfig", data = "AbilityHeadDizzyObject", },
        ["27"] = { config = "AbilityPierceConfig", data = "AbilityPierce1Object", },
        ["28"] = { config = "AbilityCritConfig", data = "AbilityUltraCritObject", },
        ["29"] = { config = "AbilityCritConfig", data = "AbilityHurtCritObject", },
        ["30"] = { config = "AbilityCountConfig", data = "AbilityHurtDotObject", },
        ["31"] = { config = "AbilityCritConfig", data = "AbilityPowerCritObject", },
        ["32"] = { config = "AbilityMarkCritConfig", data = "AbilityMarkCritObject", },
        ["33"] = { config = "AbilityCritConfig", data = "AbilityHitCritObject", },
        ["34"] = { config = "AbilityAngleConfig", data = "AbilityAngleObject", },
        ["35"] = { config = "AbilitySpeedUpConfig", data = "AbilitySpeedUpObject", },
        ["36"] = { config = "AbilityCountConfig", data = "AbilityHitBounceObject", },
        ["37"] = { config = "AbilityCountConfig", data = "AbilityHeadBounceObject", },
        ["38"] = { config = "AbilityCountConfig", data = "AbilityUltraBounceObject", },
        ["39"] = { config = "AbilityDamageConfig", data = "AbilityBounce1Object", },
        ["40"] = { config = "AbilityAreaDotConfig", data = "AbilityUltra6Object", },
        ["41"] = { config = "AbilityCdConfig", data = "AbilityUltraCdObject", },
        ["42"] = { data = "AbilityUltra2Object", },
        ["43"] = { data = "AbilityUltra3Object", },
        ["44"] = { config = "AbilityCountConfig", data = "AbilityUltra4Object", },
        ["45"] = { config = "AbilitySpeedUpConfig", data = "AbilityBulletSpeedUpObject", },
        ["46"] = { config = "AbilityPowerSwordConfig", data = "AbilityPowerSwordObject", },
        ["47"] = { data = "AbilityIncreaseAttack1Object", },
        ["48"] = { config = "AbilityLengthenInvincibleConfig", data = "AbilityLengthenInvincibleObject", },
        ["49"] = { data = "AbilityInvincibleDeflectObject", },
        ["50"] = { config = "AbilityCritConfig", data = "AbilityHeadCritObject", },
        ["51"] = { data = "AbilityRecoveryCritObject", },
        ["52"] = { config = "AbilityCritConfig", data = "AbilityReCritObject", },
        ["53"] = { config = "AbilityCountConfig", data = "AbilityHitSecondary1Object", },
        ["54"] = { config = "AbilityDamageConfig", data = "AbilitySecondary3Object", },
        --受伤弹射
        ["55"] = { config = "AbilityDamageConfig", data = "AbilityHurtBounceObject", },
        --反弹伤害
        ["56"] = { data = "AbilityReboundObject", },
        --过关加攻击
        ["57"] = { config = "AbilityAttackPassConfig", data = "AbilityAttackPassObject", },
        --残血加攻击
        ["58"] = { config = "AbilityAttackRageConfig", data = "AbilityRageAttackObject", },
        --落地攻击
        ["59"] = { data = "AbilityAttackLandObject", },
        --自动防御
        ["60"] = { config = "AbilityAutoDefConfig",data = "AbilityAutoDefObject"},
        --斩杀
        ["61"] = { config = "AbilityExecuteConfig",data = "AbilityExecuteObject"},
        --自动攻击
        ["62"] = { config = "AbilityAutoHomingConfig", data = "AbilityAutoHomingObject", },
        --穿透
        ["63"] = { config = "AbilityPierceConfig", data = "AbilityPierce2Object", },
        --爆头涨内力
        ["64"] = { data = "AbilityHeadManaObject" },
        --拼刀涨内力
        ["65"] = { data = "AbilityHitManaObject" },
        --范围攻击
        ["66"] = { config = "AbilityAreaDotConfig", data = "AbilityAreaDotObject", },
        --变小变大
        ["67"] = { data = "AbilitySizeObject", },
        --拼刀扣血
        ["71"] = { data = "AbilityHitHurtObject", },
        --额外复活
        ["72"] = { config = "AbilityCountConfig", data = "AbilityExtraReviveObject", },
        --无法爆头
        ["73"] = { data = "AbilityDisableHeadObject", },
        --爆头伤害增加50%
        ["74"] = { data = "AbilityHeadAttack1Object", },
        --无法使用大招
        ["75"] = { data = "AbilityDisableUltraObject", },
        --大招伤害增加50%
        ["76"] = { data = "AbilityUltra5Object", },
        --伤害增加20%
        ["79"] = { data = "AbilityDamageObject", },
        --爆头概率加50%
        ["81"] = { config = "AbilityHeadShotConfig", data = "AbilityHeadShot1Object", },
        --大招无敌
        ["82"] = { config = "AbilityInvincibleConfig", data = "AbilityUltraInvincibleObject", },
        --爆头无敌
        ["83"] = { config = "AbilityInvincibleConfig", data = "AbilityHeadInvincibleObject", },
        --拼刀无敌
        ["84"] = { config = "AbilityInvincibleConfig", data = "AbilityHitInvincibleObject", },
        --受伤无敌
        ["85"] = { config = "AbilityInvincibleConfig", data = "AbilityHurtInvincibleObject", },
        --大招叠毒
        ["86"] = { config = "AbilityCountConfig", data = "AbilityUltraDotObject", },
        --爆头叠毒
        ["87"] = { config = "AbilityCountConfig", data = "AbilityHeadDotObject", },
        --拼刀叠毒
        ["88"] = { config = "AbilityCountConfig", data = "AbilityHitDotObject", },
        --无敌加攻
        ["89"] = { data = "AbilityInvincibleDamageObject", },
        --叠毒加伤
        ["90"] = { config = "AbilityAttackConfig", data = "AbilityDot1Object", },
        --小怪投降
        ["91"] = { data = "AbilityFoeSurrenderObject"},
        --我膨胀了
        ["94"] = { config = "AbilitySwellConfig", data = "AbilitySwellObject", },
        --再次装填
        ["92"] = { config = "AbilityProbabilityConfig", data = "AbilityReloadManaObject", },
        --爆毒
        ["93"] = { data = "AbilityDot2Object", },
        --天山大招，群控大招
        ["95"] = { config = "AbilityUltraDizzyConfig", data = "AbilityUltraDizzyObject", },
        --残影魅敌
        ["96"] = { config = "Ability96Config", data = "Ability96Object", },
        --拼多多
        ["97"] = { config = "AbilityHitMultConfig", data = "AbilityHitMultObject", },
        --葵花宝典
        ["98"] = { config = "AbilityCharmConfig", data = "AbilityCharmObject", },
        --瞄准大招
        ["99"] = { data = "Ability99Object", },
        --蓄力回复大招
        ["100"] = { config = "AbilityChargeConfig", data = "AbilityCharge1Object", },
        --改变大招子弹
        ["101"] = { config = "AbilityRuneBulletConfig", data = "AbilityRuneBulletObject"} ,
        --蓄力群伤
        ["102"] = { config = "AbilityChargeConfig", data = "AbilityCharge2Object", },

        --天山普攻
        ["103"] = { config = "AbilityDizzyConfig", data = "AbilityNormalDizzyObject", },
        --天山拼刀
        ["104"] = { config = "AbilityDizzyConfig", data = "AbilityHitDizzyObject", },
        --眩晕延长
        ["105"] = { config = "AbilityDizzyConfig", data = "AbilityExtendDizzyObject", },
        --眩晕加伤
        ["106"] = { config = "AbilityDamageConfig", data = "AbilityPowerDizzyObject", },
        --顺手牵羊
        ["107"] = { config = "AbilityStealDizzyConfig", data = "AbilityStealDizzyObject", },

        --加暴击伤害
        ["108"] = { data = "AbilityChangeCritObject", },
        --加爆头伤害
        ["109"] = { data = "AbilityChangeHeadObject", },

        --小铁匠能力，30%几率涨大招
        ["130"] = { config = "AbilityProbabilityConfig", data = "AbilityUltra8Object", },
        --小铁匠能力，30%的几率纵向三发大宝剑
        ["131"] = { config = "AbilityChangeUltraConfig", data = "AbilityChangeUltraObject", },
        --峨眉跟踪剑
        ["132"] = { config = "AbilityNormalHomingConfig", data = "AbilityNormalHomingObject", },
        --开局弹射
        ["133"] = { config = "AbilityAttackCountConfig", data = "AbilityStartBounceObject", },
        --弹射造成额外伤害
        ["134"] = { data = "AbilityExtraBounceObject", },
        --开局剑气伤害
        ["135"] = { config = "AbilityAttackCountConfig", data = "AbilityStartSecondaryDamageObject", },
        --开局剑气
        ["136"] = { config = "AbilityDelayConfig", data = "AbilityStartSecondaryObject", },
        --开局暴击
        ["137"] = { config = "AbilityAttackCountConfig", data = "AbilityStartCritObject", },

        --无敌叠加攻击
        ["138"] = { config = "AbilityAttackConfig", data = "AbilityIncreaseInvincibleObject", },
        --弹射叠加伤害
        ["139"] = { config = "AbilityAttackConfig", data = "AbilityIncreaseBounceObject", },
        --剑气叠加伤害
        ["140"] = { config = "AbilityAttackConfig", data = "AbilityIncreaseSecondaryObject", },
        --眩晕叠加伤害
        ["141"] = { config = "AbilityAttackConfig", data = "AbilityIncreaseDizzyObject", },
        --暴击叠加伤害
        ["142"] = { config = "AbilityAttackConfig", data = "AbilityIncreaseCritObject", },
        --毒叠加攻击
        ["143"] = { config = "AbilityAttackConfig", data = "AbilityIncreaseDotObject", },
        --奇遇切换大招
        ["145"] = { config = "AbilityChangeUltraConfig", data = "AbilityChangeCurUltraObject", },
        --大招2轮变3轮
        ["146"] = { config = "AbilityCountConfig", data = "AbilityChangeUltra4Object", },

        --普攻
        ["147"] = { data = "AbilityNormalObject", },
        --大招
        ["148"] = { data = "AbilityUltraObject", },
        --爆头
        ["149"] = { data = "AbilityHeadObject", },

        --华山爆头眩晕
        ["152"] = { config = "AbilityHeadSecondaryConfig", data = "AbilityHeadBaseSecondaryObject", },

        --满血加攻
        ["167"] = { data = "AbilityFullHealthAttackObject", },
        --概率闪避
        ["168"] = { config = "AbilityProbabilityConfig", data = "AbilityDodgeObject", },
        --概率吸血
        ["169"] = { config = "AbilityProbabilityConfig", data = "AbilityVampireObject", },

        --回春术
        ["172"] = { config = "AbilityRecoveryConfig", data = "AbilityRecoveryObject", },
        ["173"] = { config = "AbilitySwordConfig", data = "AbilityDMSwordObject", },

        --试炼
        ["501"] = { config = "AbilityTrialConfig", data = "AbilityTrialObject", },
    },
    ability = {
        ----武当
        --加普功伤害
        ["147"] = { key = "normal", comment = "加普功伤害", category = 147, },
        --加大招伤害
        ["148"] = { key = "ultra", comment = "加大招伤害", category = 148, },
        --加爆头伤害
        ["149"] = { key = "head", comment = "加爆头伤害", category = 149, },

        ["1"] = { key = "normalCrit", comment = "普功暴击", category = 1, },
        ["28"] = { key = "ultraCrit", comment = "大招暴击", category = 28, },
        ["50"] = { key = "headCrit", comment = "爆头暴击", category = 50, },
        ["33"] = { key = "hitCrit", comment = "拼刀暴击", category = 33, },

        ["29"] = { key = "hurtCrit", comment = "受伤暴击", category = 29, },
        ["31"] = { key = "powerCrit", comment = "暴击加伤", category = 31, },
        ["52"] = { key = "reCrit", comment = "一暴再暴", category = 52, },

        ["9"] = { key = "increaseAttack", comment = "加攻击力", category = 9, },
        ["51"] = { key = "attack_9", comment = "暴击回血", category = 51, },
        ["32"] = { key = "attack_7", comment = "暴击标记", category = 32, },
        --暴击叠加伤害
        ["142"] = { key = "increaseCrit", comment = "暴击叠加伤害", category = 142, },

        ["108"] = { key = "critAttack", comment = "武当加攻击力", category = 9, },
        ["109"] = { key = "critCritDamage", comment = "武当加暴击伤害", category = 108, },
        ["110"] = { key = "critHeadDamage", comment = "武当加爆头伤害", category = 109, },
        --开局暴击
        ["137"] = { key = "startCrit", comment = "开局暴击", category = 137, },

        ----华山
        --加普功伤害
        ["150"] = { key = "normal", comment = "加普功伤害", category = 147, },
        --加大招伤害
        ["151"] = { key = "ultra", comment = "加大招伤害", category = 148, },
        --加爆头眩晕
        ["152"] = { key = "headBaseSecondary", comment = "加爆头眩晕", category = 152, },

        ["13"] = { key = "normalSecondary", comment = "普攻厄运", category = 13, },
        ["22"] = { key = "ultraSecondary", comment = "大招厄运", category = 22, },
        ["24"] = { key = "headSecondary", comment = "爆头厄运", category = 24, },
        ["23"] = { key = "hitSecondary", comment = "拼刀厄运", category = 23, },

        ["21"] = { key = "hurtSecondary", comment = "受伤厄运", category = 21, },
        ["19"] = { key = "powerSecondary", comment = "厄运提升", category = 19, },

        ["20"] = { key = "multiSecondary", comment = "厄运叠加", category = 20, },
        --拼刀施加剑气
        ["53"] = { key = "secondary_7", comment = "拼刀加厄运", category = 53, },
        --低血提剑气
        ["54"] = { key = "secondary3", comment = "低血提剑气", category = 54, },
        --剑气叠加伤害
        ["140"] = { key = "increaseSecondary", comment = "剑气叠加伤害", category = 140, },

        ["111"] = { key = "secondaryAttack", comment = "华山加攻击力", category = 9, },
        ["112"] = { key = "secondaryCritDamage", comment = "华山加暴击伤害", category = 108, },
        ["113"] = { key = "secondaryHeadDamage", comment = "华山加爆头伤害", category = 109, },
        --开局剑气伤害
        ["135"] = { key = "startSecondaryDamage", comment = "开局剑气伤害", category = 135, },
        --开局剑气
        ["136"] = { key = "startSecondary", comment = "开局剑气", category = 136, },


        ----少林
        --加普功伤害
        ["153"] = { key = "normal", comment = "加普功伤害", category = 147, },
        --加大招伤害
        ["154"] = { key = "ultra", comment = "加大招伤害", category = 148, },
        --加爆头伤害
        ["155"] = { key = "head", comment = "加爆头伤害", category = 149, },

        ["15"] = { key = "normalInvincible", comment = "普功无敌", category = 15, },
        ["82"] = { key = "ultraInvincible", comment = "大招无敌", category = 82, },
        ["83"] = { key = "headInvincible", comment = "爆头无敌", category = 83, },
        ["84"] = { key = "hitInvincible", comment = "拼刀无敌", category = 84, },
        --受伤无敌
        ["85"] = { key = "hurtInvincible", comment = "受伤无敌", category = 85, },
        ["89"] = { key = "powerInvincible", comment = "无敌加攻", category = 89, },
        ["16"] = { key = "reduceDamage", comment = "减伤", category = 16, },
        ["7"] = { key = "counter", comment = "玄冥神掌", category = 7, },
        ["10"] = { key = "increaseHealth", comment = "加血量上限", category = 10, },
        ["47"] = { key = "increaseAttack_2", comment = "血量加攻", category = 47, },
        ["56"] = { key = "rebound", comment = "反弹伤害", category = 56, },
        --无敌叠加攻击
        ["138"] = { key = "increaseInvincible", comment = "无敌叠加攻击", category = 138, },

        ["114"] = { key = "invincibleAttack", comment = "少林加攻击力", category = 9, },
        ["115"] = { key = "invincibleCritDamage", comment = "少林加暴击伤害", category = 108, },
        ["116"] = { key = "invincibleHeadDamage", comment = "少林加爆头伤害", category = 109, },

        --偏续航的新能力
        ["17"] = { key = "shield", comment = "护盾", category = 17, },
        ["170"] = { key = "health_1", comment = "血量提升(大)", category = 10, },
        ["171"] = { key = "health_2", comment = "血量提升(小)", category = 10, },
        ["172"] = { key = "recovery_1", comment = "回春术", category = 172, },
        ["173"] = { key = "dmsword", comment = "达摩飞剑", category = 173, },

        --桃花岛
        --加普功伤害
        ["156"] = { key = "normal", comment = "加普功伤害", category = 147, },
        --加大招伤害
        ["157"] = { key = "ultra", comment = "加大招伤害", category = 148, },
        --加爆头伤害
        ["158"] = { key = "head", comment = "加爆头伤害", category = 149, },

        ["6"] = { key = "normalBounce", comment = "普功弹射", category = 6, },
        ["38"] = { key = "ultraBounce", comment = "大招弹射", category = 38, },
        ["37"] = { key = "headBounce", comment = "爆头弹射", category = 37, },
        ["36"] = { key = "hitBounce", comment = "拼刀弹射", category = 36, },

        ["39"] = { key = "powerBounce", comment = "弹射加伤", category = 39, },
        ["59"] = { key = "attackLand", comment = "落地攻击", category = 59, },
        --受伤弹射
        ["55"] = { key = "hurtBounce", comment = "受伤弹射", category = 55, },
        ["11"] = { key = "wallBounce", comment = "台阶弹射", category = 11, },
        --弹射叠加伤害
        ["139"] = { key = "increaseBounce", comment = "弹射叠加伤害", category = 139, },

        ["117"] = { key = "bounceAttack", comment = "桃花岛加攻击力", category = 9, },
        ["118"] = { key = "bounceCritDamage", comment = "桃花岛加暴击伤害", category = 108, },
        ["119"] = { key = "bounceHeadDamage", comment = "桃花岛加爆头伤害", category = 109, },
        --开局弹射
        ["133"] = { key = "startBounce", comment = "开局弹射", category = 133, },
        --弹射造成额外伤害
        ["134"] = { key = "extraBounce", comment = "弹射额外伤害", category = 134, },

        --偏攻击的新能力
        ["165"] = { key = "attack_2", comment = "攻击力提升(大)", category = 9, },
        ["166"] = { key = "attack_3", comment = "攻击力提升(小)", category = 9, },
        ["167"] = { key = "fullHealthAttack", comment = "满血加攻", category = 167, },
        ["168"] = { key = "dodge", comment = "概率闪避", category = 168, },
        ["169"] = { key = "vampire", comment = "概率吸血", category = 169, },

        --峨眉
        ["3"] = { key = "continuous", comment = "攻击2次", category = 3, },
        --子弹提速
        ["45"] = { key = "bulletSpeedUp", comment = "子弹提速", category = 45, },
        ["35"] = { key = "speedUp", comment = "提速", category = 35, },
        --峨眉跟踪剑
        ["132"] = { key = "extraHoming", comment = "额外跟踪剑", category = 132, },

        ["120"] = { key = "speedAttack", comment = "峨眉加攻击力", category = 9, },
        ["121"] = { key = "speedCritDamage", comment = "峨眉加暴击伤害", category = 108, },
        ["122"] = { key = "speedHeadDamage", comment = "峨眉加爆头伤害", category = 109, },

        --白驼山庄
        --加普功伤害
        ["159"] = { key = "normal", comment = "加普功伤害", category = 147, },
        --加大招伤害
        ["160"] = { key = "ultra", comment = "加大招伤害", category = 148, },
        --加爆头伤害
        ["161"] = { key = "head", comment = "加爆头伤害", category = 149, },

        ["2"] = { key = "normalDot", comment = "普功叠毒", category = 2, },
        ["86"] = { key = "ultraDot", comment = "大招叠毒", category = 86, },
        ["87"] = { key = "headDot", comment = "爆头叠毒", category = 87, },
        ["88"] = { key = "hitDot", comment = "拼刀叠毒", category = 88, },

        ["30"] = { key = "hurtDot", comment = "受伤叠毒", category = 30, },
        ["90"] = { key = "powerDot", comment = "叠毒加伤", category = 90, },
        --毒叠加攻击
        ["143"] = { key = "increaseDot", comment = "毒叠加攻击", category = 143, },

        ["123"] = { key = "dotAttack", comment = "白驼山庄加攻击力", category = 9, },
        ["124"] = { key = "dotCritDamage", comment = "白驼山庄加暴击伤害", category = 108, },
        ["125"] = { key = "dotHeadDamage", comment = "白驼山庄加爆头伤害", category = 109, },


        --天山派
        --加普功伤害
        ["162"] = { key = "normal", comment = "加普功伤害", category = 147, },
        --加大招伤害
        ["163"] = { key = "ultra", comment = "加大招伤害", category = 148, },
        --加爆头伤害
        ["164"] = { key = "head", comment = "加爆头伤害", category = 149, },

        --天山普攻
        ["103"] = { key = "normalDizzy", comment = "天山普攻", category = 103, },
        --万剑归宗
        ["95"] = { key = "ultraDizzy", comment = "万剑归宗", category = 95, },
        --天山爆头
        ["26"] = { key = "headDizzy", comment = "天山爆头", category = 26, },
        --天山拼刀
        ["104"] = { key = "hitDizzy", comment = "天山拼刀", category = 104, },
        --眩晕延长
        ["105"] = { key = "extendDizzy", comment = "眩晕延长", category = 105, },
        --眩晕加伤
        ["106"] = { key = "powerDizzy", comment = "眩晕加伤", category = 106, },
        --顺手牵羊
        ["107"] = { key = "stealDizzy", comment = "顺手牵羊", category = 107, },
        --眩晕叠加伤害
        ["141"] = { key = "increaseDizzy", comment = "眩晕叠加伤害", category = 141, },

        ["126"] = { key = "dizzyAttack", comment = "天山加攻击力", category = 9, },
        ["127"] = { key = "dizzyCritDamage", comment = "天山加暴击伤害", category = 108, },
        ["128"] = { key = "dizzyHeadDamage", comment = "天山加爆头伤害", category = 109, },


        --小铁匠
        ["4"] = { key = "constant", comment = "一剑3连", category = 4, },
        ["18"] = { key = "homing", comment = "跟踪剑", category = 18, },
        ["34"] = { key = "angle", comment = "三向剑", category = 34, },
        ["46"] = { key = "increaseAttack_1", comment = "加攻击力", category = 46, },

        ["41"] = { key = "ultra_1", comment = "大招减CD", category = 41, },
        ["42"] = { key = "ultra_2", comment = "大招加伤害", category = 42, },
        ["44"] = { key = "ultra_4", comment = "再来一发", category = 44, },
        --再装填
        ["92"] = { key = "reloadMana", comment = "概率再装填", category = 92, },
        --小铁匠能力，30%几率涨大招
        ["130"] = { key = "ultra_8", comment = "攻击涨大招", category = 130, },
        --小铁匠能力，30%的几率纵向三发大宝剑
        ["131"] = { key = "changeUltra_1", comment = "纵向三发大宝剑", category = 131, },
        --小铁匠能力，切换大招为大宝剑
        ["144"] = { key = "changeUltra_3", comment = "祖传大宝剑", category = 131, },
        --大招2轮变3轮
        ["146"] = { key = "changeUltra_4", comment = "七星剑", category = 146, },


        --未使用旧能力
        ["5"] = { key = "sputter", comment = "溅射", category = 5, },
        ["8"] = { key = "recovery", comment = "恢复血量", category = 0, },
        ["14"] = { key = "slow", comment = "减速", category = 14, },
        ["25"] = { key = "attack_1", comment = "拼刀加攻", category = 25, },
        ["27"] = { key = "pierce", comment = "锐利一剑", category = 27, },
        ["40"] = { key = "ultra_6", comment = "剑阵", category = 40, },
        ["43"] = { key = "ultra_3", comment = "大招眩晕", category = 43, },
        ["48"] = { key = "lengthenInvincible",comment = "无敌延长",category = 48, },
        ["49"] = { key = "invincibleDeflect",comment = "无敌反弹子弹",category = 49, },
        --新能力
        ["57"] = { key = "attackPass", comment = "过关加攻击", category = 57, },
        ["58"] = { key = "rageAttackRate", comment = "七伤拳", category = 58, },
        ["60"] = { key = "autoDef",comment = "自动防御",category = 60},
        ["61"] = { key = "execute",comment = "斩杀",category = 61},
        --自动攻击
        ["62"] = { key = "autoHoming", comment = "自动攻击", category = 62, },
        --穿透
        ["63"] = { key = "pierce_1", comment = "穿透", category = 63, },
        --爆头涨内力
        ["64"] = { key = "headMana", comment = "爆头涨内力", category = 64, },
        --拼刀涨内力
        ["65"] = { key = "hitMana", comment = "拼刀涨内力", category = 65, },
        --范围攻击
        ["66"] = { key = "areaDot", comment = "范围攻击", category = 66, },
        --以德服人
        ["91"] = { key = "foeSurrender", comment = "以德服人", category = 91, },
        --爆毒
        ["93"] = { key = "dot_2", comment = "爆毒", category = 93, },
        ["94"] = { key = "swell", comment = "我膨胀了", category = 94, },

        --残影魅敌
        ["96"] = { key = "ability96", comment = "残影魅敌", category = 96, },
        --拼多多
        ["97"] = { key = "ability97", comment = "拼多多", category = 97, },
        --葵花宝典
        ["98"] = { key = "charm", comment = "葵花宝典", category = 98, },
        --瞄准大招
        ["99"] = { key = "ability99", comment = "瞄准大招", category = 99, },
        --蓄力回复大招
        ["100"] = { key = "ability100", comment = "蓄力回复大招", category = 100, },

        --斗转星移
        ["101"] = { key = "ability101", comment = "斗转星移", category = 101, },
        --蓄力群伤
        ["102"] = { key = "ability102", comment = "蓄力群伤", category = 102, },


        --试炼能力
        --百分百空手接白刃
        ["12"] = { key = "specialTrack", comment = "百分百空手接白刃", category = 12, },
        --变小
        ["67"] = { key = "smaller", comment = "变小", category = 67, },
        --变大
        ["68"] = { key = "bigger", comment = "变大", category = 67, },
        --减血量上限
        ["69"] = { key = "decreaseHealth_1", comment = "减血量上限", category = 10, },
        --加血量上限
        ["70"] = { key = "increaseHealth_1", comment = "加血量上限", category = 10, },
        --拼刀扣血
        ["71"] = { key = "hitHurt", comment = "拼刀扣血", category = 71, },
        --额外复活
        ["72"] = { key = "extraRevive", comment = "额外复活", category = 72, },
        --无法爆头
        ["73"] = { key = "disableHead", comment = "无法爆头", category = 73, },
        --爆头加伤
        ["74"] = { key = "headAttack_1", comment = "爆头加伤", category = 74, },
        --无法使用大招
        ["75"] = { key = "disableUltra", comment = "无法使用大招", category = 75, },
        --大招伤害增加50%
        ["76"] = { key = "ultra_5", comment = "大招伤害增加", category = 76, },
        --减攻击
        ["77"] = { key = "decreaseAttack_3", comment = "减攻击", category = 9, },
        --加攻击
        ["78"] = { key = "increaseAttack_3", comment = "加攻击", category = 9, },
        --加伤害
        ["79"] = { key = "decreaseDamage", comment = "加伤害", category = 79, },
        --减伤害
        ["80"] = { key = "increaseDamage", comment = "减伤害", category = 79, },
        --爆头概率+50%
        ["81"] = { key = "headShot", comment = "爆头概率+50%", category = 81, },
        --大招加速
        ["129"] = { key = "ultra_7", comment = "大招加速", category = 41, },
        --奇遇散射大宝剑
        ["145"] = { key = "changeUltra_2", comment = "散射大宝剑", category = 145, },

        --试炼
        ["501"] = { key = "trial", comment = "试炼1", category = 501, },
        ["502"] = { key = "trial", comment = "试炼2", category = 501, },
        ["503"] = { key = "trial", comment = "试炼3", category = 501, },
        ["504"] = { key = "trial", comment = "试炼4", category = 501, },
        ["505"] = { key = "trial", comment = "试炼5", category = 501, },
        ["506"] = { key = "trial", comment = "试炼6", category = 501, },
        ["507"] = { key = "trial", comment = "试炼7", category = 501, },
        ["508"] = { key = "trial", comment = "试炼8", category = 501, },
        ["509"] = { key = "trial", comment = "试炼9", category = 501, },
        ["510"] = { key = "trial", comment = "试炼10", category = 501, },--3回合空手接白刃
        ["511"] = { key = "trial", comment = "试炼11", category = 501, },--3回合变小
        ["512"] = { key = "trial", comment = "试炼12", category = 501, },--3回合变大
        ["513"] = { key = "trial", comment = "试炼13", category = 501, },--3回合大招加速
    },
    config = {
        -------武当：暴击
        --普攻伤害
        ["10102"] = { quality = 2, ability = 147, cost = 300, effect = { value = 0.5, }, },
        --大招伤害
        ["10202"] = { quality = 2, ability = 148, cost = 300, effect = { value = 0.5, }, },
        --爆头伤害
        ["10302"] = { ability = 149, cost = 300, effect = { value = 0.2, }, },

        --普攻暴击
        ["10101"] = {  type = 1, ability = 1, cost = 300, effect = { probability = 0.3, }, },
        --大招暴击
        ["10201"] = {  type = 2, ability = 28, cost = 300, effect = { probability = 0.3, }, },
        --爆头暴击
        ["10301"] = { type = 3, ability = 50, cost = 300, effect = { damageRate = 3, }, },
        --拼刀暴击
        ["10401"] = { quality = 2, type = 4, ability = 33, cost = 300, effect = { probability = 1, attackCount = 3, }, },

        --暴击伤害提升
        ["10501"] = { ability = 31, cost = 300, effect = { level = 1, maxLevel = 2, effect = {base = 0.2, extra = 0.15}, }, },
        --受伤暴击
        ["10502"] = { ability = 29, cost = 300, effect = { probability = 1, }, },
        --斗转星移
        ["10503"] = { ability = 101, cost = 300, effect = { probability = 1, max = 4, bullet = 33, level = 1, maxLevel = 2, effect = {base = 4, extra = 2}, }, },
        --一暴再暴
        ["10504"] = { ability = 52, cost = 100, effect = { probability = 0.3, damageRate = 0.2, }, },
        --暴击标记
        ["10505"] = { unlockStageId = 1, ability = 32, cost = 300, effect = { probability = 0.3, effectTime = 3, level = 1, maxLevel = 2, effect = {base = 1, extra = 1}, }, },
        --暴击叠加伤害
        ["10506"] = { ability = 142, cost = 300, effect = { increase = 0.01, max = 1, }, },

        --加攻击力
        ["10601"] = { ability = 108, cost = 300, effect = { value = 0.3, }, },
        --加暴击伤害
        ["10602"] = { ability = 109, cost = 300, effect = { value = 0.8, }, },
        --加爆头伤害
        ["10603"] = { ability = 110, cost = 300, effect = { value = 0.5, }, },
        --开局暴击
        ["10604"] = { ability = 137, cost = 300, effect = { attackCount = 5, }, },


        -------华山：剑气
        --普攻伤害
        ["20102"] = { quality = 2, ability = 150, cost = 300, effect = { value = 0.5, }, },
        --大招伤害
        ["20202"] = { quality = 2, ability = 151, cost = 300, effect = { value = 0.5, }, },
        --爆头伤害
        ["20302"] = { ability = 152, cost = 300, effect = { dizzyTime = 1, }, },

        --加攻、普攻附带剑气
        ["20101"] = { type = 1, ability = 13, cost = 300, effect = { }, },
        --加攻、大招附带剑气
        ["20201"] = { type = 2, ability = 22, cost = 300, effect = { }, },
        --爆头上剑气并且眩晕1秒
        ["20301"] = { type = 3, ability = 24, cost = 300, effect = { }, },
        --拼刀一次，接下来3次普攻附带剑气，并且剑气伤害翻倍
        ["20401"] = { quality = 2, type = 4, ability = 23, cost = 300, effect = { damageRate = 2, attackCount = 3, }, },

        --受伤时给周围的2个单位增加剑气
        ["20501"] = { ability = 21, cost = 300, effect = { level = 1, maxLevel = 2, effect = {base = 1, extra = 1}, }, },
        --剑气伤害提升
        ["20502"] = { type = 5, ability = 19, cost = 300, effect = { level = 1, maxLevel = 2, effect = {base = 0.2, extra = 0.2}, }, },
        --剑阵
        ["20503"] = { ability = 40, cost = 300, effect = { probability = 1, bullet = 28, level = 1, maxLevel = 2, effect = {base = 0.3, extra = 0.15}, }, },
        --低血提剑气伤害
        ["20504"] = { type = 5, ability = 54, cost = 300, effect = { value = 0.5, damageRate = 0.3, }, },
        -- --剑气可叠加的层数
        -- ["20505"] = { type = 5, ability = 20, cost = 300, effect = { count = 1, }, },
        --剑气叠加伤害
        ["20506"] = { type = 5, ability = 140, cost = 300, effect = { increase = 0.03, max = 1.5, }, },

        --加攻击力
        ["20601"] = { ability = 108, cost = 300, effect = { value = 0.2, }, },
        --加暴击伤害
        ["20602"] = { ability = 109, cost = 300, effect = { value = 0.5, }, },
        --加爆头伤害
        ["20603"] = { ability = 110, cost = 300, effect = { value = 0.3, }, },
        --开局剑气伤害
        ["20604"] = { ability = 135, cost = 300, effect = { attackCount = 5, value = 1, }, },
        --开局剑气
        ["20605"] = { ability = 136, cost = 300, effect = { delay = 2, count = 1, }, },


        -------少林：防御
        --普攻伤害----黑豆
        ["40102"] = { quality = 2, ability = 153, cost = 300, effect = { value = 0.5, }, },
        --大招伤害----黑豆
        ["40202"] = { quality = 2, ability = 154, cost = 300, effect = { value = 0.5, }, },
        --爆头伤害
        ["40302"] = { ability = 155, cost = 300, effect = { value = 0.2, }, },

        --普攻无敌, value为增加的攻击力
        ["40101"] = { type = 1, ability = 15, cost = 300, effect = { interval = 20, effectTime = 3, }, },
        --大招无敌
        ["40201"] = { type = 2, ability = 82, cost = 300, effect = { effectTime = 2, }, },
        --爆头无敌
        ["40301"] = { unlockStageId = 6, type = 3, ability = 83, cost = 300, effect = { effectTime = 1, }, },
        --拼刀无敌
        ["40401"] = { unlockStageId = 6, quality = 2, type = 4, ability = 84, cost = 300, effect = { effectTime = 3, }, },

        --受伤无敌
        ["40501"] = { ability = 85, cost = 300, effect = { effectTime = 3, }, },
        --无敌加攻
        ["40502"] = { type = 5, ability = 89, cost = 300, effect = { value = 0.5, }, },
        --反弹伤害
        ["40503"] = { unlockStageId = 6, ability = 56, cost = 300, effect = { value = 0.2 }, },
        -- --斩杀
        -- ["40504"] = { ability = 61, cost = 300, effect = { criticalHealth = 0.3, probility = 0.5, probilityElite = 0.10, probilityBoss = 0.00 }, },
        --无敌叠加攻击
        ["40505"] = { type = 5, ability = 138, cost = 300, effect = { increase = 0.01, max = 0.4, }, },

        --加攻击力
        ["40601"] = { ability = 108, cost = 300, effect = { value = 0.3, }, },
        --加暴击伤害
        ["40602"] = { ability = 109, cost = 300, effect = { value = 0.8, }, },
        --加爆头伤害
        ["40603"] = { ability = 110, cost = 300, effect = { value = 0.5, }, },

        --偏续航的新能力
        --加血量上限
        ["40701"] = { quality = 2, ability = 170, cost = 300, effect = { value = 0.3, }, },
        ["40702"] = { ability = 171, cost = 300, effect = { value = 0.15, }, },
        --护盾，value为增加的攻击力
        ["40703"] = { ability = 17, cost = 300, effect = { value = 0.15, }, },
        --回春术
        ["40704"] = { ability = 172, cost = 300, effect = { value = 0.02, effectTime = 5, interval = 20, }, },
        --东方剑法
        ["40705"] = { quality = 2, ability = 173, cost = 300, effect = { value = 3, count = 9, interval = 20, bullet = 46, }, },


        -------桃花岛：AOE
        --普攻伤害
        ["50102"] = { quality = 2, ability = 156, cost = 300, effect = { value = 0.5, }, },
        --大招伤害
        ["50202"] = { quality = 2, ability = 157, cost = 300, effect = { value = 0.5, }, },
        --爆头伤害
        ["50302"] = { ability = 158, cost = 300, effect = { value = 0.2, }, },

        --弹射, 基础弹射配置在hero.lua中
        ["50101"] = { type = 1, ability = 6, cost = 300, effect = { level = 1, maxLevel = 2, effect = {base = 3, extra = 1}, }, },
        --大招弹射
        ["50201"] = { unlockStageId = 6, type = 2, ability = 38, cost = 300, effect = { level = 1, maxLevel = 2, effect = {base = 3, extra = 1}, }, },
        --爆头弹射
        ["50301"] = { unlockStageId = 6, type = 3, ability = 37, cost = 300, effect = { level = 1, maxLevel = 2, effect = {base = 3, extra = 1}, }, },
        --拼多多
        ["50401"] = { unlockStageId = 6, quality = 2, type = 4, ability = 97, cost = 300, effect = { max = 3, damageRate = 0.3, count = 6, radius = 180, bullet = 32, class = "DelayHomingFollowLocus", velocity = 9, homingInterval = 0.03, homingAngle = 20, homingDuration = 0.5, }, },

        --弹射比例提升
        ["50501"] = { type = 5, ability = 39, cost = 300, effect = { damageRate = 0.6, }, },
        --受伤弹射
        ["50502"] = { unlockStageId = 6, unlockStageId = 6, ability = 55, cost = 300, effect = { damageRate = 3, }, },
        --落地攻击
        ["50503"] = { ability = 59, cost = 300, effect = { value = 0.1, }, },
        --台阶弹射
        ["50504"] = { ability = 11, cost = 300, effect = { count = 1, }, },
        --弹射叠加伤害
        ["50505"] = { type = 5, ability = 139, cost = 300, effect = { increase = 0.2, max = 1, }, },

        --好感度绝学
        --加攻击力
        ["50601"] = { ability = 108, cost = 300, effect = { value = 0.3, }, },
        --加暴击伤害
        ["50602"] = { ability = 109, cost = 300, effect = { value = 0.8, }, },
        --加爆头伤害
        ["50603"] = { ability = 110, cost = 300, effect = { value = 0.5, }, },
        --开局弹射
        ["50604"] = { ability = 133, cost = 300, effect = { attackCount = 5, count = 7, }, },
        --弹射造成额外伤害
        ["50605"] = { ability = 134, cost = 300, effect = { value = 0.3, }, },

        --偏攻击的新能力
        --攻击大
        ["50701"] = { quality = 2, ability = 165, cost = 300, effect = { value = 0.3, }, },
        --攻击小
        ["50702"] = { ability = 166, cost = 300, effect = { value = 0.15, }, },
        --满血加攻击
        ["50703"] = { quality = 2, ability = 167, cost = 300, effect = { value = 0.4, }, },
        --闪避
        ["50704"] = { ability = 168, cost = 300, effect = { probability = 0.3, }, },
        --吸血
        ["50705"] = { ability = 169, cost = 300, effect = { value = 0.1, probability = 0.2, }, },


        -------峨眉
        --一次起跳攻击2次
        ["60501"] = { ability = 3, cost = 300,effect = { attackCount = 2, }, },
        ---子弹提速
        ["60502"] = { ability = 45, cost = 300, effect = { speedRate = 0.2, value = 0.1, }, },
        --提速
        ["60503"] = { ability = 35, cost = 300, effect = { speedRate = 0.333, value = 0.1, }, },
        --加跟踪弹
        ["60504"] = { ability = 132, cost = 300, effect = { probability = 0.5, count = 2, class = "HomingFollowLocus", velocity = 7, homingInterval = 0.05, homingAngle = 20, homingDuration = 0.5, }, },

        --加攻击力
        ["60601"] = { ability = 108, cost = 300, effect = { value = 0.3, }, },
        --加暴击伤害
        ["60602"] = { ability = 109, cost = 300, effect = { value = 0.8, }, },
        --加爆头伤害
        ["60603"] = { ability = 110, cost = 300, effect = { value = 0.5, }, },


        ---白驼山庄
        --普攻伤害
        ["70102"] = { quality = 2, ability = 159, cost = 300, effect = { value = 0.5, }, },
        --大招伤害
        ["70202"] = { quality = 2, ability = 160, cost = 300, effect = { value = 0.5, }, },
        --爆头伤害
        ["70302"] = { ability = 161, cost = 300, effect = { value = 0.2, }, },

        --叠毒
        ["70101"] = { type = 1, ability = 2, cost = 300, effect = { }, },
        --大招叠毒
        ["70201"] = { type = 2, ability = 86, cost = 300, effect = { count = 2, }, },
        --爆头叠毒
        ["70301"] = { type = 3, ability = 87, cost = 300, effect = { }, },
        --拼刀叠毒
        ["70401"] = { quality = 2,  type = 4, ability = 88, cost = 300, effect = { value = 0.1, attackCount = 3, count = 2, }, },

        --受伤叠毒
        ["70501"] = { ability = 30, cost = 300, effect = { count = 1, }, },
        --叠毒加伤
        ["70502"] = { type = 5, ability = 90, cost = 300, effect = { increase = 0.2, max = 0.6, }, },
        --爆毒
        ["70503"] = { ability = 93, cost = 300, effect = { value = 30, }, },
        --小怪死后留毒
        ["70504"] = { ability = 66, cost = 300, effect = { bullet = 25, }, },
        --残影魅敌
        ["70505"] = { ability = 96, cost = 300, effect = { healthRate = 0.3, }, },
        --毒叠加伤害
        ["70506"] = { type = 5, ability = 143, cost = 300, effect = { increase = 0.05, max = 1, }, },

        --加攻击力
        ["70601"] = { ability = 108, cost = 300, effect = { value = 0.3, }, },
        --加暴击伤害
        ["70602"] = { ability = 109, cost = 300, effect = { value = 0.8, }, },
        --加爆头伤害
        ["70603"] = { ability = 110, cost = 300, effect = { value = 0.5, }, },


        -------天山：控制
        --普攻伤害
        ["80102"] = { quality = 2, ability = 162, cost = 300, effect = { value = 0.5, }, },
        --大招伤害
        ["80202"] = { quality = 2, ability = 163, cost = 300, effect = { value = 0.5, }, },
        --爆头伤害
        ["80302"] = { ability = 164, cost = 300, effect = { value = 0.2, }, },

        --天山普攻
        ["80101"] = { type = 1, ability = 103, cost = 300, effect = { probability = 0.3, }, },
        --群控大招
        ["80201"] = { type = 2, ability = 95, cost = 300, effect = { probability = 0.5, dizzyTime = 4, bullet = 31, class = "HomingFollowLocus", velocity = 9, homingInterval = 0.01, homingAngle = 10, homingDuration = 0.5, }, },
        --天山爆头
        ["80301"] = { type = 3, ability = 26, cost = 300, effect = { probability = 0.3, }, },
        --天山拼刀
        ["80401"] = { quality = 2, type = 4, ability = 104, cost = 300, effect = { attackCount = 3, }, },
        --眩晕延长
        ["80501"] = { type = 5, ability = 105, cost = 300, effect = { dizzyTime = 1, }, },
        --眩晕加伤
        ["80502"] = { type = 5, ability = 106, cost = 300, effect = { damageRate = 0.6, }, },
        --顺手牵羊
        ["80503"] = { type = 5, ability = 107, cost = 300, effect = { probability = 0.3, coin = 3, }, },
        --葵花宝典
        ["80504"] = { ability = 98, cost = 300, effect = { damageRate = 2.0, effectTime = 5, bullet = 34, class = "HomingFollowLocus", velocity = 4, homingInterval = 0.01, homingAngle = 10, homingDuration = 0.5, }, },
        --眩晕叠加伤害
        ["80505"] = { type = 5, ability = 141, cost = 300, effect = { increase = 0.05, max = 1, }, },

        --加攻击力
        ["80601"] = { ability = 108, cost = 300, effect = { value = 0.3, }, },
        --加暴击伤害
        ["80602"] = { ability = 109, cost = 300, effect = { value = 0.8, }, },
        --加爆头伤害
        ["80603"] = { ability = 110, cost = 300, effect = { value = 0.5, }, },


        -------小铁匠
        --加攻击
        ["10001"] = { ability = 46, cost = 300, effect = { bullet = 45, value = 1, }, },
        --跟踪剑
        ["10002"] = {  unlockStageId = 1, ability = 18, cost = 300, effect = { value = 0.5, class = "HomingFollowLocus", velocity = 9, homingInterval = 0.05, homingAngle = 20, homingDuration = 0.5, }, },
        --散射
        ["10003"] = { ability = 34, cost = 300, effect = { bullet = 44, angle = { -90, -15, 15, 90, }, damageRate = 1, }, },
        --录屏能力，一剑三连
        ["10004"] = { ability = 4, cost = 300, effect = { bullet = 43, bulletCount = 3, bulletInterval = 0.13, damageRate = 0.6, }, },

        --大招提速40%
        ["10005"] = { ability = 41, cost = 300, effect = { speedRate = 1.4, }, },
        --增加30%伤害
        ["10006"] = { ability = 42, cost = 300, effect = { value = 0.3, }, },
        --额外多扔一发
        ["10007"] = { ability = 44, cost = 300, effect = { count = 1, }, },
        --大招概率再装填
        ["10008"] = { ability = 92, cost = 300, effect = { probability = 0.2, }, },

        --小铁匠能力，30%几率涨大招
        ["10009"] = { ability = 130, cost = 300, effect = { probability = 0.3, }, },
        --小铁匠能力，30%的几率纵向三发大宝剑
        ["10010"] = { ability = 131, cost = 300, effect = { ultraAttackKey = "attack3", }, },
        --更换大招
        ["10011"] = { ability = 144, cost = 300, effect = { ultraAttackKey = "attack1", }, },
        --大招2轮变3轮
        ["10012"] = { ability = 146, cost = 300, effect = { count = 1, }, },


        --奇遇对大招的提升
        ["90001"] = { ability = 513, cost = 0, effect = { debuff = { ability = 129, startStage = 0, stage = 2, }, }, }, --大招伤害翻倍
        ["90002"] = { ability = 513, cost = 0, effect = { debuff = { ability = 145, startStage = 0, stage = 2, }, }, }, --大招散射
        ["90003"] = { ability = 513, cost = 0, effect = { debuff = { ability = 12, startStage = 0, stage = 2, }, }, }, --接白刃
        ["90004"] = { ability = 513, cost = 0, effect = { debuff = { ability = 91, startStage = 0, stage = 2, }, }, }, --以德服人

        -------特殊房间
        --暴击回血
        ["20001"] = { ability = 51, cost = 300, effect = { value = 3, }, },


        --新能力
        --通关提升攻击力
        ["57"] = { ability = 57, cost = 300, effect = { value = 1, }, },
        --残血提升攻击力
        ["58"] = { ability = 58, cost = 300, effect = { healthRate = 0.5, value = 1, }, },

        ["60"] = { ability = 60, cost = 100, effect = { interval = 3, radius = 800, bulletId = 14, }, },
        --自动攻击
        ["62"] = { ability = 62, cost = 300, effect = { bullet = 14, interval = 10, class = "HomingFollowLocus", velocity = 9, homingInterval = 0.05, homingAngle = 20, damageRate = 1.5, homingDuration = 0.5, }, },
        --穿透
        ["63"] = { ability = 63, cost = 300, effect = { target = 8, }, },
        --爆头涨内力
        ["64"] = { ability = 64, cost = 300, effect = { value = 1, }, },
        --拼刀涨内力
        ["65"] = { ability = 65, cost = 300, effect = { value = 1, }, },



        --减速
        ["3001"] = { ability = 14, cost = 300, effect = { value = 0.5, effectTime = 2.0, }, },

        --减伤
        ["4050401"] = { ability = 16, cost = 300, effect = { value = 0.3, }, },
        --神掌
        ["4005"] = { ability = 7, cost = 300, effect = { preDelay = 0, duration = 0.3, postDelay = 0.3 }, },
        --血量加攻
        ["4006"] = { ability = 47, cost = 300, effect = { value = 0.1 }, },
        --无敌反弹子弹
        ["4008"] = { ability = 49, cost = 300, },
        --无敌延长
        ["4050310"] = { ability = 48, cost = 300, effect = { extraInvincibleTime = 2 }, },
        --溅射，屏幕宽度1500
        ["5050310"] = { type = 5, ability = 5, cost = 300,effect = { range = 800, damageRate = 0.3, }, },
        --命中后眩晕2s
        ["7003"] = { type = 5, ability = 43, cost = 300, effect = { value = 2.0, }, },
        --你膨胀了
        ["70504"] = { ability = 94, cost = 300, effect = { swellRate = 0.3, decreasePerHit = 0.3 }, },



        --瞄准大招
        ["99"] = { ability = 99, cost = 300, effect = { value = 0.8, }, },
        --拼刀弹射
        ["36"] = { type = 4, ability = 36, cost = 300, effect = { count = 5, attackCount = 3}, },
        --以德服人
        ["91"] = { ability = 91, cost = 300, effect = { count = 3 }, },
        --蓄力群伤
        ["102"] = { unlockStageId = 2, ability = 102, cost = 300, effect = { delay = 3, interval = 1, value = 0.1, }, },
        --蓄力回复大招
        ["100"] = { unlockStageId = 2, ability = 100, cost = 300, effect = { delay = 0, interval = 1, }, },

       --------------------------试炼
        --变小
        ["67"] = { ability = 67, cost = 300, effect = { value = 0.5, }, },
        --变大
        ["68"] = { ability = 68, cost = 300, effect = { value = 1.5, }, },
        --减血量上限
        ["69"] = { ability = 69, cost = 300, effect = { value = -0.5, }, },
        --加血量上限
        ["70"] = { ability = 70, cost = 300, effect = { value = 0.3, }, },
        --拼刀扣血
        ["71"] = { ability = 71, cost = 300, effect = { value = 3, }, },
        --额外复活
        ["72"] = { ability = 72, cost = 300, effect = { count = 1, }, },
        --无法爆头
        ["73"] = { ability = 73, cost = 300, },
        --爆头加伤
        ["74"] = { ability = 74, cost = 300, effect = { value = 0.5, }, },
        --无法使用大招
        ["75"] = { ability = 75, cost = 300, },
        --大招伤害加50%
        ["76"] = { ability = 76, cost = 300, effect = { value = 0.2, }, },
        --减攻击
        ["77"] = { ability = 77, cost = 300, effect = { value = -0.2, }, },
        --加攻击
        ["78"] = { ability = 78, cost = 300, effect = { value = 0.1, }, },
        --加伤害
        ["79"] = { ability = 79, cost = 300, effect = { value = 1.5, }, },
        --减伤害
        ["80"] = { ability = 80, cost = 300, effect = { value = 0.2, }, },
        --爆头概率+50%
        ["81"] = { ability = 81, cost = 300, effect = { probability = 0.1, }, },
        --百分百空手接白刃
        ["12"] = { ability = 12, cost = 300, effect = { value = 10, damage = 1, interval = 1, }, },
        --大招加速3倍
        -- ["129"] = { ability = 129, cost = 300, effect = { speedRate = 4, }, },
        ["129"] = { ability = 76, cost = 300, effect = { value = 1, }, },
        ["145"] = { ability = 145, cost = 300, effect = { ultraAttackKey = "attack4", }, },


        --试炼
        ["501"] = { ability = 501, cost = 0, effect = { debuff = { ability = 67, startStage = 0, stage = 3, }, buff = { ability = 68, startStage = 3, }, }, },
        ["502"] = { ability = 502, cost = 0, effect = { debuff = { ability = 69, startStage = 0, stage = 3, }, buff = { ability = 70, startStage = 3, }, }, },
        ["503"] = { ability = 503, cost = 0, effect = { debuff = { ability = 71, startStage = 0, stage = 3, }, buff = { ability = 72, startStage = 3, }, }, },
        ["504"] = { ability = 504, cost = 0, effect = { debuff = { ability = 73, startStage = 0, stage = 3, }, buff = { ability = 74, startStage = 3, }, }, },
        ["505"] = { ability = 505, cost = 0, effect = { debuff = { ability = 75, startStage = 0, stage = 3, }, buff = { ability = 76, startStage = 3, }, }, },
        ["506"] = { ability = 506, cost = 0, effect = { debuff = { ability = 77, startStage = 0, stage = 3, }, buff = { ability = 78, startStage = 3, }, }, },
        ["507"] = { ability = 507, cost = 0, effect = { debuff = { ability = 79, startStage = 0, stage = 3, }, buff = { ability = 80, startStage = 3, }, }, },
        ["508"] = { ability = 508, cost = 0, effect = { debuff = { ability = 67, startStage = 0, stage = 3, }, buff = { ability = 78, startStage = 3, }, }, },
        ["509"] = { ability = 509, cost = 0, effect = { debuff = { ability = 68, startStage = 0, stage = 3, }, buff = { ability = 12, startStage = 3, stage = 4, }, }, },
        --空手接白刃
        ["510"] = { ability = 510, cost = 0, effect = { debuff = { ability = 12, startStage = 0, stage = 3, }, }, },
        --变小
        ["511"] = { ability = 511, cost = 0, effect = { debuff = { ability = 67, startStage = 0, stage = 3, }, }, },
        --变大
        ["512"] = { ability = 512, cost = 0, effect = { debuff = { ability = 68, startStage = 0, stage = 3, }, }, },

    },
    -- sect = {
    --     --武当：暴击为主
    --     ["1"] = {name = "武当派", ability1 = {{10101, 10201, 10301, 10401,}, {10501, 10502, 10503, 10504, 10505, }, {}, }, },
    --
    --     --华山：厄运
    --     ["2"] = {name = "华山派", ability1 = {{20101, 20201, 20301, 20401,}, {20501, 20502, 20503, 20504, 20505, }, {}, }, },
    --
    --     --天山：减速
    --     ["3"] = {name = "天山派", ability = {{4, 5, 6, 36}}},
    --
    --     --少林：防御，反弹
    --     ["4"] = {name = "少林派", ability1 = {{40101, 40201, 40301, 40401}, {40501, 40502, 40503, 40504, 40505, }, {}, }, },
    --
    --     --桃花岛：AOE
    --     ["5"] = {name = "桃花岛", ability1 = {{50101, 50201, 50301, 50401,}, {50501, 50502, 50503, 50504, 50505}, {}, }, },
    --
    --     --峨眉派
    --     ["6"] = {name = "峨眉派", ability = {{60501, 60502, 60503}, {},}},
    --
    --     --白驼山庄
    --     ["7"] = {name = "白驼山庄", ability1 = {{70101, 70201, 70301, 70401}, {70501, 70502, 70503, 70504, }, {}, }, },
    --
    --
    --     --商店
    --     ["10"] = {name = "商店", ability = {{10001}}},
    --
    --     --小铁匠
    --     ["11"] = {name = "小铁匠", ability = {{10001, 10002, 10003, 10004}, }, },
    --
    --     --试炼
    --     ["12"] = {name = "试炼", ability = {{502, 503, 504, 505, 506, 507, 508, 509,}}},
    -- },
    -- dialog = {
    --     ["1"] = {
    --       name = "武当派",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "武当派从不废话，直取要害",
    --         "武当绝学，那讲究一个看脸",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "不坏！武当绝学你大可学去！"
    --       },
    --     },
    --
    --     ["2"] = {
    --       name = "华山派",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "你可曾见过一招从天而降的剑法？",
    --         "华山派的剑法天下第一",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "不错，你也是可塑之才"
    --       },
    --     },
    --
    --     ["3"] = {
    --       name = "天山派",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "无",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "无"
    --       },
    --     },
    --
    --     ["4"] = {
    --       name = "少林派",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "少林绝学，免费就学",
    --         "金钟护体，我教你",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "贫僧也顺手点悟你一二"
    --       },
    --     },
    --
    --     ["5"] = {
    --       name = "桃花岛",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "弹指神功，你值得拥有",
    --         "单身弟子，最适合修学桃花岛绝学",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "如何？对桃花岛有所改观吗？"
    --       },
    --     },
    --
    --     ["6"] = {
    --       name = "峨眉派",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "峨眉派不招男徒……你到是可以破例",
    --         "天下武功，唯快不破",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "天下武功，唯快不破"
    --       },
    --     },
    --
    --     ["7"] = {
    --       name = "白驼山庄",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "我的毒，没有解药",
    --         "我这把刀上可是剧毒(舔~)",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "…………",
    --       },
    --     },
    --
    --     ["10"] = {
    --       name = "天山派",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "无",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "无"
    --       },
    --     },
    --
    --     ["11"] = {
    --       name = "小铁匠",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "只需一锤，神器相随",
    --         "打铁打铁，神兵似雪",
    --         "一锤一锤，武器如雷",
    --         "听说第9关有个神秘人在等你",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "无"
    --       },
    --     },
    --
    --     ["12"] = {
    --       name = "试炼",
    --       --普通模式成功通关后的说话
    --       successDesc = {
    --         "只需一锤，神器相随",
    --         "打铁打铁，神兵似雪",
    --         "一锤一锤，武器如雷",
    --         "听说第9关有个神秘人在等你",
    --       },
    --       --二选一模式成功通关后的说话
    --       passDesc = {
    --         "无"
    --       },
    --     },
    -- }
}
return config
