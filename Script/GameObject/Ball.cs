using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 判断小球击中物体类型、以及对小球击碎的砖块进行计数、判断成功失败的脚本
/// </summary>
public class Ball : MonoBehaviour
{
    public int count;//击碎砖块数
    public int ground_count = 1;//击中地面的次数
    public int brick_number = 0;//所有砖块的总数
    public bool des = false;//摧毁小球的参数

    /*其他脚本参数
     * Shoot get_count
     * Shoot check
     * Counter pause
     * UI_SET get_success
     * UI_SET set_fail
     */

    // Start is called before the first frame update
    void Start()
    {
        count = GameObject.Find("Position_set").GetComponent<Shoot>().get_count;//每个小球生成时都会获取之前击碎的砖块数
    }

    // Update is called once per frame
    void Update()
    {
        brick_number =100 - GameObject.Find("Bricks").GetComponent<Brick>().brick_number;//获取砖块总数
        if(des)//摧毁小球
        {
            Destroy(this.gameObject); 
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Bricks")//如果击中砖块
        {
            count += 1;//计数加一
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count=count;//将增加的值存到其他脚本中
            Destroy(other.gameObject);//摧毁砖块
            if (count==brick_number)//判断是否已经摧毁所有砖块
            {
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success = true;//游戏成功
                GameObject.Find("Counter").GetComponent<Counter>().pause = true;//暂停计时
                des = true;//摧毁砖块
            }
        }

        if (other.gameObject.tag == "Ground")//如果击中地板
        {
            if(ground_count==0)//如果不是生成的时候接触地板
            {
                GameObject.Find("Position_set").GetComponent<Shoot>().check = false;//重新进入可发射小球的状态
                if(GameObject.Find("Position_set").GetComponent<Shoot>().life ==0)//如果没有可发射小球的机会
                {
                    GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = true;//游戏失败
                }
                des = true;//摧毁小球
                GameObject.Find("Counter").GetComponent<Counter>().pause = true;//暂停计时
            }
            ground_count--;//如果是首次击中地面，为生成小球时的误触，下次接触时才摧毁小球
        }
        if(GameObject.Find("Counter").GetComponent<Counter>().timer <= 0)//如果计时结束，摧毁小球
            des = true;
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail==true)//如果游戏失败，摧毁小球
            des = true;
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success == true)//如果游戏成功，摧毁小球
            des = true;
    }
}
