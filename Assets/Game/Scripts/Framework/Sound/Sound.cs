using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//声音管理类
public class Sound : Singleton<Sound>{
    protected override void Awake() {
        base.Awake();
        //动态创建
        m_bgSound = this.gameObject.AddComponent<AudioSource>();
        m_effectSound = this.gameObject.AddComponent<AudioSource>();

        m_bgSound.playOnAwake = false;
        m_bgSound.loop = true;
    }

    public string ResourceDir = "";

    AudioSource m_bgSound;
    AudioSource m_effectSound;
    
    //音乐大小
    public float BgVolume {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value; }
    }

    //音效大小
    public float EffectVolume {
        get { return m_effectSound.volume; }
        set { m_effectSound.volume = value; }
    }

    //播放音乐
    public void PlayBg(string audioName) {
        //需要做一个同一个音乐文件传进来，不需要重新播放
        //当前正在播放的音乐文件
        string oldName;
        if(m_bgSound.clip == null) {
            oldName = "";
        }
        else {
            oldName = m_bgSound.clip.name;
        }

        if(oldName != audioName) {
            AudioClip clip = ProductClip(audioName);
            //播放
            if (clip != null) {
                m_bgSound.clip = clip;
                m_bgSound.Play();
            }
        }
    }

    //停止音乐
    public void StopBg() {
        m_bgSound.Stop();
        m_bgSound.clip = null;
    }

    //播放音效
    public void PlayEffect(string audioName) {
        //获取clip
        AudioClip clip = ProductClip(audioName);
        //播放
        m_effectSound.PlayOneShot(clip);
    }


    //通过音频名称获取该音频clip
    public AudioClip ProductClip(string audioName) {
        //路径
        string path;
        if (string.IsNullOrEmpty(ResourceDir))
            path = "";
        else
            path = ResourceDir + "/" + audioName;

        //音频
        AudioClip clip = Resources.Load<AudioClip>(path);

        return clip;
    }
}