using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
/// <summary>
/// 计时器、显示剩余小球数、剩余砖块数、终止按钮的控制脚本
/// </summary>
public class Counter : MonoBehaviour
{
    private Text textComponent;//显示倒计时
    public Text Life;//显示剩余小球数
    public Text brick_number;//显示剩余砖块数
    public Button GIVE_UP;//终止按钮

    public float timer;//计时
    private bool click;//判断鼠标是否已点击
    public bool pause;//是否暂停
    public int brick = 0;//剩余砖块数
    /*其他脚本变量
     * UI_SET set_fail
     * UI_SET set_quet
     */

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        if (!textComponent)//如果没有文本组件则报错
        {
            Debug.LogError
            ("This is need to ……");
            enabled = false;
            return;
        }
        timer = 120.0f;//设定初始时间
        click = false;//点击鼠标后再开始计时
        pause = false;//设置暂停
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        brick = 100 - GameObject.Find("Bricks").GetComponent<Brick>().brick_number;//获取砖块总数
        if ((Input.GetMouseButtonDown(0))&&(GameObject.Find("Position_set").GetComponent<Shoot>().UI_check == true))//按下鼠标开始计时
        {
            click = true;
            pause = false;
        }
        if((click==true)&&(pause==false))
        {
            timer -= Time.deltaTime;//倒计时
            //倒计时分时段变色
            if (timer < 40)
                textComponent.color = Color.red;
            else if (timer < 80)
                textComponent.color = Color.yellow;
            else
                textComponent.color = Color.green;

            Life.text = string.Format("剩余次数：{0}", GameObject.Find("Position_set").GetComponent<Shoot>().life.ToString());//记录剩余的小球数
            textComponent.text = string.Format("{0}s", Mathf.Round(timer));//显示剩余时间
            brick_number.text = string.Format("剩余砖块数目：{0}",brick-GameObject.Find("Position_set").GetComponent<Shoot>().get_count);//显示剩余砖块
            if (timer <= 0)//时间结束，计时暂停，游戏失败
            {
                pause = true;
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = true;
                textComponent.text = "<color=red>Time Over!!!</color>";
            }
        }
        GIVE_UP.GetComponent<Button>().onClick.AddListener(delegate ()//点击终止按钮进入退出游戏页面
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_quet = true;
        });
        if (click==false)//计时未开始时的显示
            textComponent.text = "Ready";
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail == true)//游戏失败时停止计时
            pause = true;
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success == true)//游戏成功时停止计时
            pause = true;
    }
}
