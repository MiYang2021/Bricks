using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 选择UI的控制脚本
/// </summary>
public class select : MonoBehaviour
{
    public Button CLASSICAL;//进入经典模式的按钮
    public Button DEFFINED_THE_NUMBER;//进入自定义模式的按钮

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
            GameObject.Find("Bricks").GetComponent<Brick>().choose = 0;//砖块定义模式为0模式
            GameObject.Find("Bricks").GetComponent<Brick>().again = false;//不再初始化砖块
        });
        CLASSICAL.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_select = false;
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_classical = true;
        });
    }
}
