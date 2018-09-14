using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MVC {

    //存储MVC
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();//名字---模型
    public static Dictionary<string, View> Views = new Dictionary<string, View>();//名字---视图
    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();//事件名字---事件控制器类型

    //注册
    public static void RegisterModel(Model model) {
        Models[model.Name] = model;
    }

    public static void RegisterView(View view) {
        Views[view.name] = view;
    }

    public static void RegisterController(string eventName, Type controllerType) {
        CommandMap[eventName] = controllerType;
    }

    //获取
    public static Model GetModel<T>() where T : Model {
        foreach(Model m in Models.Values) {
            if(m is T) 
                return m;
        }
        return null;
    }
    public static View GetView<T>() where T : View {
        foreach (View m in Views.Values) {
            if (m is T)
                return m;
        }
        return null;
    }
    
    //发送事件
    public static void SendEvent(string eventName,object data = null) {
        //控制器响应事件
        if (CommandMap.ContainsKey(eventName)) {
            Type t = CommandMap[eventName];
            Controller controller = Activator.CreateInstance(t) as Controller;
            //控制器执行
            controller.Execute(data);
        }

        //视图响应事件
        foreach(View v in Views.Values) {
            if (v.AttationEvents.Contains(eventName)) {
                //视图响应事件
                v.HandleEvent(eventName, data);
            }
        }

    }
}
