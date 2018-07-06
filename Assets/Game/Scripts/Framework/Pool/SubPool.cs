using System.Collections.Generic;
using UnityEngine;

public class SubPool{
    //预设
    GameObject m_prefab;

    //集合
    List<GameObject> m_objects = new List<GameObject>();

    //名字标识
    public string Name {
        get { return m_prefab.name; }
    }

    //构造函数
    public SubPool(GameObject prefab) {
        this.m_prefab = prefab;
    }

    //取对象
    public GameObject Spawn() {
        GameObject go = null;
        foreach(GameObject obj in m_objects) {
            if (!obj.activeSelf) {//如果当前对象为不可用状态
                go = obj;
                break;
            }
        }
        if(go == null) {
            go = GameObject.Instantiate<GameObject>(m_prefab);//初始化一个对象
            m_objects.Add(go);//添加到当前对象池中
        }
        go.SetActive(true);
        go.SendMessage("OnSpawn",SendMessageOptions.DontRequireReceiver);
        return go;
    }

    //回收对象
    public void UnSpawn(GameObject go) {
        if (Contains(go)) {
            go.SendMessage("OnUnspawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }


    //回收该池子中所有对象
    public void UnSpawnAll() {
        foreach(GameObject item in m_objects) {
            if (item.activeSelf) {
                UnSpawn(item);
            }
        }
    }

    //本对象池是否包含对象
    public bool Contains(GameObject go) {
        return m_objects.Contains(go);
    }
}