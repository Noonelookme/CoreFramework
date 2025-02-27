using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����ģ�� ������
/// </summary>
public class PoolMgr : BaseManager<PoolMgr>
{
    //�����������г���ı���
    private Dictionary<string, Stack<GameObject>> poolDic = new Dictionary<string, Stack<GameObject>>();
    private PoolMgr() { }

    /// <summary>
    /// �ö����ķ���
    /// </summary>
    /// <param name="name">���������</param>
    /// <returns>�ӻ������ȡ���Ķ���</returns>
    public GameObject GetObj(string name)
    {
        GameObject obj;
        //�г��� ���� ������ �ж��� ��ȥֱ����
        if(poolDic.ContainsKey(name) && poolDic[name].Count > 0)
        {
            obj = poolDic[name].Pop();
            //������ȡ����
            obj.SetActive(true);
        }
        //���� ֱ��ȥ����
        else
        {  
            //û�е�ʱ�� ͨ����Դ���� ȥʵ������һ��GameObject
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //����ʵ���������Ķ��� Ĭ�ϻ��ں����һ����Clone��
            //�������������� �����������
            obj.name = name;
        }
        return obj;
    }
    /// <summary>
    /// ��������зŶ���
    /// </summary>
    /// <param name="name">Ҫ������������</param>
    /// <param name="obj">Ҫ����Ķ���</param>
    public void PushObj(GameObject obj)
    {
        //������ֱ���Ƴ����� ���ǽ�����ʧ��һ������ �õ�ʱ���ټ�����
        //�������ַ�ʽ �����԰Ѷ��������Ұ��
        obj.SetActive(false);
        //û�г��� ��������
        if(!poolDic.ContainsKey(obj.name))
            poolDic.Add(obj.name, new Stack<GameObject>());

        //�����뵱�зŶ���
        poolDic[obj.name].Push(obj);

        ////������ڶ�Ӧ�ĳ������� ֱ�ӷ�
        //if (poolDic.ContainsKey(name))
        //{
        //    //��ջ�����룩�з������
        //    poolDic[name].Push(obj);
        //}
        ////���� ��Ҫ�ȴ������� �ٷ�
        //else
        //{
        //    //�ȴ�������
        //    poolDic.Add(name, new Stack<GameObject>());
        //    poolDic[name].Push(obj);
        //}
    }
    /// <summary>
    /// ��������������ӵ��е�����
    /// ʹ�ó��� ��Ҫ�� �г���ʱ
    /// </summary>
    public void ClearPool()
    {
        poolDic.Clear();
    }
}
