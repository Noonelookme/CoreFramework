using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ʽ �̳�Mono�ĵ���ģʽ����
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonMono<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            return instance;
        }
    }
    protected virtual void Awake()
    {
        instance = this as T;
    }
}
