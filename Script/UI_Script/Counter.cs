using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

///


public class Counter : MonoBehaviour
{
    private Text textComponent;
    public Text Life;
    public Text brick_number;
    public Button GIVE_UP;

    public float timer;
    private bool click;
    public bool pause;
    public int brick = 0;


    private void Awake()
    {
        textComponent = GetComponent<Text>();
        if (!textComponent)
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
        brick = 100 - GameObject.Find("Bricks").GetComponent<Brick>().brick_number;
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
            {
                textComponent.color = Color.red;
            }
            else if (timer < 80)
            {
                textComponent.color = Color.yellow;
            }
            else
            {
                textComponent.color = Color.green;
            }
            Life.text = string.Format("剩余次数：{0}", GameObject.Find("Position_set").GetComponent<Shoot>().life.ToString());//记录剩余的小球数
            textComponent.text = string.Format("{0}s", Mathf.Round(timer));//显示剩余时间
            brick_number.text = string.Format("剩余砖块数目：{0}",brick-GameObject.Find("Position_set").GetComponent<Shoot>().get_count);
            if (timer <= 0)//时间结束，计时暂停，游戏失败
            {
                pause = true;
                //des_ball = true;
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = true;
                textComponent.text = "<color=red>Time Over!!!</color>";
            }
            
        }
        GIVE_UP.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_quet = true;
        });

        if (click==false)//计时未开始时的显示
        {
            textComponent.text = "Ready";

        }
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail == true)//游戏失败时停止计时
        {
            pause = true;
        }
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success == true)//游戏成功时停止计时
        {
            pause = true;
        }

    }
}
