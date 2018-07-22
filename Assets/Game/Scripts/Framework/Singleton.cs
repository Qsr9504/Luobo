using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour 
    where T : MonoBehaviour //对T进行类型约束，必须也是继承于MonoBehaviour
{
    private static T m_instance = null;

    public static T Instance {
        get { return m_instance; }
    }

    protected virtual void Awake() {
        m_instance = this as T;    
    }

}

