using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login_success : MonoBehaviour
{
    public Canvas Login_success;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag == true)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().UI_check = true;

        }
    }
}
