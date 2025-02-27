using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 缓存池模块 管理器
/// </summary>
public class PoolMgr : BaseManager<PoolMgr>
{
    //柜子容器中有抽屉的表现
    private Dictionary<string, Stack<GameObject>> poolDic = new Dictionary<string, Stack<GameObject>>();
    private PoolMgr() { }

    /// <summary>
    /// 拿东西的方法
    /// </summary>
    /// <param name="name">抽屉的名字</param>
    /// <returns>从缓存池中取出的对象</returns>
    public GameObject GetObj(string name)
    {
        GameObject obj;
        //有抽屉 并且 抽屉里 有对象 才去直接拿
        if(poolDic.ContainsKey(name) && poolDic[name].Count > 0)
        {
            obj = poolDic[name].Pop();
            //激活再取出来
            obj.SetActive(true);
        }
        //否则 直接去创造
        else
        {  
            //没有的时候 通过资源加载 去实例化出一个GameObject
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //避免实例化出来的对象 默认会在后面加一个（Clone）
            //我们重命名过后 方便往里面放
            obj.name = name;
        }
        return obj;
    }
    /// <summary>
    /// 往缓存池中放东西
    /// </summary>
    /// <param name="name">要放入抽屉的名字</param>
    /// <param name="obj">要放入的对象</param>
    public void PushObj(GameObject obj)
    {
        //并不是直接移除对象 而是将对象失活一会再用 用的时候再激活它
        //除了这种方式 还可以把对象放在视野外
        obj.SetActive(false);
        //没有抽屉 创建抽屉
        if(!poolDic.ContainsKey(obj.name))
            poolDic.Add(obj.name, new Stack<GameObject>());

        //往抽屉当中放对象
        poolDic[obj.name].Push(obj);

        ////如果存在对应的抽屉容器 直接放
        //if (poolDic.ContainsKey(name))
        //{
        //    //往栈（抽屉）中放入对象
        //    poolDic[name].Push(obj);
        //}
        ////否则 需要先创建抽屉 再放
        //else
        //{
        //    //先创建抽屉
        //    poolDic.Add(name, new Stack<GameObject>());
        //    poolDic[name].Push(obj);
        //}
    }
    /// <summary>
    /// 用于清楚整个柜子当中的数据
    /// 使用场景 主要是 切场景时
    /// </summary>
    public void ClearPool()
    {
        poolDic.Clear();
    }
}
