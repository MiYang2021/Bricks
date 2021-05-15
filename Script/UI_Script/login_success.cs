using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 登陆成功提示窗的控制脚本
/// </summary>
public class login_success : MonoBehaviour
{
    public Canvas Login_success;//提示窗

    public float time;//计时

    /*其他脚本变量
     * UI_SET set_login_flag
     * Shoot UI_check
     */

    // Start is called before the first frame update
    void Start()
    {
        time = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag == true)//提示窗显示后计时
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)//判断是否到时间
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = false;//提示窗消失
            GameObject.Find("Position_set").GetComponent<Shoot>().UI_check = true;//UI结束，进入游戏模式
        }
    }
}
