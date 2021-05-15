using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏成功页面的控制脚本
/// </summary>
public class success : MonoBehaviour
{
    public Button CONTINUE;//返回Select页面
    public Text Goal;//输出分数

    public Vector3 direction;//记录position_set的初始位置

    public float GOAL;//用于记录最高分
    public float HISTORY_GOAL;//获取历史最高分
    public float goal;//本次得分
    public int brick_number;//获取击碎的砖块数
    public float time;//通关时间
    public string username;//用户名

    /*其他脚本变量
     * PlayerPrefs username+"goal"
     * Shoot life
     * Shoot check
     * Shoot get_count
     * Shoot gameObject.transform.position
     * Shoot UI_check
     * Count timmer
     * Brick again
     * UI_SET set_success
     * UI_SET set_select
     */

    // Start is called before the first frame update
    void Start()
    {
        goal = 0;//初始化分数
        direction = GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position;//获取position_set的初始位置
    }

    // Update is called once per frame
    void Update()
    {
        brick_number = GameObject.Find("Position_set").GetComponent<Shoot>().get_count;//获取击碎的砖块数量
        time = GameObject.Find("Counter").GetComponent<Counter>().timer;//获取所用的时间
        if(GameObject.Find("Canvas_Register") != null)//如果是通过注册进入游戏的通过此函数获取用户名
        {
            if (GameObject.Find("Canvas_Register").GetComponent<register>().login_or_register == true)//如果已登录
            {
                username = GameObject.Find("Canvas_Register").GetComponent<register>().set_username;
            }
        }
        if(GameObject.Find("Canvas_Login") != null)//如果是直接登录进入游戏的通过此函数获取用户名
        {
            if (GameObject.Find("Canvas_Login").GetComponent<login>().login_or_register == true)//如果已登录
            {
                username = GameObject.Find("Canvas_Login").GetComponent<login>().get_username;
            }
        }
        
        HISTORY_GOAL = PlayerPrefs.GetFloat(username+"goal");//获取历史最高分
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success == true)
        {
            goal = Mathf.Round(brick_number * time * 100);//计算本次得分
            if(goal > HISTORY_GOAL)//比较历史最高分和本次得分
            {
                GOAL = goal;
            }
            else
            {
                GOAL = HISTORY_GOAL;
            }
            
            PlayerPrefs.SetFloat(username+"goal", GOAL);//记录最高分
        }
        Goal.text = string.Format("历史最高分：{0}  本次得分：{1}",GOAL,goal);//显示最高分和本次得分
        CONTINUE.GetComponent<Button>().onClick.AddListener(delegate ()//点击CONTINUE
        {

            GameObject.Find("Position_set").GetComponent<Shoot>().life = 3;//剩余小球数恢复为3
            GameObject.Find("Position_set").GetComponent<Shoot>().check = false;//屏幕中无小球
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count = 0;//获取击碎的砖块数
            GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position = direction;//滑动板恢复原位
            GameObject.Find("Counter").GetComponent<Counter>().timer = 120.0f;//时间恢复

            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success = false;//退出Success页面
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = true;//进入Select页面
            GameObject.Find("Bricks").GetComponent<Brick>().again = true;//重新初始化砖块
            GameObject.Find("Position_set").GetComponent<Shoot>().UI_check = false;//回到游戏前UI未结束的状态
        });


    }
}
