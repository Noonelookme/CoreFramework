using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject loadScreen;//画板
    public Slider slider;//进度条
    public TextMeshProUGUI text;//文本框


    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel());
    }



    IEnumerator Loadlevel()
    {
        loadScreen.SetActive(true);//显示出进度条和文本框
        //获取下一个场景加载
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //不允许跳转到下一场景
        operation.allowSceneActivation = false;
        //场景未加载完成就一直循环
        while (!operation.isDone)
        {
            //令场景加载的进度等于进度条的进度
            slider.value = operation.progress;
            //文本显示场景加载进度为%多少
            text.text = operation.progress * 100 + "%";
            //不允许跳转到下一场景时 场景加载进度会停在0.9
            //当到这个数时进行处理
            if(operation.progress >= 0.9f)
            {
                //令进度条涨满
                slider.value = 1;
                //提示玩家
                text.text = "任意按键开始游戏";
                //当玩家进行任意按键时 场景可以并跳转
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
