using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject loadScreen;//����
    public Slider slider;//������
    public TextMeshProUGUI text;//�ı���


    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel());
    }



    IEnumerator Loadlevel()
    {
        loadScreen.SetActive(true);//��ʾ�����������ı���
        //��ȡ��һ����������
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //��������ת����һ����
        operation.allowSceneActivation = false;
        //����δ������ɾ�һֱѭ��
        while (!operation.isDone)
        {
            //������صĽ��ȵ��ڽ������Ľ���
            slider.value = operation.progress;
            //�ı���ʾ�������ؽ���Ϊ%����
            text.text = operation.progress * 100 + "%";
            //��������ת����һ����ʱ �������ؽ��Ȼ�ͣ��0.9
            //���������ʱ���д���
            if(operation.progress >= 0.9f)
            {
                //�����������
                slider.value = 1;
                //��ʾ���
                text.text = "���ⰴ����ʼ��Ϸ";
                //����ҽ������ⰴ��ʱ �������Բ���ת
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
