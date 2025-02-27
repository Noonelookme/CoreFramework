using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()//开始游戏函数
    {
        SceneManager.LoadScene(1);//跳转到地图1
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
