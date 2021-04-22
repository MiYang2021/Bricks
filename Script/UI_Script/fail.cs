using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//GameObject.Find("").GetComponent<>().

public class fail : MonoBehaviour
{
    public Button RESET;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position;
    }

   

    // Update is called once per frame
    void Update()
    {
        RESET.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Position_set").GetComponent<Shoot>().life = 2;
            GameObject.Find("Position_set").GetComponent<Shoot>().check = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count = 0;
            GameObject.Find("Counter").GetComponent<Counter>().timer = 60.0f;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position = direction;
        });
    }
}
