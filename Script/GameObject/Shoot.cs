using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 小球发射、滑动板移动控制、以及计数的控制脚本
/// </summary>
public class Shoot : MonoBehaviour
{
    public GameObject ball;//对象：小球
    public Vector3 direction;//小球发射的方向

    public int speed;//移动板的移动速度
    public int ball_speed;//小球的默认速度
    public float h;//移动板的横坐标
    public int life;//可发射的小球数
    public float ball_y;//小球的y坐标
    public bool check;//屏幕中是否有小球
    public bool UI_check;//是否已经结束UI
    public int get_count;//记录小球击碎的砖块数

    // Start is called before the first frame update
    void Start()
    {
        speed = 15;//默认滑动板速度
        ball_speed = 10;//默认小球速度
        get_count = 0;//游戏开始时击碎的砖块数为0
        life = 3;//一共有三次发射小球的机会
        check = false;//页面无小球
        UI_check = false;//UI未结束
    }
// Update is called once per frame
void Update()
    {
        float h = Input.GetAxis("Horizontal");//获取“A”“D”键的按动情况
        if(UI_check==true)//判断进入游戏的UI是否已结束
        {
            transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime * speed);//如果进入游戏则可通过键盘控制滑动板位置
        }

        if ((Input.GetMouseButtonDown(0))&&(life!=0)&&(check==false)&&(UI_check==true))//按下鼠标且还有发射机会时发射小球
        {
            GameObject a = GameObject.Instantiate(ball, transform.position, Quaternion.Euler(0, 0, 0));//克隆小球,初始化模型、位置、角度
            Rigidbody rgd = a.GetComponent<Rigidbody>(); //附加刚体属性
            direction = new Vector3(1,1,0);//初始化速度的方向
            rgd.velocity = direction* ball_speed;//定义速度
            life--;//可发射小球次数减一
            check = true;//页面已有小球
        }
    }
}
