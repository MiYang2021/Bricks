using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 开始UI控制脚本
/// </summary>
public class begin : MonoBehaviour
{
    public Button LOGIN;//点击进入登录页面
    /*
     其他脚本的变量 
      UI_SET set_begin
      UI_SET set_login
     */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LOGIN.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_begin = false;//关闭Begin页面
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login = true;//开启Login页面
        });
    }
}