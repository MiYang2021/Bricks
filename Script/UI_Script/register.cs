using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class register : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public InputField passwordAgain;
    public Button register_password;
    public Button register_username;
    public Text username_alarm;
    public Text password_alarm;

    public string alarm_1;
    public string alarm_2;
    public string set_username;
    public string set_password;
    public string password_again;
    public float goal;
    public bool check;
    public bool login_or_register;
    
    // Start is called before the first frame update
    void Start()
    {
        alarm_1 = "<color=red>The Username already exists!</color>";
        alarm_2 = "<color=red>The two inputs are different!</color>";
        login_or_register = false;
        goal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        set_username = username.GetComponent<InputField>().text;
        register_username.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            check = PlayerPrefs.HasKey(set_username);
           // Debug.Log(check);
            if (check==true)
            {
                username_alarm.text = alarm_1;
            }
            else
            {
                username_alarm.text = "Set the password below";
            }
        });


        set_password = password.GetComponent<InputField>().text;
        password_again = passwordAgain.GetComponent<InputField>().text;

        register_password.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            if (set_password == password_again)
            {
                PlayerPrefs.SetString(set_username, set_password);//注册账户密码
                PlayerPrefs.SetFloat(set_username + "goal", 0);//记录历史最高分
                goal = PlayerPrefs.GetFloat(set_username + "goal");
                password_alarm.text = "Registered successfully!";
                login_or_register = true;
                //         GameObject.Find("Main Camera").GetComponent<UI_SET>().set_register = false;
                //           GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;

            }
            else
            {
                password_alarm.text = alarm_2;
            }
        });
        

    }
}
