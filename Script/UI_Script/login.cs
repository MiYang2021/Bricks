using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 登录UI控制脚本
/// </summary>
public class login : MonoBehaviour
{
    public InputField username;//用户名输入框
    public InputField password;//密码输入框
    public Button LOGIN;//登录按钮
    public Button REGISTER;//进入注册
    public Text alarm;//警告文字

    public string alarm_1;//警告文字
    public string get_username;//输入的用户名
    public string get_password;//输入的密码
    public bool check;//输入的用户名对应的密码
    public bool login_or_register;
    /*其他脚本变量
     * UI_SET set_login
     * UI_SET set_register
     * UI_SET set_select
     */

    // Start is called before the first frame update
    void Start()
    {
        alarm_1 = "<color=red>Incorrect username or password </color>";
        login_or_register = false;
        //PlayerPrefs.DeleteAll();//清除所有存储的用户信息！谨慎调取！！
    }

    // Update is called once per frame
    void Update()
    {
        get_username = username.GetComponent<InputField>().text;//获取输入框的输入信息
        get_password = password.GetComponent<InputField>().text;

        LOGIN.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            if (get_username != "")//如果用户名非空，获取用户名对应密码
            {
                check = PlayerPrefs.GetString(get_username) == get_password;
            }
            if (check==true)//如果密码存在登录成功
            {
                alarm.text = "Login successfully!";
                login_or_register = true;
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login = false;
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = true;
            }
            else//如果密码不存在返回提示信息
            {
                alarm.text = alarm_1;
            }
        });

        REGISTER.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login = false;//关闭登录页面
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_register = true;//进入注册页面
        });
    }
}
