using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool check = false;
    public int count;
    public int ground_count = 1;

    // Start is called before the first frame update
    void Start()
    {
        count = GameObject.Find("Position_set").GetComponent<Shoot>().get_count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag=="Bricks")
        {
            count += 1;
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count=count;
            Destroy(other.gameObject);
            //           Debug.Log(count);
            if (count==20)
            {
                GameObject.Find("Main Camera").GetComponent<UI_SET>().set_success = true;
                GameObject.Find("Counter").GetComponent<Counter>().pause = true;
                Destroy(this.gameObject);

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
                Destroy(this.gameObject);
                GameObject.Find("Counter").GetComponent<Counter>().pause = true;

            }
            ground_count--;
        }
        if(GameObject.Find("Counter").GetComponent<Counter>().timer <= 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log("Tag is " + other.gameObject.tag);
    }
}
