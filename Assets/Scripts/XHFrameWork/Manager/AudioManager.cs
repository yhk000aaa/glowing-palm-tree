//音频控制器

using System.Collections;
using UnityEngine;


using UnityEngine.UI;
using XHFrameWork;
using System.Collections.Generic;


namespace XHFrameWork
{
    public class AudioManager :Singleton<AudioManager>
    {
        AudioSource bgSound;
        AudioSource FXsound;
        public float musicFadeValue =1f;//淡入淡出系数，用于背景音乐时淡入淡出切换用的

        private AudioClip ac;
        private EnumMusicType BGName;

        public override void Init()
        {
            CheckAudioSources();
            BGName = EnumMusicType.None;
        }
        //播放背景音乐
        public void Play(EnumMusicType fileName)
        {
            if (fileName != BGName)
            {
                if (fileName != EnumMusicType.None)
                {
                    ac = Resources.Load(AudioPath.GetMusicPath(fileName)) as AudioClip;
                    //ac = UnityEditor.AssetDatabase.LoadAssetAtPath(AudioPathDefines.GetMusicPathByName(fileName), typeof(AudioClip)) as AudioClip;此处有坑，调用UnityEditor的内容无法打入包中
                    bgSound.clip = ac;
                    bgSound.playOnAwake = true;
                    bgSound.loop = true;
                    bgSound.volume = MainData.Instance.configData.musicValue / 10f* musicFadeValue;
                    bgSound.Play();
                    BGName = fileName;
                }
            }
        }

        //停止背景音乐
        public void Stop()
        {
            bgSound.Stop();
            BGName = EnumMusicType.None;
            //Debug.Log("Stop background music");
        }

        //刷新音乐音量
        public void FleshMisicVolume() 
        {
            if (bgSound!=null)
            {
                bgSound.volume = MainData.Instance.configData.musicValue / 10f* musicFadeValue;
            }
        }


        //重载1：播放音效 by 使用物体作为声音源 by声音源物体&声音类型
        public AudioSource PlaySound(GameObject _soundRes, EnumSoundType _fileName)
        {       
            return PlaySound(_soundRes, _fileName,false);
        }

        //根方法1：播放音效 by 使用物体作为声音源（声音源物体&声音类型&是否循环）
        public AudioSource PlaySound(GameObject _soundRes, EnumSoundType _fileName, bool _loop)
        {
            AudioSource sound = _soundRes.GetComponent<AudioSource>();
            if (sound == null)
            {
                sound = _soundRes.AddComponent<AudioSource>();
            }
            
            if (_fileName != EnumSoundType.None)
            {
                ac = Resources.Load(AudioPath.GetSoundPath(_fileName)) as AudioClip;
                sound.clip = ac;
                sound.loop = _loop;
                sound.volume = MainData.Instance.configData.soundValue / 10f;
                
                // sound.pitch = 1f;
                // sound.bypassEffects = false;
                // sound.bypassListenerEffects = false;
                // sound.bypassReverbZones = false;
                // sound.spatialBlend = 0;
                // sound.reverbZoneMix = 0;
                // sound.PlayOneShot(ac);
                sound.Play();
            }
            else
            {
                if (sound != null)
                {
                    sound.Stop();
                }
            }
            return sound;
        }

        //根方法2：播放音效 by 占用公共声音源（UI关闭需发声时用）,并返回公共声音源
        public void PlaySound(EnumSoundType fileName)
        {
            if (fileName != EnumSoundType.None)
            {
                ac = Resources.Load(AudioPath.GetSoundPath(fileName)) as AudioClip;
                FXsound.clip = ac;
                FXsound.loop = false;
                FXsound.volume = MainData.Instance.configData.soundValue / 10f;
                FXsound.Play();
            }
        }

        //刷新公共声音源的音效音量
        public void FleshSoundVolume()
        {
            if (FXsound != null)
            {
                FXsound.volume = MainData.Instance.configData.soundValue / 10f;
            }
        }

        //遍历游戏物体刷新所有声音音量
        public void FleshAllSound()
        {
            GameObject[] objs = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
            foreach (GameObject obj in objs)
            {
                AudioSource a = obj.transform.GetComponent<AudioSource>();
                if (a != null)
                {
                    a.volume = MainData.Instance.configData.soundValue / 10f;
                }
            }
            //上一步将音乐音量也压到了音效音量的大小，此处恢复音乐音量
            FleshMisicVolume();
        }

        private void CheckAudioSources() 
        {
            bgSound = GameObject.Find("Main Camera").GetComponent<AudioSource>();
            //如果没声音源脚本，依照加一个脚本
            if (null == bgSound)
            {
                bgSound = GameObject.Find("Main Camera").AddComponent<AudioSource>();
            }
            
            FXsound = GameObject.Find("Main Camera").AddComponent<AudioSource>();
        }


    }
}

