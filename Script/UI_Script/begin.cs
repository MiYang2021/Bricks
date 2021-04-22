using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class begin : MonoBehaviour
{
    public Button LOGIN;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LOGIN.GetComponent<Button>().onClick.AddListener(delegate ()
        {
           
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_begin = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login = true;
        });

    }
}
