using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool check = false;
    public int count;
    public int ground_count = 1;
    public int brick_number = 0;
    public bool des = false;//摧毁小球的参数

    // Start is called before the first frame update
    void Start()
    {
        count = GameObject.Find("Position_set").GetComponent<Shoot>().get_count;
    }

    // Update is called once per frame
    void Update()
    {
        brick_number =100 - GameObject.Find("Bricks").GetComponent<Brick>().brick_number;
        if(des)
        {
            Destroy(this.gameObject); 
        }
    }
    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag=="Bricks")
        {
            count += 1;
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count=count;
            Destroy(other.gameObject);
            //           Debug.Log(count);
            if (count==brick_number)
            {
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success = true;
                GameObject.Find("Counter").GetComponent<Counter>().pause = true;
                //Destroy(this.gameObject);
                des = true;
            }
        }

        if (other.gameObject.tag == "Ground")
        {
            
            if(ground_count==0)
            {
                GameObject.Find("Position_set").GetComponent<Shoot>().check = false;
                if(GameObject.Find("Position_set").GetComponent<Shoot>().life ==0)
                {
                    GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = true;
                }
                des = true;
                GameObject.Find("Counter").GetComponent<Counter>().pause = true;

            }
            ground_count--;
        }
        if(GameObject.Find("Counter").GetComponent<Counter>().timer <= 0)
        {
            des = true;
        }
        if(GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail==true)
        {
            des = true;
        }
        if (GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success == true)
        {
            des = true;
        }
        //Debug.Log("Tag is " + other.gameObject.tag);
    }
}
