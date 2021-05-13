using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 登录页面控制脚本
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
    public bool check;//
    public bool login_or_register;


    // Start is called before the first frame update
    void Start()
    {
        alarm_1 = "<color=red>Incorrect username or password </color>";
        login_or_register = false;
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        get_username = username.GetComponent<InputField>().text;
        get_password = password.GetComponent<InputField>().text;

        LOGIN.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //Debug.Log(check);
            if (get_username != "")
            {
                check = PlayerPrefs.GetString(get_username) == get_password;
            }
            
            if (check==true)
            {
                alarm.text = "Login successfully!";
                login_or_register = true;
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login = false;
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = true;

            }
            else
            {
                alarm.text = alarm_1;//
            }
        });

        REGISTER.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login = false;//关闭登录页面
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_register = true;//进入注册页面
        });
    }
}
