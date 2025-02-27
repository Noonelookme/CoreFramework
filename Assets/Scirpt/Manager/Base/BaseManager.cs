using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// ����ģʽ���� ��ҪĿ���Ǳ����������� ��������ʵ�ֵ���ģʽ����
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseManager<T> where T:class//,new()//Լ��
{
    private static T instance;
    //���Եķ�ʽ
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = new T();
                //���÷���ĵ�˽�е��޲ι��캯�� �����ڶ����ʵ��������
                Type type = typeof(T);
                ConstructorInfo info =  type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                                                            null,
                                                            Type.EmptyTypes,
                                                            null);
                if (info != null)
                    instance = info.Invoke(null) as T;
                else
                    Debug.LogError("û�еõ���Ӧ���޲ι��캯��");
            }
                
            return instance;
        }
    }
    //�����ķ�ʽ
    //public static T GetInstance()
    //{
    //    if (instance == null)
    //        instance = new T();
    //    return instance;
    //}
}
