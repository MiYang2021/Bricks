using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/// <summary>
/// 设置砖块数和小球速度的页面控制脚本
/// </summary>
public class select_num : MonoBehaviour
{
    public Slider num_set;//选择砖块数量的滑条
    public Text brick_number;//显示砖块数
    public Slider speed_set;//选择小球速度的滑条
    public Text ball_speed;//显示小球速度
    public Button OK;//确认按钮

    public float number;//记录砖块数
    public float speed;//记录小球速度
    /*其他脚本变量
     * Brick check
     * Brick brick_number
     * Shoot ball_speed
     * UI_SET set_select
     * UI_SET set_login_flag
     */
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        number = num_set.value;//砖块数为滑条的值
        speed = speed_set.value;//小球速度为滑条的值
        number = Mathf.Round(number);//取整
        speed = Mathf.Round(speed);
        brick_number.text = string.Format("砖块数目：{0}", number);//显示
        ball_speed.text = string.Format("小球速度:{0}", speed);

        OK.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Bricks").GetComponent<Brick>().check = true;//开始定义砖块形式
            GameObject.Find("Bricks").GetComponent<Brick>().brick_number = (int)number;//砖块数赋值
            GameObject.Find("Position_set").GetComponent<Shoot>().ball_speed = (int)speed;//小球速度赋值
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select_num = false;//关闭选数页面
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;//准备进入游戏
        });
    }   
    
}
