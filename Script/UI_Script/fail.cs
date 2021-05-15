using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏失败UI控制脚本
/// </summary>
public class fail : MonoBehaviour
{
    public Button RESET;//重置（开始新游戏）按钮
    public Button BACK;//返回选择模式按钮
    public Vector3 direction;//保留滑动板最初位置
    public GameObject AllComponents = null; //用于删除所有页面上残留的砖块

    /*其他脚本变量
     * Shoot life
     * Shoot check
     * Shoot get_count
     * Shoot gameObject.transform.position
     * Shoot UI_check
     * Count timmer
     * UI_SET set_fail
     * UI_SET set_select
     * Brick reset
     * Brick again
     */

    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RESET.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //各个数据恢复初始化
            GameObject.Find("Position_set").GetComponent<Shoot>().life = 3;
            GameObject.Find("Position_set").GetComponent<Shoot>().check = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count = 0;
            GameObject.Find("Counter").GetComponent<Counter>().timer = 120.0f;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position = direction;

            AllComponents = GameObject.Find("Bricks");//AllComponents为所有砖块的父物体
            foreach (Transform child in AllComponents.transform)//遍历摧毁所有还在页面中的砖块
            {
                Destroy(child.gameObject);
            }
            GameObject.Find("Bricks").GetComponent<Brick>().reset = true;//重新生成砖块
        });
        BACK.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //各个数据恢复初始化
            GameObject.Find("Position_set").GetComponent<Shoot>().life = 3;
            GameObject.Find("Position_set").GetComponent<Shoot>().check = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count = 0;
            GameObject.Find("Counter").GetComponent<Counter>().timer = 120.0f;
            GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position = direction;

            AllComponents = GameObject.Find("Bricks");
            foreach (Transform child in AllComponents.transform)//遍历摧毁所有还在页面中的砖块
            {
                Destroy(child.gameObject);
            }
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = false;
            GameObject.Find("Bricks").GetComponent<Brick>().again = true;//重新初始化砖块
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = true;//进入选择页面
            GameObject.Find("Position_set").GetComponent<Shoot>().UI_check = false;//进入UI未结束状态
        });
    }
}
