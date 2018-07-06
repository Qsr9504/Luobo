using UnityEngine;

public abstract class ReuseableObject : MonoBehaviour, IReuseable {
    //对象池管理，基类

    public abstract void OnSpawn();

    public abstract void OnUnspawn();


}