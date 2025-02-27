using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cainos.PixelArtTopDown_Basic;
using UnityEngine.InputSystem;
public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public TMPro.TextMeshProUGUI textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;

    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        GetTextFormFile(textFile);
        index = 0;
    }
    private void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && index == textList.Count)
        {
            gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerInput>().enabled = true;
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.E) )
        {
            textLabel.text = textList[index];
            index++;
        }
    }
    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach(var line in lineDate)
        {
            textList.Add(line);
        }

    }
}
