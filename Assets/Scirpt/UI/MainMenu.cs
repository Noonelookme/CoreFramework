using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()//��ʼ��Ϸ����
    {
        SceneManager.LoadScene(1);//��ת����ͼ1
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
