using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public Button LOGIN;
    public Button REGISTER;
    public Text alarm;

    public string alarm_1;
    public string get_username;
    public string get_password;
    public bool check;
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
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;

            }
            else
            {
                alarm.text = alarm_1;
            }
        });

        REGISTER.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_register = true;
        });




    }
}
