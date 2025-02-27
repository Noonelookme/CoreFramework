using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// 单例模式基类 主要目的是避免代码的冗余 方便我们实现单例模式的类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseManager<T> where T:class//,new()//约束
{
    private static T instance;
    //属性的方式
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = new T();
                //利用反射的到私有的无参构造函数 来用于对象的实例化对象
                Type type = typeof(T);
                ConstructorInfo info =  type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                                                            null,
                                                            Type.EmptyTypes,
                                                            null);
                if (info != null)
                    instance = info.Invoke(null) as T;
                else
                    Debug.LogError("没有得到对应的无参构造函数");
            }
                
            return instance;
        }
    }
    //方法的方式
    //public static T GetInstance()
    //{
    //    if (instance == null)
    //        instance = new T();
    //    return instance;
    //}
}
