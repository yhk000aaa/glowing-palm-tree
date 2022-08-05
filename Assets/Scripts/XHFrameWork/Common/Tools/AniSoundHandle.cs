using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using XHFrameWork;

public class AniSoundHandle : MonoBehaviour
{    
    public void PlaySound(string _sound)
    {
        AudioManager.Instance.PlaySound(this.gameObject, (EnumSoundType)Enum.Parse(typeof(EnumSoundType), _sound));
    }
}
