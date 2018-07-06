using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool{

    public string ResourceDir = "";

    Dictionary<string,SubPool> m_Pools = new Dictionary<string, SubPool>();

    //取对象
    public GameObject Spawn(string name) {
        if (!m_Pools.ContainsKey(name))
            RegisterNew(name);
        SubPool pool = m_Pools[name];
        return pool.Spawn();//取消息
    }

    //回收对象
    public void UnSpawn(GameObject go) {
        SubPool pool = null;
        foreach(SubPool p in m_Pools.Values) {
            pool = p;
            break;
        }

        pool.UnSpawn(go);
    }

    //回收所有对象
    public void UnspawnAll() {
        foreach(SubPool p in m_Pools.Values) {
            p.UnSpawnAll();
        }
    }

    //创建新的子对象池
    void RegisterNew(string name) {
        //预设对象
        string path = "";
        if (string.IsNullOrEmpty(ResourceDir)) {
            path = name;
        }
        else {
            path = ResourceDir + "/" + name; 
        }

        //加载预设
        GameObject prefab = Resources.Load<GameObject>(path);

        //创建子对象池
        SubPool pool = new SubPool(prefab);
        m_Pools.Add(pool.Name, pool);
    }
}
