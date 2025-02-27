using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public GameObject TPUI;
    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OpenTP()
    {
        
        TPUI.SetActive(true);
        open = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && open==true)
        {
            TPUI.SetActive(false);
            
        }
    }
    public void  TP1()
    {
        new Vector3(-22.27f, 10.26f, 0.00f);
        transform.position = new Vector3(-22.27f, 10.26f, 0.00f);
    }
    public void TP2()
    {
        new Vector3(175.86f, -25.23f, 0.00f);
        transform.position = new Vector3(175.86f, -25.23f, 0.00f);
    }
}
