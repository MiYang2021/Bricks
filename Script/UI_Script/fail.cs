using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fail : MonoBehaviour
{
    public Button RESET;
    public Button BACK;
    public Vector3 direction;
    public GameObject AllComponents = null; 
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
            GameObject.Find("Position_set").GetComponent<Shoot>().life = 3;
            GameObject.Find("Position_set").GetComponent<Shoot>().check = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count = 0;
            GameObject.Find("Counter").GetComponent<Counter>().timer = 120.0f;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position = direction;

            AllComponents = GameObject.Find("Bricks");
            foreach (Transform child in AllComponents.transform)
            {
                Destroy(child.gameObject);
            }
            GameObject.Find("Bricks").GetComponent<Brick>().reset = true;
        });
        BACK.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Position_set").GetComponent<Shoot>().life = 3;
            GameObject.Find("Position_set").GetComponent<Shoot>().check = false;
            GameObject.Find("Position_set").GetComponent<Shoot>().get_count = 0;
            GameObject.Find("Counter").GetComponent<Counter>().timer = 120.0f;
            
            GameObject.Find("Position_set").GetComponent<Shoot>().gameObject.transform.position = direction;

            AllComponents = GameObject.Find("Bricks");
            foreach (Transform child in AllComponents.transform)
            {
                Destroy(child.gameObject);
            }
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_fail = false;
            GameObject.Find("Bricks").GetComponent<Brick>().again = true;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = true;
            GameObject.Find("Position_set").GetComponent<Shoot>().UI_check = false;
        });
    }
}
