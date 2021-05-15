using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 经典模式UI控制脚本
/// </summary>
public class classical : MonoBehaviour
{
    public Button MODEL_1;//模式１
    public Button MODEL_2;//模式２
    public Button MODEL_3;//模式３
    /*其他脚本变量
     * Brick choose
     * Brick check
     * Brick again
     * Brick brick_number
     * UI_SET set_login_flag
     * UI_SET set_classical
     */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MODEL_1.GetComponent<Button>().onClick.AddListener(delegate ()//模式一
        {
            GameObject.Find("Bricks").GetComponent<Brick>().choose = 1;//选择模式一
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_classical = false;//关闭选择页面
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;//准备进入游戏
            GameObject.Find("Bricks").GetComponent<Brick>().check = true;//可以开始定义砖块
            GameObject.Find("Bricks").GetComponent<Brick>().again = false;//结束初始化砖块
            GameObject.Find("Bricks").GetComponent<Brick>().brick_number = 30;//砖块数为30
        });
        MODEL_2.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Bricks").GetComponent<Brick>().choose = 2;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_classical = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;
            GameObject.Find("Bricks").GetComponent<Brick>().check = true;
            GameObject.Find("Bricks").GetComponent<Brick>().again = false;
            GameObject.Find("Bricks").GetComponent<Brick>().brick_number = 50;
        });
        MODEL_3.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Bricks").GetComponent<Brick>().choose = 3;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_classical = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;
            GameObject.Find("Bricks").GetComponent<Brick>().check = true;
            GameObject.Find("Bricks").GetComponent<Brick>().again = false;
            GameObject.Find("Bricks").GetComponent<Brick>().brick_number = 38;
        });
    }
}
