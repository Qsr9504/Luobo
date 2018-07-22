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

    //停止音乐

    //播放特效

}