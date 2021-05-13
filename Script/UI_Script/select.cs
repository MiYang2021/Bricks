using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class select : MonoBehaviour
{
    public Button CLASSICAL;
    public Button DEFFINED_THE_NUMBER;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DEFFINED_THE_NUMBER.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select_num = true;
            GameObject.Find("Bricks").GetComponent<Brick>().choose = 0;
            GameObject.Find("Bricks").GetComponent<Brick>().again = false;
        });
        CLASSICAL.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_classical = true;
        });
    }
}
