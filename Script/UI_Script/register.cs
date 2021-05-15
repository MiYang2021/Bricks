using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 注册UI的控制脚本
/// </summary>
public class register : MonoBehaviour
{
    public InputField username;//输入框
    public InputField password;
    public InputField passwordAgain;
    public Button register_password;//注册按钮
    public Button register_username;//检查用户名按钮
    public Text username_alarm;//提示信息
    public Text password_alarm;

    public string alarm_1;
    public string alarm_2;
    public string set_username;
    public string set_password;
    public string password_again;
    public float goal;
    public bool check;
    public bool login_or_register;//是否已注册
    /*其他脚本参数
     * UI_SET set_register
     * UI_SET set_select
     */

    // Start is called before the first frame update
    void Start()
    {
        alarm_1 = "<color=red>The Username already exists!</color>";
        alarm_2 = "<color=red>The two inputs are different!</color>";
        login_or_register = false;//初始时未注册
        goal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        set_username = username.GetComponent<InputField>().text;//获取用户输入的用户名
        register_username.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            check = PlayerPrefs.HasKey(set_username);//检查用户名是否已存在
            if (check==true)
            {
                username_alarm.text = alarm_1;
            }
            else
            {
                username_alarm.text = "Set the password below";
            }
        });
        set_password = password.GetComponent<InputField>().text;//获取两次输入的密码
        password_again = passwordAgain.GetComponent<InputField>().text;
        register_password.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            if (set_password == password_again)//如果两次输入的密码一样
            {
                PlayerPrefs.SetString(set_username, set_password);//注册账户密码
                PlayerPrefs.SetFloat(set_username + "goal", 0);//初始化历史最高分
                goal = PlayerPrefs.GetFloat(set_username + "goal");
                password_alarm.text = "Registered successfully!";
                login_or_register = true;//已注册
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_register = false;//关闭注册页面
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = true;//进入选择页面
            }
            else
            {
                password_alarm.text = alarm_2;
            }
        });
        

    }
}
