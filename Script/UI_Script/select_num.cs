using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class select_num : MonoBehaviour
{
    public Slider num_set;
    public Text brick_number;
    public Slider speed_set;
    public Text ball_speed;
    public Button OK;

    public float number;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        number = num_set.value;
        speed = speed_set.value;
        number = Mathf.Round(number);
        speed = Mathf.Round(speed);
        brick_number.text = string.Format("砖块数目：{0}", number);
        ball_speed.text = string.Format("小球速度:{0}", speed);

        OK.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Bricks").GetComponent<Brick>().check = true;
            GameObject.Find("Bricks").GetComponent<Brick>().brick_number = (int)number;
            GameObject.Find("Position_set").GetComponent<Shoot>().ball_speed = (int)speed;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select_num = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;
        });
    }   
    
}
