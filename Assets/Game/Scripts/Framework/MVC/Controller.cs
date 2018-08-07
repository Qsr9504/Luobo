using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller{
    public abstract void HandleEvent(string eventName, object data);
}
