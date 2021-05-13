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
    public string alarm_text;
    public bool check;//屏幕中是否有小球
    public bool UI_check;//是否已经结束UI
    public bool text = false;
    public int get_count;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        ball_speed = 10;
        get_count = 0;
        life = 3;
        check = false;
        UI_check = false;
        alarm_text = "<color=red>Please Don't Leave The Area!</color>";

    }
// Update is called once per frame
void Update()
    {
        float h = Input.GetAxis("Horizontal");//获取“A”“D”键的按动情况

        if(UI_check==true)
         {
            transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime * speed);

          }

        //设置移动板移动
        if ((Input.GetMouseButtonDown(0))&&(life!=0)&&(check==false)&&(UI_check==true))//按下鼠标且还有发射机会时发射小球
        {
            GameObject a = GameObject.Instantiate(ball, transform.position, Quaternion.Euler(0, 0, 0));
            //克隆小球
          
            Rigidbody rgd = a.GetComponent<Rigidbody>(); //把a刚体属性给rgd
            direction = new Vector3(1,1,0);
            rgd.velocity = direction* ball_speed;


            life--;//可发射小球次数减一
            check = true;

        }
       Debug.Log(get_count);

    }
}
