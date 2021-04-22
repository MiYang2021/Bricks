using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class success : MonoBehaviour
{
    public Button CONTINUE;
    public Text Goal;

    public float GOAL;
    public float HISTORY_GOAL;
    public float goal;
    public int brick_number;
    public float time;
    public string username;
    // Start is called before the first frame update
    void Start()
    {
        goal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        brick_number = GameObject.Find("Position_set").GetComponent<Shoot>().get_count;
        time = GameObject.Find("Counter").GetComponent<Counter>().timer;
        if(GameObject.Find("Canvas_Register") != null)
        {
            if (GameObject.Find("Canvas_Register").GetComponent<register>().login_or_register == true)
            {
                username = GameObject.Find("Canvas_Register").GetComponent<register>().set_username;
            }
        }
        if(GameObject.Find("Canvas_Login") != null)
        {
            if (GameObject.Find("Canvas_Login").GetComponent<login>().login_or_register == true)
            {
                username = GameObject.Find("Canvas_Login").GetComponent<login>().get_username;
            }
        }
        

        HISTORY_GOAL = PlayerPrefs.GetFloat(username+"goal");
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success == true)
        {
            goal = Mathf.Round(brick_number * time * 100);
            if(goal > HISTORY_GOAL)
            {
                GOAL = goal;
            }
            else
            {
                GOAL = HISTORY_GOAL;
            }
            
            PlayerPrefs.SetFloat(username+"goal", GOAL);
        }
        Goal.text = string.Format("历史最高分：{0}  本次得分：{1}",GOAL,goal);
        CONTINUE.GetComponent<Button>().onClick.AddListener(delegate ()
        {

            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success = false;
         //   GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login = true;
        });


    }
}
