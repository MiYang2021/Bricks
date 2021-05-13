using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class classical : MonoBehaviour
{
    public Button MODEL_1;
    public Button MODEL_2;
    public Button MODEL_3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MODEL_1.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Bricks").GetComponent<Brick>().choose = 1;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_classical = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;
            GameObject.Find("Bricks").GetComponent<Brick>().check = true;
            GameObject.Find("Bricks").GetComponent<Brick>().again = false;
            GameObject.Find("Bricks").GetComponent<Brick>().brick_number = 30;
        });
        MODEL_2.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Bricks").GetComponent<Brick>().choose = 2;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_classical = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;
            GameObject.Find("Bricks").GetComponent<Brick>().check = true;
            GameObject.Find("Bricks").GetComponent<Brick>().again = false;
            GameObject.Find("Bricks").GetComponent<Brick>().brick_number = 50;
        });
        MODEL_3.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Bricks").GetComponent<Brick>().choose = 3;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_classical = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_login_flag = true;
            GameObject.Find("Bricks").GetComponent<Brick>().check = true;
            GameObject.Find("Bricks").GetComponent<Brick>().again = false;
            GameObject.Find("Bricks").GetComponent<Brick>().brick_number = 38;
        });
    }
}
